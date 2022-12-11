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

        public string sgtin;       // SGTIN товара
        public string status;       // в обороте или нет 
        public string withdrawal_type;	//2
        public string batch;       // номер серии
        public DateTime expiration_date; // последняя дата операции с КИЗом 
        public string pack3_id;     //	null АХЕЗ
        public string gtin;        //GTIN товара
        public string sell_name;   // часть наименования товара 
        public string sys_id;      // предположительно - номер точки где числится КИЗ
        public string prod_name;   // АМОКСИЦИЛЛИН
        public string full_prod_name; // полное наименование с дозировкой 
        public string source_type; // АХЕЗ
        public string federal_subject_name; //Регион таблетки
        public DateTime last_tracing_op_date; // последняя дата операции с КИЗом 
        public string gnvlp;       // признак ЖВ  true/false
        public string verified;     // АХЕЗ
        public string total_cost;   // затраты, но там нифига нет
        
        
        public string apteka_mdlp; //

        //Часть для заполнения данными по ефарме         
        public string cheque;
        public string internal_barcode;
        public string apteka;
        public string date_cheque;
        
        public void SetFieldValue (string FieldName , string FieldValue)
        {
            
            // Тут нужно сделать через Reflection , но не понял как
            switch (FieldName)
            {
                case "sgtin":
                    sgtin = FieldValue;
                    break;
                case "status":
                    status = FieldValue;
                    break;

                case "withdrawal_type":
                    withdrawal_type = FieldValue;
                    break;
                case "batch":
                    batch = FieldValue;
                    break;
                case "expiration_date":
                    //expiration_date = DateTime.Parse(FieldValue);
                    break;

                case "pack3_id":
                    pack3_id = FieldValue;
                    break;

                case "gtin":
                    gtin = FieldValue;
                    break;
                case "sell_name":
                    sell_name = FieldValue;
                    break;
                case "sys_id":
                    sys_id = FieldValue;
                    break;
                case "prod_name":
                    prod_name = FieldValue;
                    break;
                case "full_prod_name":
                    full_prod_name = FieldValue;
                    break;

                case "source_type":
                    source_type = FieldValue;
                    break;

                case "federal_subject_name":
                    federal_subject_name = FieldValue;
                    break;
                case "last_tracing_op_date":
                    //last_tracing_op_date = DateTime.Parse(FieldValue);
                    break;

                case "gnvlp":
                    gnvlp = FieldValue;
                    break;

                case "verified":
                    verified = FieldValue;
                    break;

                case "total_cost":
                    total_cost = FieldValue;
                    break;
                case "apteka_mdlp":
                    apteka_mdlp = FieldValue;
                    break;

                //Часть для заполнения данными по ефарме         
                case "cheque":
                    cheque = FieldValue;
                    break;
                case "internal_barcode":
                    internal_barcode = FieldValue;
                    break;
                case "apteka":
                    apteka = FieldValue;
                    break;

                case "date_cheque":
                    date_cheque = FieldValue;
                    break;

            

            }
        

        }

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
        private string deleteQuotes(string strwithquotes)
        {
            strwithquotes = strwithquotes.Replace(@"""", "");
            strwithquotes = strwithquotes.Replace("\"", "");
            return strwithquotes;

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

            
            string[] kizstr = File.ReadAllLines(filename,Encoding.GetEncoding(866)); // в других отчетах может быть UTF
            kizstr = kizstr.Skip(1).ToArray();

            string FieldName;
            foreach (string kizline in kizstr)
            {
                
                
                string[] splitkiz = kizline.Split(',');
                if (splitkiz.Length <= 1)
                    continue;
                Kiz onekiz = new Kiz();

                for (int i=0; i < splitkiz.Length; i++)
                {
                    FieldName = "";
                    if (fields.ContainsKey(i))
                    {
                        FieldName = fields[i];
                        onekiz.SetFieldValue(FieldName,deleteQuotes( splitkiz[i]));
                    }
                    
                }

                KizList.Add(onekiz);

            }


        }
    }
}
