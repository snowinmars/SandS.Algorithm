using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace SandS.Algorithm.Extensions.EnumerableExtensionNamespace
{
    public static class EnumerableExtension
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// Returns sequence of random elements from source.
        /// </summary>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            return source.Shuffle(EnumerableExtension.Random);
        }

        /// <summary>
        /// Returns sequence of random elements from source.
        /// </summary>
        /// <param name="rng">I need it due to I return random element of sequence. If you don't use this parameter, class will create it's own private static Random instance and will use it</param>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<ArgumentNullException>(rng != null, "Random generator is null");

            T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }

            yield return elements[0];
        }

        /// <summary>
        /// </summary>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        /// <returns></returns>
        public static bool SequenceEqualWithoutOrder<T>(this IEnumerable<T> source, IEnumerable<T> sequence)
            where T : IComparable<T>
        {
            Contract.Requires<ArgumentNullException>(source != null, "Left-hand side sequence is null");
            Contract.Requires<ArgumentNullException>(sequence != null, "Right-hand side sequence is null");

            return source.OrderBy(x => x).SequenceEqual(sequence.OrderBy(x => x));
        }

        /// <summary>
        /// If value doesn't euqal to default value of that type, this function will return it. If it's not, this will return alternate
        /// </summary>
        public static T IfDefaultGiveMe<T>(this T value, T alternate)
            where T : struct
        {
            return (value.Equals(default(T)) ? alternate : value);
        }

        /// <summary>
        /// If first item in this sequence is not null, this function will return it. If it's not, this will return alternate.
        /// </summary>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        public static T FirstOrDefault_AndIfDefaultGiveMe<T>(this IEnumerable<T> source, T alternate)
            where T : class
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            var value = source.FirstOrDefault();

            return (object.ReferenceEquals(value, default(T)) ? alternate : value);
        }

        /// <summary>
        /// If source have anything, function will return it. If not - function will returns alternate
        /// If source is null, returns alternate
        /// </summary>
        public static T FirstOr<T>(this IEnumerable<T> source, T alternate)
        {
            if (source != null)
            {
                foreach (T t in source)
                {
                    return t;
                }
            }

            return alternate;
        }

        /// <summary>
        /// Function enumerate input collection and invoke func on every item of the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        public static IEnumerable<TOut> ForEach<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> func)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<ArgumentNullException>(func != null, "Selector function is null");

            return source.Select(func.Invoke);
        }

        /// <summary>
        /// Function enumerate input collection and invoke func on every item of the collection
        /// </summary>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> func)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<ArgumentNullException>(func != null, "Selector function is null");

            if (func == null)
            {
                throw new ArgumentNullException(nameof(func), "Function is null");
            }

            foreach (T item in source)
            {
                func.Invoke(item);
                yield return item;
            }
        }

        /// <summary>
        /// This function do nothing with the collection, but it force IEnumerable to iterate
        /// </summary>
        /// <exception cref="ArgumentNullException">If any parameter is null</exception>
        public static void IterateEnumerator<T>(this IEnumerable<T> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            using (var en = source.GetEnumerator())
            {
                while (en.MoveNext()){}
            }
        }
    }
}