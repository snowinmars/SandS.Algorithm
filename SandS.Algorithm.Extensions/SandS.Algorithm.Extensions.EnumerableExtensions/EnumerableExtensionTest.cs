using System;
using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Extensions.EnumerableExtensionNamespace;
using SandS.Algorithm.Extensions.IListExtensionNamespace;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace SandS.Algorithm.Extensions.EnumerableExtension
{
    public class EnumerableExtensionTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(10000)]
        public void ShuffleMustWork(int count)
        {
            IList<int> arr = new List<int>(count);

            arr.FillWithRandomElements(-100, 100, count, CommonValues.Random.Next);

            IList<int> result = arr.Shuffle(CommonValues.Random).ToList();

            Assert.False(object.ReferenceEquals(arr, result));
            Assert.Equal(arr.Count, result.Count());
            Assert.True(arr.SequenceEqualWithoutOrder(result));
        }

        [Fact]
        public void IfDefaultGiveMeMustWorkForClass()
        {
            var collection = new[] {"hello"};
            string word = collection.FirstOrDefault_AndIfDefaultGiveMe("another");

            Assert.Equal("hello", word);

            var anotherCollection = new string[0];
            string anotherWord = anotherCollection.FirstOrDefault_AndIfDefaultGiveMe("another");

            Assert.Equal("another", anotherWord);
        }

        [Fact]
        public void IfDefaultGiveMeMustWorkForStruct()
        {
            var collection = new[] { 1 };
            int word = collection.FirstOrDefault().IfDefaultGiveMe(2);

            Assert.Equal(1, word);

            var anotherCollection = new int[0];
            int anotherWord = anotherCollection.FirstOrDefault().IfDefaultGiveMe(2);

            Assert.Equal(2, anotherWord);
        }

        [Fact]
        public void FirstOrMustWorkForStruct()
        {
            var collection = new[] { 1 };
            int word = collection.FirstOr(2);

            Assert.Equal(1, word);

            var anotherCollection = new int[0];
            int anotherWord = anotherCollection.FirstOr(2);

            Assert.Equal(2, anotherWord);
        }

        [Fact]
        public void FirstOrMustWorkForClass()
        {
            var collection = new[] { "hello" };
            string word = collection.FirstOr("another");

            Assert.Equal("hello", word);

            var anotherCollection = new string[0];
            string anotherWord = anotherCollection.FirstOr("another");

            Assert.Equal("another", anotherWord);
        }

        [Fact]
        public void ForEachMustWork()
        {
            int[] array = {0, 1, 2, 3, 4, 5};
            int[] result = array.ForEach(i => i*i).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array[i] * array[i], result[i]);
            }

            Assert.Throws<ArgumentNullException>(() =>
            {
                int[] arr = {1, 2, 3};
                Func<int, int> p = null;

                arr.ForEach(p);
            });
        }
    }
}