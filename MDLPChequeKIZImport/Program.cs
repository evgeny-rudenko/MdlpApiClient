using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MDLPChequeKIZImport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;

            // 1. Чтение CSV файла
            string csvFilePath = "input.csv"; // Путь к входному файлу CSV

            if (args.Length > 0) // если передали параметр, то подставляем название загружаемого файла
            {
                csvFilePath = args[0];
            }

            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine("Нужно проверить название файла");
                Console.WriteLine("Файл не найден");
                return;
            }

            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string header = reader.ReadLine();
                    string[] columns = header.Split(';');

                    // Создаем столбцы в DataTable на основе заголовка
                    foreach (string column in columns)
                    {
                        dataTable.Columns.Add(column);
                    }

                    // Читаем данные из файла и добавляем их в DataTable
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < values.Length; i++)
                        {
                            row[i] = values[i];
                        }

                        dataTable.Rows.Add(row);
                    }
                }

                // 2. Загрузка содержимого файла в таблицу MS SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Создаем временную таблицу в базе данных
                    string createTableQuery = @"
                       CREATE TABLE #TempTable (
                           GTIN_SGTIN NVARCHAR(255),
                           GTIN NVARCHAR(255),
                           SGTIN NVARCHAR(255),
                           MDLP_MD NVARCHAR(255),
                           DOCUMENT_SUB NVARCHAR(255),
                           ID_KIZ VARCHAR(255),
                           ID_KIZ_GLOBAL NVARCHAR(255)
                       )";

                    using (SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                    }

                    // Выполняем быструю вставку данных из DataTable во временную таблицу с использованием SqlBulkCopy
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                    {
                        bulkCopy.DestinationTableName = "#TempTable";
                        bulkCopy.WriteToServer(dataTable);
                    }

                    // Выполняем MERGE операцию для вставки данных из временной таблицы в постоянную таблицу
                    string mergeQuery = @"
                       MERGE INTO KIZ_CHEQUE AS target
                       USING #TempTable AS source
                       ON (target.GTIN_SGTIN = source.GTIN_SGTIN
                               and target.SGTIN = source.SGTIN
                               and target.MDLP_MD = source.MDLP_MD
                               and target.DOCUMENT_SUB = source.DOCUMENT_SUB
                               and target.ID_KIZ = source.ID_KIZ
                               and target.ID_KIZ_GLOBAL = source.ID_KIZ_GLOBAL    
                        )
                       WHEN MATCHED THEN
                           UPDATE SET
                               target.GTIN = source.GTIN,
                               target.SGTIN = source.SGTIN,
                               target.MDLP_MD = source.MDLP_MD,
                               target.DOCUMENT_SUB = source.DOCUMENT_SUB,
                               target.ID_KIZ = source.ID_KIZ,
                               target.ID_KIZ_GLOBAL = source.ID_KIZ_GLOBAL
                       WHEN NOT MATCHED THEN
                           INSERT (GTIN_SGTIN, GTIN, SGTIN, MDLP_MD, DOCUMENT_SUB, ID_KIZ, ID_KIZ_GLOBAL)
                           VALUES (source.GTIN_SGTIN, source.GTIN, source.SGTIN, source.MDLP_MD, source.DOCUMENT_SUB, source.ID_KIZ, source.ID_KIZ_GLOBAL);";

                    using (SqlCommand mergeCommand = new SqlCommand(mergeQuery, connection))
                    {
                        mergeCommand.ExecuteNonQuery();
                    }

                    Console.WriteLine("Данные успешно загружены в таблицу MS SQL Server.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

          
        }
    }
}
