using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using bigint = SandS.Algorithm.Library.BigInt.BigInt;

namespace SandS.Algorithm.Library.BigIntTest
{
    public class CalcMethods
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(12, 12, 0)]
        [InlineData(654231, 987, 653244)]
        [InlineData(65421574231, 213451235, 65208122996)]
        [InlineData(18446744073709551615, 18446744073709551615, 0)]
        public void OperatorMinusMustWork(uint l, uint r, uint res)
        {
            bigint lhs = new bigint(l);
            bigint rhs = new bigint(r);
            bigint result = new bigint(res);

            Assert.Equal<bigint>(result, lhs - rhs);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(123, 123, 246)]
        [InlineData(9875, 622210, 632085)]
        [InlineData(123456789123, 987654321987, 1111111111110)]
        [InlineData(123456789123, 13982164348, 137438953471)]
        [InlineData(4045432065982464, 458167561388031, 4503599627370495)]
        public void OperatorMultiplicativePlusMustWork(uint l, uint r, uint result)
        {
            bigint lhs = new bigint(l);
            bigint rhs = new bigint(r);
            bigint res = new bigint(result);

            Assert.Equal<bigint>(res, lhs + rhs);
        }

        [Theory]
        [InlineData(45, 7, 3)]
        //[InlineData(12589995, 2, 1)]
        //[InlineData(12589994, 2, 0)]
        [InlineData(123456789123, 987654, 39123)]
        [InlineData(987654321987, 123456789123, 9003)]
        public void OperatorMultiplicativeReminderMustWork(uint l, uint r, uint result)
        {
            bigint lhs = new bigint(l);
            bigint rhs = new bigint(r);
            bigint res = new bigint(result);

            Assert.Equal<bigint>(res, lhs % rhs);
        }
    }
}
