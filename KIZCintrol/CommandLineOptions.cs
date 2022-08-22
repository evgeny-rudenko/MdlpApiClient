using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace KIZCintrol
{
    internal class Options
    {
       // [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        //public bool Verbose { get; set; }

        [Option('e', "exit", Required = false, Default =false, HelpText = "Выход из программы без анализа данных")]
        public bool ExitAfter { get; set; }

        [Option('w', "withdrawl", Required = false, Default =false, HelpText = "Списать таблетки.")]
        public bool Withdrawl { get; set; }
        
        [Option('f', "filter", Default ="%", Required = false,  HelpText ="Фильтр по названию таблетки")]
        public String Filter { get; set; }

        [Option('m',"mdlp", Default = "", Required = false, HelpText = "Название CSV файла из отчетов по остаткам МДЛП ")]
        public String MDLP { get; set; }

    }
}
