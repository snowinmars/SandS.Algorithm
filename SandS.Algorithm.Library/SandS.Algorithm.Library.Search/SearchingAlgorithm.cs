using SandS.Algorithm.Library.Sort;
using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.Search
{
    public class SearchingAlgorithm
    {
        #region Public Methods

        public static int Binary<T>(IList<T> list, T sreachingItem, bool isPresorted = false)
            where T : IComparable
        {
            if ((!isPresorted) && (!SearchingAlgorithm.IsArraySorted(list)))
            {
                list = SortingAlgorithm.MergeSort(list);
            }

            return SearchingAlgorithm.BinarySearch(list, sreachingItem);
        }

        #endregion Public Methods

        #region Private Methods

        private static int BinarySearch<T>(IList<T> list, T itemToSearch)
            where T : IComparable
        {
            int lhs = 0;
            int rhs = list.Count;

            while (lhs < rhs)
            {
                int mid;
                checked
                {
                    mid = (lhs + rhs) / 2;
                }

                if (list[mid].CompareTo(itemToSearch) == 0)
                {
                    return mid;
                }

                if (list[mid].CompareTo(itemToSearch) < 0)
                {
                    rhs = mid;
                }
                else
                {
                    lhs = mid + 1;
                }
            }

            return -1;
        }

        private static bool IsArraySorted<T>(IList<T> arr)
            where T : IComparable
        {
            return SearchingAlgorithm.IsArraySortedByAcending(arr) || SearchingAlgorithm.IsArraySortedByDecending(arr);
        }

        private static bool IsArraySortedByAcending<T>(IList<T> arr)
            where T : IComparable
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsArraySortedByDecending<T>(IList<T> arr)
            where T : IComparable
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i].CompareTo(arr[i + 1]) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion Private Methods
    }
}