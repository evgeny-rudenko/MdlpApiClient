using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIZCintrol
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
}
