using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Extensions.EnumerableExtensionNamespace;
using SandS.Algorithm.Extensions.IListExtensionNamespace;
using System.Collections.Generic;
using System.Linq;
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
    }
}