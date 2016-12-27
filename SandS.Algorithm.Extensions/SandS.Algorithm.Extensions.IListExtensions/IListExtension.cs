using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace SandS.Algorithm.Extensions.IListExtensionNamespace
{
    public static class IListExtensions
    {
        // TODO naming?
        public static void FillWithRandomElements<T>(this IList<T> source, T min, T max, int capacity, Func<T, T, T> funcToGetNewRandomElement)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<ArgumentNullException>(funcToGetNewRandomElement != null, "Function to get new ramndom element is null");

            // to array[i] = ...
            for (int i = 0; i < capacity; ++i)
            {
                source.Add(funcToGetNewRandomElement(min, max));
            }
        }

        /// <summary>
        /// print to console. I know, that it's bad, but I need it too often.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static void ShowOnConsole<T>(this IList<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            foreach (var item in source)
            {
                Console.WriteLine(item + "  ");
            }
        }
    }
}