using System;
using System.Collections.Generic;
using SandS.Algorithm.Common;
using SandS.Algorithm.Extensions.IListExtension;

namespace SandS.Algorithm.Library.SearchTest
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
