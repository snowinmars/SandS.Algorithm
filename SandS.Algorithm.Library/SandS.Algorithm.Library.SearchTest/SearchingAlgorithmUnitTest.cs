using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Extensions.IListExtensionNamespace;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.SearchTestNamespace
{
    public class SearchingAlgorithmUnitTest
    {
        public void OverflowOfIndexsersTest()
        {
            const int count = 1000;
            IList<int> array = new List<int>(count);
            array.SetWithRandomElements(min: -10,
                    max: 10,
                    capacity: count,
                    funcToGetNewRandomElement: CommonValues.Random.Next);
        }
    }
}