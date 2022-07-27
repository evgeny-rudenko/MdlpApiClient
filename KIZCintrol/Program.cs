using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dapper;
using System.Data.Sql;
using System.Data.SqlClient;


namespace KIZCintrol
{
    
    
    internal class Program
    {
        public static string farmaConnectionString;
        public static SqlConnection farmaConnection;
        
        /// <summary>
        /// Получаем 14 значный код МДЛП текущей точки 
        /// </summary>
        /// <returns></returns>
        public static string  MdlpCode ()
        {

            string mdlpcodesql = "SELECT KIZ_CODE  from CONTRACTOR  WHERE ID_CONTRACTOR = DBO.FN_CONST_CONTRACTOR_SELF()";
            string result = farmaConnection.Query<string>(mdlpcodesql).ToList().First() ;
            return result;
        }
        static void Main(string[] args)
        {
                        
            

            farmaConnectionString = Properties.Settings.Default.ConnectionString;
            farmaConnection = new SqlConnection(farmaConnectionString);

            StoreEfarma store = new StoreEfarma();
            
            
            string filename = @"c1e2652f-4c3d-4e29-9184-818fbc517415-0.csv";
            
            if (args.Length>0)
            {
                if (File.Exists(args[0]))
                    filename = args[0];
            }

            string[] kizstr = File.ReadAllLines(filename);
            kizstr = kizstr.Skip(1).ToArray();

            string md = MdlpCode();
            md = md;

            KizFromDatabase fromDatabase = new KizFromDatabase("00000000173611");
            KizFromFile kizFromFile = new KizFromFile();
            kizFromFile.ReadKizData(kizstr);


            foreach (Kiz k in kizFromFile.kiz)
            {
                List<Kiz> kizs = fromDatabase.kiz.Where(u=> u.sgtin==k.sgtin).ToList();

                if(kizs.Count>0)
                {
                    foreach (Kiz kk in kizs)
                    
                        Console.WriteLine($"Не выведен из оборота МДЛП {k.sell_name} еФарма {kk.sell_name} SGTIN МДЛП {k.sgtin}  SGTIN еФарма {kk.sgtin} Статус МЛЛП {k.status} Статус еФарма {kk.status} ");
                }
                
            }


            //Console.ReadKey();

        }
    }
}
