using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MDLPDocumentsLib;

namespace Doc552ByGTIN
{


    /// <summary>
    /// Расширение класса списков для деления 
    /// на чанки 
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">Список произвольного типа </param>
        /// <param name="chunkSize">размер чанка. Например если число элементов 18 а размер чанка 5, то результатом будет списки 5/5/5/3</param>
        /// <returns>список списков разбитый на чнки размером chunkSize</returns>
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                Console.WriteLine("Нужен файл с GTIN ами для списания");
                return;
            }

            if (!File.Exists(args[0].ToString()) )
            {
                Console.WriteLine("Нет такого файла - нужно проверить что там ");
                return;
            }


            List<string> withdrawlCodes = File.ReadAllLines(args[0].ToString()).ToList();

            string g = Guid.NewGuid().ToString();

            if (!File.Exists("mdlpCodeFromDatabase.txt"))
            {
                Console.WriteLine("Нужен файл с кодом места деятельности mdlpCodeFromDatabase.txt");
                return; 
            }
            string mdlpCodeFromDatabase = File.ReadAllText("mdlpCodeFromDatabase.txt");
            
            
            // выгрузка документов списания в файлы
            string filename="";
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            int chunkCounter = 0;
            List<List<string>> strings = withdrawlCodes.ChunkBy(10);
            foreach (List<string> wc in strings)
            {
                chunkCounter++;
                filename = Path.Combine(executablePath, "552", "doc_552_" + chunkCounter.ToString() + "_" + g + ".xml");
                MDLPDocumentsLib.MDLPDoc552 doc522 = new MDLPDocumentsLib.MDLPDoc552(wc, MDLPDocumentsLib.MDLPDoc552.withdrawal_type.СписаниеБезУничт, mdlpCodeFromDatabase);
                doc522.XmlDoc.Save(filename);
            }

        }
    }
}
