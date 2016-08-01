using System;
using System.Collections.Generic;
using System.Linq;
using SandS.Algorithm.Common;
using SandS.Algorithm.Extensions.IListExtension;
using SandS.Algorithm.Library.Sort;
using Xunit;

namespace SandS.Algorithm.Library.SortTest
{
    public class SortingAlgorithmUnitTest
    {
        #region Public Methods

        [Fact]
        public void IsArraySortedByBogosort()
        {
            const int count = 10;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.Bogosort<int>(ref array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedByBubbleSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.BubbleSort<int>(array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedByInsertSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.InsertSort<int>(array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedByMergeSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);

            array = SortingAlgorithm.MergeSort<int>(array).ToList();

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedByPancakeSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.PancakeSort<int>(array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedByQuickBubbleSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.QuickBubbleSort<int>(array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedByQuickSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.QuickSort<int>(array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        [Fact]
        public void IsArraySortedBySelectionSort()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            SortingAlgorithm.SelectionSort<int>(array);

            Assert.Equal(true, SortingAlgorithmUnitTest.IsArraySorted<int>(array));
        }

        #endregion Public Methods

        #region Private Methods

        private static bool IsArraySorted<T>(IList<T> arr)
            where T : IComparable
        {
            return SortingAlgorithmUnitTest.IsArraySortedByAcending(arr) || SortingAlgorithmUnitTest.IsArraySortedByDecending(arr);
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
