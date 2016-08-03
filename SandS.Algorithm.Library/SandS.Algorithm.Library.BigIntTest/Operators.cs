using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using bigint = SandS.Algorithm.Library.BigInt.BigInt;

namespace SandS.Algorithm.Library.BigIntTest
{
    public class Operators
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(12, 12)]
        [InlineData(156, 874)]
        [InlineData(321, 99984)]
        [InlineData(0, 123456)]
        [InlineData(654231, 987)]
        [InlineData(695451, 6512)]
        [InlineData(18446744073709551615, 0)]
        [InlineData(18446744073709551615, 12355121578451)]
        [InlineData(18446744073709551615, 18446744073709551615)]
        public void OperatorEquallyMustWork(uint l, uint r)
        {
            bigint lhs = bigint.Parse(l);
            bigint rhs = bigint.Parse(r);

            Assert.Equal(l == r, lhs == rhs);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(12, 12)]
        [InlineData(156, 874)]
        [InlineData(321, 99984)]
        [InlineData(0, 123456)]
        [InlineData(654231, 987)]
        [InlineData(695451, 6512)]
        [InlineData(123456789123, 4045432065982464)]
        [InlineData(4045432065982464, 123456789123)]
        [InlineData(4045432065982464, 4045432065982464)]
        public void OperatorGreaterMustWork(uint l, uint r)
        {
            bigint lhs = bigint.Parse(l);
            bigint rhs = bigint.Parse(r);

            Assert.Equal(l > r, lhs > rhs);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(12, 12)]
        [InlineData(156, 874)]
        [InlineData(321, 99984)]
        [InlineData(0, 123456)]
        [InlineData(654231, 987)]
        [InlineData(695451, 6512)]
        [InlineData(123456789123, 4045432065982464)]
        [InlineData(4045432065982464, 123456789123)]
        [InlineData(4045432065982464, 4045432065982464)]
        public void OperatorGreaterOrEquallMustWork(uint l, uint r)
        {
            bigint lhs = bigint.Parse(l);
            bigint rhs = bigint.Parse(r);

            Assert.Equal(l >= r, lhs >= rhs);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(12, 12)]
        [InlineData(156, 874)]
        [InlineData(321, 99984)]
        [InlineData(0, 123456)]
        [InlineData(654231, 987)]
        [InlineData(695451, 6512)]
        [InlineData(123456789123, 4045432065982464)]
        [InlineData(4045432065982464, 123456789123)]
        [InlineData(4045432065982464, 4045432065982464)]
        public void OperatorLessMustWork(uint l, uint r)
        {
            bigint lhs = bigint.Parse(l);
            bigint rhs = bigint.Parse(r);

            Assert.Equal(l < r, lhs < rhs);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(12, 12)]
        [InlineData(156, 874)]
        [InlineData(321, 99984)]
        [InlineData(0, 123456)]
        [InlineData(654231, 987)]
        [InlineData(695451, 6512)]
        [InlineData(123456789123, 4045432065982464)]
        [InlineData(4045432065982464, 123456789123)]
        [InlineData(4045432065982464, 4045432065982464)]
        public void OperatorLessOrEquallMustWork(uint l, uint r)
        {
            bigint lhs = bigint.Parse(l);
            bigint rhs = bigint.Parse(r);

            Assert.Equal(l <= r, lhs <= rhs);
        }
    }
}
