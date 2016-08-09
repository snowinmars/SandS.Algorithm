using System;
using System.Collections.Generic;
using System.Linq;

namespace SandS.Algorithm.Library.BitwiseNamespace
{
    public static class BitwiseOperation
    {
        /// <summary>
        /// Return number as a bit collection.
        /// Collection starts from top order bit.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>

        public static IEnumerable<bool> GetNextBit(ulong num)
        {
            return BitwiseOperation.GetBitsReversed(num).Reverse();
        }

        private static IEnumerable<bool> GetBitsReversed(ulong num)
        {
            if (num == 0)
            {
                yield return false;
            }

            while (num != 0)
            {
                yield return num % 2 == 0 ? false : true;
                num /= 2;
            }
        }

        /// <summary>
        /// Returns true if number is a power of two
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(ulong num)
            => num == 0 ? false : (num & (num - 1)) == 0;

        /// <summary>
        /// Create new number from bit stream
        /// </summary>
        /// <param name="bits">Input stream</param>
        /// <returns></returns>
        public static ulong BitsToNumber(bool[] bits)
        {
            if (bits == null)
            {
                return 0;
            }

            ulong div = 1;
            ulong result = 0;

            foreach (bool bit in bits)
            {
                if (bit)
                {
                    result += div;
                }

                div *= 2;
            }

            return result;
        }

        /// <summary>
        /// Compute next highest power of 2, e.g. for 114 it returns 128
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ulong NextPowerOfTwo(ulong v)
        {
            if (v == 0)
            {
                return 1;
            }

            if (BitwiseOperation.IsPowerOfTwo(v))
            {
                return v << 1;
            }

            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            v |= v >> 8;
            v |= v >> 16;
            v++;

            return v;
        }

        /// <summary>
        /// Returns new array as sum of two arrays without overflow.
        /// </summary>
        /// <param name="lhs">Left array must have the same length as right array</param>
        /// <param name="rhs">Right array must have the same length as left array</param>
        /// <returns>New array with same length as parents have</returns>
        public static bool[] Add(bool[] lhs, bool[] rhs)
        {
            bool bitOverflow = false;

            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException("Array is null");
            }

            if (lhs.Length != rhs.Length)
            {
                throw new ArgumentException("Arrays' lengths must be the same");
            }

            bool[] result = new bool[lhs.Length];

            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = lhs[i] ^ rhs[i] ^ bitOverflow;
                bitOverflow = (lhs[i] && rhs[i]) || (lhs[i] && bitOverflow) || (rhs[i] && bitOverflow);
            }

            return result;
        }

        /// <summary>
        /// Make -(array) in twos-complement
        /// </summary>
        /// <param name="array">Input array</param>
        /// <returns>New array with same length as parent has in twos-complement</returns>
        public static bool[] UnaryMinus(bool[] array)
        {
            bool[] one = new bool[array.Length];
            one[array.Length - 1] = true;

            return BitwiseOperation.Add(BitwiseOperation.Invert(array), one);
        }

        /// <summary>
        /// Invert (0 -> 1 and 1 -> 0) all bits in input array
        /// </summary>
        /// <param name="input"></param>
        /// <returns>New array with same length as parent has</returns>
        public static bool[] Invert(bool[] input)
        {
            bool[] result = new bool[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = !input[i];
            }

            return result;
        }

        /// <summary>
        /// Modifies result array as multiple of two input arrays without overflow
        /// Method uses Booth's multiplication algorithm
        /// </summary>
        /// <param name="m">Left array must have the same length as right array</param>
        /// <param name="r">Right array must have the same length as left array</param>
        /// <returns>New array with same length as parents have</returns>
        public static bool[] Multiply(bool[] m, bool[] r)
        {
            if ((m == null) || (r == null))
            {
                throw new ArgumentNullException("Array is null");
            }


            bool[] extendedM = new bool[m.Length + 1];
            bool[] extendedR = new bool[r.Length + 1];

            for (int i = 0; i < m.Length; i++)
            {
                extendedM[i + 1] = m[i];
            }

            for (int i = 0; i < r.Length; i++)
            {
                extendedR[i + 1] = r[i];
            }

            bool[] a = new bool[extendedM.Length + extendedR.Length + 1];
            bool[] s = new bool[extendedM.Length + extendedR.Length + 1];
            bool[] result = new bool[extendedM.Length + extendedR.Length + 1];
            bool[] actualResult = new bool[result.Length - 1];
            bool[] minusM = BitwiseOperation.UnaryMinus(extendedM);

            for (int i = 0; i < extendedM.Length; i++)
            {
                a[i] = extendedM[i];
                s[i] = minusM[i];
            }

            for (int i = 0; i < extendedR.Length; i++)
            {
                result[extendedM.Length + i] = extendedR[i];
            }

            result[result.Length - 1] = false;
            //00 -> no sum
            //11 -> no sum
            //01 -> result + a
            //10 -> result + s
            for (int i = 0; i < extendedR.Length; i++)
            {
                if (result[result.Length - 1])
                {
                    if (!result[result.Length - 2])
                    {
                        result = BitwiseOperation.Add(result, a);
                    }
                }
                else
                {
                    if (result[result.Length - 2])
                    {
                        result = BitwiseOperation.Add(result, s);
                    }
                }

                result = BitwiseOperation.ArithmeticRightShift(result, 1);
            }

            for (int i = 0; i < actualResult.Length; i++)
            {
                actualResult[i] = result[i];
            }

            return actualResult;
        }

        /// <summary>
        /// Right shift without overflow
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="shift"></param>
        /// <returns>New array with same length as parent has</returns>
        public static bool[] ArithmeticRightShift(bool[] arr, int shift)
        {
            bool[] result = new bool[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[0];
            }

            if (shift >= arr.Length)
            {
                return result;
            }
            
            for (int i = shift; i < arr.Length; i++)
            {
                result[i] = arr[i - shift];
            }

            return result;
        }

        /// <summary>
        /// Returns new array as difference of two arrays without overflow.
        /// </summary>
        /// <param name="lhs">Left array must have the same length as right array</param>
        /// <param name="rhs">Right array must have the same length as left array</param>
        /// <returns>New array with same length as parents have</returns>
        public static bool[] Subtract(bool[] lhs, bool[] rhs)
        {
            rhs = BitwiseOperation.UnaryMinus(rhs);

            return BitwiseOperation.Add(lhs, rhs);
        }
    }
}