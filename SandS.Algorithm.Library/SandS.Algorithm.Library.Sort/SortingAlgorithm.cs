using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Extensions.EnumerableExtensionNamespace;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.SortNamespace
{
    public static class SortingAlgorithm
    {
        public static void Bogosort<T>(ref IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            while (!SortingAlgorithm.IsArraySorted(source))
            {
                source = source.Shuffle(CommonValues.Random).ToList();
            }
        }

        public static void BubbleSort<T>(IList<T> source)
                where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            for (int i = 0; i < source.Count; ++i)
            {
                for (int j = 0; j < source.Count - i - 1; j++)
                {
                    if (source[j].CompareTo(source[j + 1]) > 0)
                    {
                        T tmp = source[j];
                        source[j] = source[j + 1];
                        source[j + 1] = tmp;
                    }
                }
            }
        }

        public static void InsertSort<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            SortingAlgorithm.InsertSort(source, 0, source.Count);
        }

        public static IList<T> MergeSort<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            if (source.Count == 1)
            {
                return source;
            }

            int cap = source.Count / 2;

            IList<T> lhsArray = new List<T>(cap);

            for (int i = 0; i < source.Count / 2; i++)
            {
                lhsArray.Add(source[i]);
            }

            cap = source.Count % 2 == 0 ? source.Count / 2 : source.Count / 2 + 1;

            IList<T> rhsArray = new List<T>(cap);

            for (int i = 0; i < cap; i++)
            {
                rhsArray.Add(source[(source.Count / 2) + i]);
            }

            lhsArray = SortingAlgorithm.MergeSort(lhsArray).ToList();
            rhsArray = SortingAlgorithm.MergeSort(rhsArray).ToList();

            return SortingAlgorithm.Merge(lhsArray, rhsArray);
        }

        public static void PancakeSort<T>(IList<T> source, int cutoffValue = 2)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<InvalidOperationException>(cutoffValue >= 0, "Cutoff value must be non-negative");

            if (source.Count < cutoffValue)
            {
                return;
            }

            for (int i = source.Count - 1; i >= 0; --i)
            {
                int pos = i;
                // Find position of max number between beginning and i
                for (int j = 0; j < i - 1; j++)
                {
                    if (source[j].CompareTo(source[pos]) > 0)
                    {
                        pos = j;
                    }
                }

                // is it in the correct position already?
                if (pos == i)
                {
                    continue;
                }

                // is it at the beginning of the array? If not flip array section so it is
                if (pos != 0)
                {
                    SortingAlgorithm.Flip(source, pos + 1);
                }

                // Flip array section to get max number to correct position
                SortingAlgorithm.Flip(source, i + 1);
            }
        }

        public static void QuickSort<T>(IList<T> source, uint cutoffValue = 9)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<InvalidOperationException>(cutoffValue >= 0, "Cutoff value must be non-negative");

            if (cutoffValue <= 0)
            {
                throw new ArgumentException("Cutoff value must be greater that zero");
            }

            SortingAlgorithm.QuickSort(source, 0, source.Count - 1);
            SortingAlgorithm.InsertSort(source);
        }

        private static void Flip<T>(IList<T> source, int n)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            for (int i = 0; i < n; i++)
            {
                --n;
                T tmp = source[i];
                source[i] = source[n];
                source[n] = tmp;
            }
        }

        private static void InsertSort<T>(IList<T> source, int left, int right)
                where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<InvalidOperationException>(left >= 0, "Left must be non-negative");
            Contract.Requires<InvalidOperationException>(right >= 0, "Right must be non-negative");

            int i = 0;
            int j = 0;

            for (i = left + 1; i < right; i++)
            {
                for (j = i; j > 0; j--)
                {
                    if (source[j - 1].CompareTo(source[j]) < 0)
                    {
                        break;
                    }

                    T tmp = source[j - 1];
                    source[j - 1] = source[j];
                    source[j] = tmp;
                }
            }
        }

        public static bool IsArraySorted<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            return SortingAlgorithm.IsArraySortedByAcending(source) || SortingAlgorithm.IsArraySortedByDecending(source);
        }

        private static bool IsArraySortedByAcending<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            for (int i = 0; i < source.Count - 1; i++)
            {
                if (source[i].CompareTo(source[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsArraySortedByDecending<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            for (int i = 0; i < source.Count - 1; i++)
            {
                if (source[i].CompareTo(source[i + 1]) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static IList<T> Merge<T>(IList<T> lhsArray, IList<T> rhsArray)
                        where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(lhsArray != null, "Left-hand sequence is null");
            Contract.Requires<ArgumentNullException>(rhsArray != null, "Right-hand sequence is null");

            int rhs = 0;
            int lhs = 0;
            List<T> merged = new List<T>(lhsArray.Count + rhsArray.Count);

            for (int i = 0; i < merged.Capacity; i++)
            {
                if (rhs > rhsArray.Count - 1)
                {
                    merged.Add(lhsArray[lhs]);
                    lhs++;
                    continue;
                }

                if (lhs > lhsArray.Count - 1)
                {
                    merged.Add(rhsArray[rhs]);
                    rhs++;
                    continue;
                }

                if (lhsArray[lhs].CompareTo(rhsArray[rhs]) > 0)
                {
                    merged.Add(rhsArray[rhs]);
                    rhs++;
                }
                else
                {
                    merged.Add(lhsArray[lhs]);
                    lhs++;
                }
            }

            return merged;
        }

        public static void SelectionSort<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            for (int i = 0; i < source.Count - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < source.Count; j++)
                {
                    if (source[j].CompareTo(source[min]) < 0)
                    {
                        min = j;
                    }
                }

                T tmp = source[i];
                source[i] = source[min];
                source[min] = tmp;
            }
        }

        private static void QuickSort<T>(IList<T> source, int left, int right, uint parallelChunkSize = 1000, uint minChunkSize = 10)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<InvalidOperationException>(left >= 0, "Left must be non-negative");
            Contract.Requires<InvalidOperationException>(right >= 0, "Right must be non-negative");
            Contract.Requires<InvalidOperationException>(parallelChunkSize >= 0, "Parallel chunk size must be non-negative");
            Contract.Requires<InvalidOperationException>(minChunkSize >= 0, "Minimum chunk size must be non-negative");

            if (left >= right)
            {
                return;
            }

            if (right - left <= minChunkSize)
            {
                SortingAlgorithm.InsertSort(source, left, right);
            }

            int medianIndex = SortingAlgorithm.GetMedian(left, right, left - (left + right) / 2);
            int i = left;
            int j = right;
            int n = right;
            T temp;
            T pivot = source[medianIndex];

            while (j <= n)
            {
                if (source[j].CompareTo(pivot) == -1)
                {
                    temp = source[i];
                    source[i] = source[j];
                    source[j] = temp;
                    i++;
                    j++;
                }
                else if (source[j].CompareTo(pivot) == 1)
                {
                    temp = source[j];
                    source[j] = source[n];
                    source[n] = temp;
                    n--;
                }
                else
                {
                    j++;
                }
            }

            if (right - left > parallelChunkSize)
            {
                Parallel.Invoke(() => SortingAlgorithm.QuickSort(source, left, i), () => SortingAlgorithm.QuickSort(source, j, right));
            }
            else
            {
                SortingAlgorithm.QuickSort(source, left, i);
                SortingAlgorithm.QuickSort(source, j, right);
            }
        }

        private static int GetMedian(int val1, int val2, int val3)
        {
            if (val1 > val2)
            {
                if (val2 > val3)
                {
                    return val2;
                }

                if (val1 > val3)
                {
                    return val3;
                }

                return val1;
            }

            if (val1 > val3)
            {
                return val1;
            }

            if (val2 > val3)
            {
                return val3;
            }

            return val2;
        }
    }
}