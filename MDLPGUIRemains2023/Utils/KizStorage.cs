using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MDLPGUIRemains2023.Utils
{
    
    class Kiz
    {

        public string sgtin { get; set; }        // SGTIN товара
        public string status { get; set; }        // в обороте или нет 
        public string withdrawal_type { get; set; } 	//2
        public string batch { get; set; }        // номер серии
        public DateTime expiration_date { get; set; }  // СГ
        public string pack3_id { get; set; }      //	null АХЕЗ
        public string gtin { get; set; }         //GTIN товара
        public string sell_name { get; set; }    // часть наименования товара 
        public string sys_id { get; set; }       // предположительно - номер точки где числится КИЗ
        public string prod_name { get; set; }    // АМОКСИЦИЛЛИН
        public string full_prod_name { get; set; }  // полное наименование с дозировкой 
        public string source_type { get; set; }  // АХЕЗ
        public string federal_subject_name { get; set; }  //Регион таблетки
        //public DateTime last_tracing_op_date; // последняя дата операции с КИЗом 
        public string gnvlp { get; set; }        // признак ЖВ  true/false
        public string verified { get; set; }      // АХЕЗ
        public string total_cost { get; set; }    // затраты, но там нифига нет


        public string apteka_mdlp { get; set; }  //

        //Часть для заполнения данными по ефарме         
        public string cheque { get; set; }
        public string internal_barcode { get; set; }
        public string apteka { get; set; }
        public string date_cheque { get; set; }

        //public void SetFieldValue (string FieldName , string FieldValue)
        //{

        // Тут нужно сделать через Reflection , но не понял как



        //}

        #region Данные в выгрузке одна строка
        // пример 
        // "18901148253527","B001641","Найз","18901148253527B2662MOJDA3DL","В обороте","","00000000173611","2022-02-12T00:13:23"
        // что есть в файле с остатками 
        /*
        sgtin	090022600192501300961492438
        status	В обороте
        withdrawal_type	2
        batch	LD8185
        expiration_date	31.01.2025
        pack3_id	null
        gtin	09002260019250
        sell_name	Амоксициллин Сандоз
        sys_id	00000000173615
        prod_name	АМОКСИЦИЛЛИН
        full_prod_name	Амоксициллин Сандоз?, (Амоксициллин) таблетки, покрытые пленочной оболочкой, 500мг
        source_type	1
        federal_subject_name	Камчатский край
        last_tracing_op_date	2022-12-08T14:51:02
        gnvlp	true
        verified	null
        total_cost	


        */
        #endregion
    }
    internal class KizStorage
    {

        private List<string> csvfields = new List<string>();
        public List<Kiz> KizList = new List<Kiz>();
        public List<string> ChequeKizList = new List<string>();
        
        private string deleteQuotes(string strwithquotes)
        {
            strwithquotes = strwithquotes.Replace(@"""", "");
            strwithquotes = strwithquotes.Replace("\"", "");
            return strwithquotes;

        }


        /// <summary>
        /// Загрузка списков киз, которые прошли по чекам из файла
        /// </summary>
        /// <param name="filename"></param>
        public void ReadChequeKizFromFile(string filename = "cheque.csv")
        {
            ChequeKizList.Clear();

            if (!File.Exists(filename))
                return;

            // по хорошему нужно грузить пачками - может быть миллион строк в одной аптеке
            ChequeKizList = File.ReadAllLines(filename).ToList();
        }
        public void ReadMDLCSV(string filename = "remains_small.csv")
        {
            //  string filename = "remains_small.csv"; //"4496c65b-6001-4f7d-ad80-fd4974082bee.zip";
            string fieldline = File.ReadLines(filename).First();
            Dictionary<int, string> fields = new Dictionary<int, string>();

            int fieledcouner = 0;
            //список полей, которые доступны
            //заполняем словрь наименованиемя и индексом поля
            foreach (string fname in fieldline.Split(','))
            {

                csvfields.Add(deleteQuotes(fname));
                fields.Add(fieledcouner, deleteQuotes( fname));
                fieledcouner++;
            }

            AptekaCode ac = new AptekaCode();
            string[] kizstr = File.ReadAllLines(filename,Encoding.UTF8); // в других отчетах может быть UTF
            kizstr = kizstr.Skip(1).ToArray();

            string FieldName;
            string FieldValue;
            foreach (string kizline in kizstr)
            {
                
                
                string[] splitkiz = kizline.Split(',');
                if (splitkiz.Length <= 1)
                    continue;
                Kiz onekiz = new Kiz();

                for (int i=0; i < splitkiz.Length; i++)
                {
                    FieldName = "";
                    FieldValue = "";
                    if (fields.ContainsKey(i))
                    {
                        FieldName = fields[i];
                        //onekiz.SetFieldValue(FieldName,deleteQuotes( splitkiz[i]));
                        FieldValue = deleteQuotes(splitkiz[i]);
                        switch (FieldName)
                        {
                            case "sgtin":
                                onekiz.sgtin = FieldValue;
                                break;
                            case "status":
                                onekiz.status = FieldValue;
                                break;

                            case "withdrawal_type":
                                onekiz.withdrawal_type = FieldValue;
                                break;
                            case "batch":
                                onekiz.batch = FieldValue;
                                break;
                            case "expiration_date":
                                try
                                {
                                    onekiz.expiration_date = DateTime.ParseExact(FieldValue, "yyyy-MM-dd", null);
                                    break;
                                }
                                catch (Exception e)
                                {
                                    break;
                                }
                                break;

                            case "pack3_id":
                                onekiz.pack3_id = FieldValue;
                                break;

                            case "gtin":
                                onekiz.gtin = FieldValue;
                                break;
                            case "sell_name":
                                onekiz.sell_name = FieldValue;
                                break;
                            case "sys_id":
                                onekiz.sys_id = FieldValue;
                                break;
                            case "prod_name":
                                onekiz.prod_name = FieldValue;
                                break;
                            case "full_prod_name":
                                onekiz.full_prod_name = FieldValue;
                                break;

                            case "source_type":
                                onekiz.source_type = FieldValue;
                                break;

                            case "federal_subject_name":
                                onekiz.federal_subject_name = FieldValue;
                                break;
                            case "last_tracing_op_date":
                                //onekiz.last_tracing_op_date = DateTime.Parse(FieldValue);
                                break;

                            case "gnvlp":
                                onekiz.gnvlp = FieldValue;
                                break;

                            case "verified":
                                onekiz.verified = FieldValue;
                                break;

                            case "total_cost":
                                onekiz.total_cost = FieldValue;
                                break;
                            case "apteka_mdlp":
                                onekiz.apteka_mdlp = FieldValue;
                                break;

                            //Часть для заполнения данными по ефарме         
                            case "cheque":
                                onekiz.cheque = FieldValue;
                                break;
                            case "internal_barcode":
                                onekiz.internal_barcode = FieldValue;
                                break;
                            case "apteka":
                                onekiz.apteka = FieldValue;
                                break;

                            case "date_cheque":
                                onekiz.date_cheque = FieldValue;
                                break;



                        }
                    }
                    
                }

                KizList.Add(onekiz);

            }


        }
    }
}
