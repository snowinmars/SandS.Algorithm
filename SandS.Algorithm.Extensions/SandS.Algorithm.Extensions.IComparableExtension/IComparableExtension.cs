using System;
using System.Diagnostics.Contracts;

namespace SandS.Algorithm.Extensions.IComparableExtensionNamespace
{
    public static class IComparableExtension
    {
        public static bool Between<T>(this T number, T lhs, T rhs)
            where T : IComparable<T>
        {
            Contract.Requires<ArgumentNullException>(number != null);
            Contract.Requires<ArgumentNullException>(lhs != null);
            Contract.Requires<ArgumentNullException>(rhs != null);

            if (lhs.CompareTo(rhs) < 0)
            {
                return number.CompareTo(lhs) >= 0 &&
                        number.CompareTo(rhs) <= 0;
            }

            return number.CompareTo(rhs) >= 0 &&
                    number.CompareTo(lhs) <= 0;
        }

        /// <summary>
        /// if this if more that cutoff, return cutoff, otherwise return this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static T CantBeMore<T>(this T value, T cutoff)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(cutoff != null);

            if (value.CompareTo(cutoff) > 0)
            {
                value = cutoff;
            }

            return value;
        }

        /// <summary>
        /// if this if less that cutoff, return cutoff, otherwise return this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cutoff"></param>
        /// <returns></returns>
        public static T CantBeLess<T>(this T value, T cutoff)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(value != null);
            Contract.Requires<ArgumentNullException>(cutoff != null);

            if (value.CompareTo(cutoff) < 0)
            {
                value = cutoff;
            }

            return value;
        }
    }
}