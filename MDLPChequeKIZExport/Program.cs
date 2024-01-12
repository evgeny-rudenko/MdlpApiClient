using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dapper;
/*
 short status;
   using (var sqlConnection = new SqlConnection(connectionString))
   {
     var parameters = new DynamicParameters();
     parameters.Add("@ID", ID, DbType.Int32, ParameterDirection.Input);
   
     await sqlConnection.OpenAsync();
     status = await sqlConnection.ExecuteScalarAsync<short>("SELECT [StatusID] FROM     [MyTable] WHERE [ID] = @ID", parameters, commandTimeout: _sqlCommandTimeoutInSeconds);
   }
 */

namespace MDLPChequeKIZExport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;

            // 1. Подключение к БД MS SQL Server
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 2. Выполнение запроса
                string query = @"
                   SELECT DISTINCT
    K.GTIN_SGTIN,
    K.GTIN,
    K.SGTIN,
    MDLP_MD = (select top 1  kiz_code from contractor where contractor.id_contractor =  DBO.FN_CONST_CONTRACTOR_SELF()),
	DOCUMENT_SUB = COALESCE(
        ADS.MNEMOCODE,
        CH.MNEMOCODE,
        M.MNEMOCODE,
        ADE.MNEMOCODE,
        IO.MNEMOCODE,
        AR2C.MNEMOCODE,
        SVED.DOC_NUM),
    K.ID_KIZ,
    K.ID_KIZ_GLOBAL
FROM KIZ K(NOLOCK)
    INNER JOIN KIZ_2_DOCUMENT_ITEM KDI(NOLOCK) ON KDI.ID_KIZ_GLOBAL = K.ID_KIZ_GLOBAL
    INNER JOIN LOT L(NOLOCK) ON L.ID_DOCUMENT_ITEM_ADD = KDI.ID_DOCUMENT_ITEM_ADD
	INNER JOIN SCALING_RATIO SR(NOLOCK) ON SR.ID_SCALING_RATIO = L.ID_SCALING_RATIO AND SR.NUMERATOR = ISNULL(K.QUANTITY, 1)
    LEFT JOIN ACT_DISASSEMBLING ADS(NOLOCK) ON ADS.ID_ACT_DISASSEMBLING_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 6
    LEFT JOIN CHEQUE CH(NOLOCK) ON CH.ID_CHEQUE_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 7
    LEFT JOIN MOVEMENT M(NOLOCK) ON M.ID_MOVEMENT_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 8
    LEFT JOIN ACT_DEDUCTION ADE(NOLOCK) ON ADE.ID_ACT_DEDUCTION_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 20
    LEFT JOIN INVOICE_OUT IO(NOLOCK) ON IO.ID_INVOICE_OUT_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 21
    LEFT JOIN INTERFIRM_MOVING IM(NOLOCK) ON IM.ID_INTERFIRM_MOVING_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 37
    LEFT JOIN ACT_RETURN_TO_CONTRACTOR AR2C(NOLOCK) ON AR2C.ID_ACT_RETURN_TO_CONTRACTOR_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 3
    LEFT JOIN INVENTORY_SVED SVED(NOLOCK) ON SVED.ID_INVENTORY_GLOBAL = K.ID_DOCUMENT_SUB AND K.ID_TABLE_SUB = 24
where CH.MNEMOCODE is not null
and  K.[STATE] = 'EXIT'
and L.ID_STORE in (SELECT ID_STORE  from STORE WHERE STORE.ID_CONTRACTOR = DBO.FN_CONST_CONTRACTOR_SELF())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 3. Выгрузка данных в текстовый файл CSV
                    string csvFilePath;
                     csvFilePath   = "mdlp_cheque.csv"; // Путь к выходному файлу CSV

                    using (StreamWriter writer = new StreamWriter(csvFilePath))
                    {
                        // Записываем заголовки столбцов
                        writer.WriteLine("GTIN_SGTIN;GTIN;SGTIN;MDLP_MD;DOCUMENT_SUB;ID_KIZ;ID_KIZ_GLOBAL");
                        //writer.WriteLine("GTIN_SGTIN;GTIN;MDLP_MD;DOCUMENT_SUB;ID_KIZ;ID_KIZ_GLOBAL");

                        // Записываем данные
                        foreach (DataRow row in dataTable.Rows)
                        {//MDLP_MD
                            writer.WriteLine($"{row["GTIN_SGTIN"]};{row["GTIN"]};{row["SGTIN"]};{row["MDLP_MD"]};{row["DOCUMENT_SUB"]};{row["ID_KIZ"]};{row["ID_KIZ_GLOBAL"]}");
                        }
                    }

                    Console.WriteLine("Данные успешно выгружены в CSV файл.");
                }
            }

            
        }
    }
}

