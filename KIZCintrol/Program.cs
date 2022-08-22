using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dapper;
using System.Data.SqlClient;
using CommandLine;

namespace KIZCintrol
{
    
    
    internal partial class Program
    {
        public static string farmaConnectionString;
        public static SqlConnection farmaConnection;
        
       
        

        /// <summary>
        /// Получаем 14 значный код МДЛП текущей точки 
        /// </summary>
        /// <returns></returns>
        public static string MdlpCode()
        {

            string mdlpcodesql = "SELECT KIZ_CODE  from CONTRACTOR  WHERE ID_CONTRACTOR = DBO.FN_CONST_CONTRACTOR_SELF()";
            string result = farmaConnection.Query<string>(mdlpcodesql).ToList().First();
            return result;
        }

        /// <summary>
        /// Получение идентификатора текущей точки из учетной системы
        /// </summary>
        /// <returns>Возвращает код текущей аптеки</returns>
        public static int ContractorCode()
        {
            string contractorCodeSQL = "SELECT TOP 1 ID_CONTRACTOR FROM CONTRACTOR WHERE ID_CONTRACTOR = DBO.FN_CONST_CONTRACTOR_SELF()";
            int result = farmaConnection.Query<int>(contractorCodeSQL).ToList().First();
            return result;

        }

        /// <summary>
        /// Получаем список складов в текущей БД
        /// </summary>
        /// <returns>Список кодов складов текущей БД</returns>
        public static List<int> GetStoreList()
        {
            List<int> result = new List<int>();
            string storesCodeSQL = "SELECT ID_STORE FROM STORE WHERE ID_CONTRACTOR = DBO.FN_CONST_CONTRACTOR_SELF()";
            result = farmaConnection.Query<int>(storesCodeSQL).ToList();

            return result;
        }

        static void Main(string[] args)
        {
           
            
            
            /// Тестовый список SGTIN 
            List<string> sgt = new List<string>();
            string goodFilter = "%";
            string filename = @"c1e2652f-4c3d-4e29-9184-818fbc517415-0.csv";

            #region Тестовые SGTIN
            // тестовые GTIN
            /*
            sgt.Add("04601498006824JZM3XDJ9LAW0A");
            sgt.Add("04601498006824PB921XQ8LA30J");
            */
            #endregion


            // https://github.com/commandlineparser/commandline#quick-start-examples
            // примеры использования библиотеки парсинга 

            Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                      
                      Console.WriteLine($"Значение фильтра товаров {o.Filter}");
                      if (o.ExitAfter)
                      {
                          
                          Console.ReadKey();
                          return;
                      }
                      goodFilter = o.Filter;
                      filename = o.MDLP;
                  });
            
            if (!File.Exists(filename))
            {
                Console.WriteLine("Нет такого файла МДЛП для обработки");
                Console.WriteLine(filename);
                return;
            }
            
            farmaConnectionString = Properties.Settings.Default.ConnectionString;
            farmaConnection = new SqlConnection(farmaConnectionString);

            StoreEfarma store = new StoreEfarma();

            string mdlpCodeFromDatabase = MdlpCode();

           
           
                            


            Console.WriteLine("Загружаем КИЗы из файла");
            string[] kizstr = File.ReadAllLines(filename);
            kizstr = kizstr.Skip(1).ToArray();
            Console.WriteLine("Загрузили КИЗы из файла");
            KizFromFile kizFromFile = new KizFromFile();
            Console.WriteLine("Разбираем и раскладываем по полочкам");
            kizFromFile.ReadKizData(kizstr);
            Console.WriteLine("Все успешно разобрали");
            Console.WriteLine("Всего записей " + kizFromFile.kiz.Count()); ;

            Console.WriteLine("Поучаем КИЗы из базы данных");
            KizFromDatabase fromDatabase = new KizFromDatabase(MdlpCode(),goodFilter);
            Console.WriteLine("КИЗы загружены из БД");

            // возможно перепутаны u.sys_id и 

            List<string> withdrawlCodes = new List<string>();
            StringBuilder sbCheque = new StringBuilder();

            foreach (Kiz k in kizFromFile.kiz)
            {
                
                List<Kiz> kizFromDatabase = fromDatabase.kiz.Where(u=> u.sgtin==k.sgtin && u.sys_id== mdlpCodeFromDatabase  ).ToList();
                

                if(kizFromDatabase.Count>0)
                {
                    foreach (Kiz kk in kizFromDatabase)
                    {

                        withdrawlCodes.Add(k.sgtin);
                        Console.WriteLine($"Не выведен из оборота МДЛП {k.sell_name} еФарма {kk.sell_name} SGTIN МДЛП {k.sgtin}  SGTIN еФарма {kk.sgtin} Статус МЛЛП {k.status} Статус еФарма {kk.status} Чек {kk.cheque}");
                        sbCheque.AppendLine(kk.sgtin+";"+kk.cheque+";"+kk.internal_barcode);
                    }  
                        
                }
                
            }

            withdrawlCodes = withdrawlCodes.Distinct().ToList();
            MDLPDoc522 d = new MDLPDoc522(withdrawlCodes, MDLPDoc522.withdrawal_type.ВыборочнКонтроль, mdlpCodeFromDatabase);
            d.XmlDoc.Save("result.xml");
            File.WriteAllText("cheque_list.txt",sbCheque.ToString());

            string g = Guid.NewGuid().ToString();

            // выгрузка документов списания в файлы
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            int chunkCounter = 0;
            List<List<string>> strings = withdrawlCodes.ChunkBy(10);
            foreach (List<string> wc in strings)
            {
                chunkCounter++;
                filename = Path.Combine(executablePath, "522", "doc_522_"+chunkCounter.ToString()+"_"+g+".xml");
                MDLPDoc522 doc522 = new MDLPDoc522(wc, MDLPDoc522.withdrawal_type.ВыборочнКонтроль, mdlpCodeFromDatabase);
                doc522.XmlDoc.Save(filename);   
            }

        }
    }
}
