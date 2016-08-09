using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit;
using bigint = SandS.Algorithm.Library.BigInt.BigInt;

namespace SandS.Algorithm.Library.BigIntTest
{
    public class OtherMethods
    {
        [Theory]
        [InlineData(0)]
        [InlineData(123)]
        [InlineData(9875)]
        [InlineData(123456789123)]
        [InlineData(4045432065982464)]
        public void MethodDeepCloneMustWork(uint v)
        {
            bigint num = new bigint(v);

            Assert.Equal<bigint>(num, num.DeepClone());
        }
    }
}
