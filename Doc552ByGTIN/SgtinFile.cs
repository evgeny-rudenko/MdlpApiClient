using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc552ByGTIN
{
    
     internal   class SGTINMD
        {
            public string SGTIN;
            public string MD;
            public static SGTINMD FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(';');
                SGTINMD sgtinmd = new SGTINMD();
                sgtinmd.SGTIN = values[1];
                sgtinmd.MD = values[0];
                /*dailyValues.Date = Convert.ToDateTime(values[0]);
                dailyValues.Open = Convert.ToDecimal(values[1]);
                dailyValues.High = Convert.ToDecimal(values[2]);
                dailyValues.Low = Convert.ToDecimal(values[3]);
                dailyValues.Close = Convert.ToDecimal(values[4]);
                dailyValues.Volume = Convert.ToDecimal(values[5]);
                dailyValues.AdjClose = Convert.ToDecimal(values[6]);*/
                return sgtinmd;
            }
        }


    
}
