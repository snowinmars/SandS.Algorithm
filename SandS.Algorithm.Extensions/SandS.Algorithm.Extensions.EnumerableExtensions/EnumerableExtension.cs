using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace SandS.Algorithm.Extensions.EnumerableExtensionNamespace
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }

            yield return elements[0];
        }

        public static bool SequenceEqualWithoutOrder<T>(this IEnumerable<T> source, IEnumerable<T> sequence)
            where T : IComparable<T>
        {
            return source.OrderBy(x => x).SequenceEqual(sequence.OrderBy(x => x));
        }

        public static T IfDefaultGiveMe<T>(this T value, T alternate)
            where T : struct
        {
            return (value.Equals(default(T)) ? alternate : value);
        }

        public static T FirstOrDefault_AndIfDefaultGiveMe<T>(this IEnumerable<T> collection, T alternate)
            where T : class
        {
            var value = collection.FirstOrDefault();

            return (object.ReferenceEquals(value, default(T)) ? alternate : value);
        }

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

        public static IEnumerable<TOut> ForEach<TIn, TOut>(this IEnumerable<TIn> input, Func<TIn, TOut> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException($"Function is null, param name is {nameof(func)}");
            }

            return input.Select(func.Invoke);
        }
    }
}