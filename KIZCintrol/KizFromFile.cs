using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIZCintrol
{
    class Kiz
    {
        public string gtin;        //GTIN товара
        public string batch;       // номер серии
        public string sell_name;   // часть наименования товара 
        public string sgtin;       // SGTIN товара
        public string status;      // статус - на остатках или нет 
        public string pack3_id;    // АХЕЗ
        public string sys_id;      // предположительно - номер точки где числится КИЗ
        public DateTime last_tracing_op_date; // последняя дата операции с КИЗом 
        public string cheque;
        public string internal_barcode;
        // пример 
        // "18901148253527","B001641","Найз","18901148253527B2662MOJDA3DL","В обороте","","00000000173611","2022-02-12T00:13:23"
    }
    internal class KizFromFile
    {
        public string filename { get; set; }
        public string[] kizList { get; set; }
        public List<Kiz> kiz = new List<Kiz>();

        private string deleteQuotes (string strwithquotes)
        {
            strwithquotes = strwithquotes.Replace(@"""", "");
            strwithquotes = strwithquotes.Replace("\"", "");
            return strwithquotes;

        }
        public void  ReadKizData(string[] kizstr)
        {

            
            foreach (string s in kizstr)
            {
                //kiz = new List<Kiz>();
                string[] splitkiz = s.Split(',');
                if (splitkiz.Length <= 1)
                    continue;
                Kiz onekiz = new Kiz();
                onekiz.gtin = deleteQuotes( splitkiz[0]);
                onekiz.batch = deleteQuotes ( splitkiz[1]);
                onekiz.sell_name= deleteQuotes( splitkiz[2]);
                onekiz.sgtin = deleteQuotes( splitkiz[3]);
                onekiz.status =deleteQuotes( splitkiz[4]);
                onekiz.pack3_id = deleteQuotes( splitkiz[5]);
                onekiz.sys_id = deleteQuotes( splitkiz[6]);
                onekiz.last_tracing_op_date = DateTime.Parse(deleteQuotes( splitkiz[7]));
                onekiz.cheque = "";
                onekiz.internal_barcode="";
                kiz.Add(onekiz);
            }
            
        }

    }
}
