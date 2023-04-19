using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MDLPGUIRemains2023.Utils
{
    interface ILoadAptekaCodes
    {
       
    }
    
    
    internal class AptekaCode:ILoadAptekaCodes
    {

        public Dictionary<string , string > aptekaDict = new Dictionary<string , string >();

        public AptekaCode()
        {
            aptekaDict = new Dictionary<string, string>();
            string filename = "apteki.csv";


            if (!File.Exists(filename))
            {
                return;
            }

            string[] aptekistr = File.ReadAllLines(filename); // в других отчетах может быть UTF
            foreach (string apteka in aptekistr)
            {
                string[] apteka_ = apteka.Split('|');
                aptekaDict.Add(apteka_[0].ToString() , apteka_[1].ToString());
            }

        }
    }
}
