using SandS.Algorithm.Library.SortNamespace;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace SandS.Algorithm.Library.SearchNamespace
{
    public class SearchingAlgorithm
    {
        #region Public Methods

        public static int Binary<T>(IList<T> source, T itemToSearch, bool isPresorted = false)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<ArgumentNullException>(itemToSearch != null, "Searching item is null");

            if (!isPresorted && 
                !SearchingAlgorithm.IsArraySorted(source))
            {
                source = SortingAlgorithm.MergeSort(source);
            }

            return SearchingAlgorithm.BinarySearch(source, itemToSearch);
        }

        #endregion Public Methods

        #region Private Methods

        private static int BinarySearch<T>(IList<T> source, T itemToSearch)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");
            Contract.Requires<ArgumentNullException>(itemToSearch != null, "Searching item is null");

            int lhs = 0;
            int rhs = source.Count;

            while (lhs < rhs)
            {
                int mid;
                checked
                {
                    mid = (lhs + rhs) / 2;
                }

                if (source[mid].CompareTo(itemToSearch) == 0)
                {
                    return mid;
                }

                if (source[mid].CompareTo(itemToSearch) > 0)
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

        private static bool IsArraySorted<T>(IList<T> source)
            where T : IComparable
        {
            Contract.Requires<ArgumentNullException>(source != null, "Source sequence is null");

            return SearchingAlgorithm.IsArraySortedByAcending(source) || SearchingAlgorithm.IsArraySortedByDecending(source);
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

        #endregion Private Methods
    }
}