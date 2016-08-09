using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Extensions.IListExtensionNamespace;
using SandS.Algorithm.Library.SortNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SandS.Algorithm.Library.SortTestNamespace
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
            var array2 = new List<int>(array);
            array2.Sort();
            SortingAlgorithm.BubbleSort<int>(array);

            Assert.True(array2.SequenceEqual(array));
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
        public void IsArraySortedByQuickSort()
        {
            const int count = 1000;

            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
            IEnumerable<int> array2 = new List<int>(array);

            array2 = array2.OrderBy(x => x).ToList();
            SortingAlgorithm.QuickSort<int>(array);

            Assert.True(array2.SequenceEqual(array));
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