using System;

namespace SandS.Algorithm.Extensions.IComparableExtensionNamespace
{
    public static class IComparableExtension
    {
        public static bool Between<T>(this T number, T bound1, T bound2)
            where T : IComparable<T>
        {
            if (bound1.CompareTo(bound2) < 0)
            {
                return number.CompareTo(bound1) >= 0 &&
                        number.CompareTo(bound2) <= 0;
            }

            return number.CompareTo(bound2) >= 0 &&
                    number.CompareTo(bound1) <= 0;
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
            if (value.CompareTo(cutoff) < 0)
            {
                value = cutoff;
            }

            return value;
        }
    }
}