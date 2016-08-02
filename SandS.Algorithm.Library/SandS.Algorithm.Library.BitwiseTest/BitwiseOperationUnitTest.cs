using System.Linq;
using SandS.Algorithm.Library.Bitwise;
using Xunit;

namespace SandS.Algorithm.Library.BitwiseOperationTest
{
    public class BitwiseOperationUnitTest
    {
        [Theory]
        [InlineData(0, new[] { false, })]
        [InlineData(1, new[] { true, })]
        [InlineData(2, new[] { true, false, })]
        [InlineData(7, new[] { true, true, true, })]
        [InlineData(15, new[] { true, true, true, true, })]
        [InlineData(16, new[] { true, false, false, false, false, })]
        [InlineData(511, new[] { true, true, true, true, true, true, true, true, true, })]
        [InlineData(512, new[] { true, false, false, false, false, false, false, false, false, false, })]
        [InlineData(513, new[] { true, false, false, false, false, false, false, false, false, true, })]
        [InlineData(200000001, new[] { true, false, true, true, true, true, true, false, true, false, true, true, true, true, false, false, false, false, true, false, false, false, false, false, false, false, false, true, })]
        [InlineData(4294967294, new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, })]
        [InlineData(4294967295, new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, })]
        public void GetNextBitMustWorkCorrectly(uint num, bool[] bits)
        {
            bool[] numbits = BitwiseOperation.GetNextBit(num).ToArray();

            Assert.Equal<bool[]>(bits, numbits);
        }

        [Theory]
        [InlineData(new[] { false, }, new[] { false, }, new[] { false, })]
        [InlineData(new[] { false, }, new[] { true, }, new[] { false, })]
        [InlineData(new[] { true, }, new[] { false, }, new[] { false, })]
        [InlineData(new[] { true, }, new[] { true, }, new[] { true, })]
        [InlineData(new[] { true, true, }, new[] { true, false, }, new[] { true, true, false, })]
        [InlineData(new[] { true, true, true, true, false, true, true, }, new[] { true, false, false, false, false, false, false, false, true, false, }, new[] { true, true, true, true, false, true, true, false, true, true, true, true, false, true, true, false, })]
        [InlineData(new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new[] { true, false, }, new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, })]
        [InlineData(new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new[] { true, true, }, new[] { true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true, })]
        public void BitArrayMultipleMustWorkCorrectly(bool[] lhs, bool[] rhs, bool[] result)
        {
            bool[] output = BitwiseOperation.BitArrayMultiple(lhs, rhs);

            Assert.Equal<bool[]>(result, output);
        }

        [Theory]
        [InlineData(new[] { false }, new[] { false }, new[] { false })]
        [InlineData(new[] { false }, new[] { true, }, new[] { true, })]
        [InlineData(new[] { true, }, new[] { false }, new[] { true, })]
        [InlineData(new[] { true, }, new[] { true, }, new[] { false })]
        [InlineData(new[] { true, true, false, false }, new[] { true, true, false, false }, new[] { true, false, false, false })]
        [InlineData(new[] { true, true, true, true, true, true, true, }, new[] { true, true, false, false, false, true, false }, new[] { true, true, false, false, false, false, true, })]

        public void BitArraySumMustWorkCorrectly(bool[] lhs, bool[] rhs, bool[] result)
        {
            bool[] output = BitwiseOperation.BitArraySum(lhs, rhs);

            Assert.Equal<bool[]>(result, output);
        }

        [Theory]
        [InlineData(new[] { false, }, new[] { false, }, new[] { false, })]
        [InlineData(new[] { true, }, new[] { false, }, new[] { true, })]
        [InlineData(new[] { true, }, new[] { true, }, new[] { false, })]
        [InlineData(new[] { true, true, false, false, }, new[] { true, true, false, }, new[] { true, true, false, })]
        [InlineData(new[] { true, false, false, false, false, false, false, true, }, new[] { true, false, false, false, true, }, new[] { true, true, true, false, false, false, false, })]
        [InlineData(new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new[] { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, }, new[] { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, })]
        public void BitArraySubtractMustWorkCorrectly(bool[] lhs, bool[] rhs, bool[] result)
        {
            bool[] output = BitwiseOperation.BitArraySubtract(lhs, rhs);

            Assert.Equal<bool[]>(result, output);
        }

        [Theory]
        [InlineData(new[] { false, }, new[] { false, }, 1)]
        [InlineData(new[] { true, }, new[] { false, }, 1)]
        [InlineData(new[] { true, true, }, new[] { true, }, 1)]
        [InlineData(new[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, }, 1)]
        [InlineData(new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, }, new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, 1)]
        [InlineData(new[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, }, 4)]
        [InlineData(new[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new[] { false, }, 31)]
        public void BitArrayRightShiftMustWorkCorrectly(bool[] num, bool[] bits, int shift)
        {
            bool[] output = BitwiseOperation.BitArrayRightShift(num, shift);

            Assert.Equal<bool[]>(bits, output);
        }

        [Theory]
        [InlineData(new[] { false, }, new[] { true, })]
        [InlineData(new[] { true, }, new[] { false, })]
        [InlineData(new[] { true, true, }, new[] { false, false, })]
        [InlineData(new[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new[] { false, false, true, false, true, false, false, false, true, false, false, true, true, false, false, true, false, true, true, true, false, true, false, false, false, true, false, false, true, false, false, })]
        [InlineData(new[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, }, new[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, })]
        public void InvertMustWorkCorrectly(bool[] num, bool[] bits)
        {
            bool[] output = BitwiseOperation.Invert(num);

            Assert.Equal<bool[]>(bits, output);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        [InlineData(9, false)]
        [InlineData(127, false)]
        [InlineData(217, false)]
        [InlineData(219, false)]
        [InlineData(12587495, false)]
        [InlineData(4294967296, true)]
        [InlineData(4294907296, false)]
        [InlineData(3221225472, false)]
        public void IsPowerOfTwoMustWorkCorrectly(ulong v, bool result)
        {
            Assert.Equal<bool>(result, BitwiseOperation.IsPowerOfTwo(v));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        [InlineData(4, 8)]
        [InlineData(7, 8)]
        [InlineData(8, 16)]
        [InlineData(9, 16)]
        [InlineData(127, 128)]
        [InlineData(217, 256)]
        [InlineData(219, 256)]
        [InlineData(12587495, 16777216)]
        [InlineData(1073741824, 2147483648)]
        [InlineData(1073701824, 1073741824)]
        public void NextPowerOfTwoMustWorkCorrectly(ulong num, ulong result)
        {
            Assert.Equal<ulong>(result, BitwiseOperation.NextPowerOfTwo(num));
        }

        [Theory]
        [InlineData(new[] { false, }, new[] { false, })]
        [InlineData(new[] { true, }, new[] { true,  })]
        [InlineData(new[] { true, false, }, new[] { true, false, })]
        [InlineData(new[] { true, true, true, true, false, false, false, }, new[] { false, false, false, true, false, false, false,  })]
        public void UnaryMinusMustWorkCorrectly(bool[] num, bool[] result)
        {
            bool[] output = BitwiseOperation.UnaryMinus(num);

            Assert.Equal<bool[]>(result, output);
        }
    }
}
