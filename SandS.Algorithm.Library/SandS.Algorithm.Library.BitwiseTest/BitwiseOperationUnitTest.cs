using System.Linq;
using SandS.Algorithm.Library.Bitwise;
using Xunit;

namespace SandS.Algorithm.Library.BitwiseOperationTest
{
    public class BitwiseOperationUnitTest
    {
        [Theory]
        [InlineData(0, new bool[] { false, })]
        [InlineData(1, new bool[] { true, })]
        [InlineData(2, new bool[] { true, false, })]
        [InlineData(7, new bool[] { false, true, true, true, })]
        [InlineData(15, new bool[] { true, true, true, true, })]
        [InlineData(16, new bool[] { true, false, false, false, false, })]
        [InlineData(511, new bool[] { true, true, true, true, true, true, true, true, true, })]
        [InlineData(512, new bool[] { true, false, false, false, false, false, false, false, false, false, })]
        [InlineData(513, new bool[] { true, false, false, false, false, false, false, false, false, true, })]
        [InlineData(200000001, new bool[] { true, false, true, true, true, true, true, false, true, false, true, true, true, true, false, false, false, false, true, false, false, false, false, false, false, false, false, true, })]
        [InlineData(4294967294, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, })]
        [InlineData(4294967295, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, })]
        public void GetNextBitMustWorkCorrectly(uint num, bool[] bits)
        {
            bool[] numbits = BitwiseOperation.GetNextBit(num).ToArray();

            Assert.Equal<bool[]>(bits, numbits);
        }

        [Theory]
        [InlineData(new bool[] { false, }, new bool[] { false, }, new bool[] { false, })]
        [InlineData(new bool[] { false, }, new bool[] { true, }, new bool[] { false, })]
        [InlineData(new bool[] { true, }, new bool[] { false, }, new bool[] { true, })]
        [InlineData(new bool[] { true, }, new bool[] { true, }, new bool[] { true, })]
        [InlineData(new bool[] { true, true, }, new bool[] { true, false, }, new bool[] { true, true, false, })]
        [InlineData(new bool[] { true, true, true, true, false, true, true, }, new bool[] { true, false, false, false, false, false, false, false, true, false, }, new bool[] { true, true, true, true, false, true, true, false, true, true, true, true, false, true, true, false, })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new bool[] { true, false, }, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new bool[] { true, true, }, new bool[] { true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true, })]
        public void BitArrayMultipleMustWorkCorrectly(bool[] lhs, bool[] rhs, bool[] result)
        {
            bool[] output = BitwiseOperation.BitArrayMultiple(lhs, rhs);

            Assert.Equal<bool[]>(result, output);
        }

        [Theory]
        [InlineData(new bool[] { false }, new bool[] { false }, new bool[] { false })]
        [InlineData(new bool[] { false }, new bool[] { true, }, new bool[] { true, })]
        [InlineData(new bool[] { true, }, new bool[] { false }, new bool[] { true, })]
        [InlineData(new bool[] { true, }, new bool[] { true, }, new bool[] { true, false })]
        [InlineData(new bool[] { true, true, false, false }, new bool[] { true, true, false }, new bool[] { true, false, false, true, false })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, }, new bool[] { true, true, false, false, false, true, false }, new bool[] { true, true, true, false, false, false, false, true, })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new bool[] { true, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true, })]
        public void BitArraySumMustWorkCorrectly(bool[] lhs, bool[] rhs, bool[] result)
        {
            bool[] output = BitwiseOperation.BitArraySum(lhs, rhs);

            Assert.Equal<bool[]>(result, output);
        }

        [Theory]
        [InlineData(new bool[] { false, }, new bool[] { false, }, new bool[] { false, })]
        [InlineData(new bool[] { true, }, new bool[] { false, }, new bool[] { true, })]
        [InlineData(new bool[] { true, }, new bool[] { true, }, new bool[] { false, })]
        [InlineData(new bool[] { true, true, false, false, }, new bool[] { true, true, false, }, new bool[] { true, true, false, })]
        [InlineData(new bool[] { true, false, false, false, false, false, false, true, }, new bool[] { true, false, false, false, true, }, new bool[] { true, true, true, false, false, false, false, })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new bool[] { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, }, new bool[] { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, })]
        public void BitArraySubtractMustWorkCorrectly(bool[] lhs, bool[] rhs, bool[] result)
        {
            bool[] output = BitwiseOperation.BitArraySubtract(lhs, rhs);

            Assert.Equal<bool[]>(result, output);
        }

        [Theory]
        [InlineData(new bool[] { false, }, new bool[] { false, }, 1)]
        [InlineData(new bool[] { true, }, new bool[] { false, }, 1)]
        [InlineData(new bool[] { true, true, }, new bool[] { true, }, 1)]
        [InlineData(new bool[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new bool[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, }, 1)]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, }, new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, 1)]
        [InlineData(new bool[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new bool[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, }, 4)]
        [InlineData(new bool[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new bool[] { false, }, 31)]
        public void BitArrayRightShiftMustWorkCorrectly(bool[] num, bool[] bits, int shift)
        {
            bool[] output = BitwiseOperation.BitArrayRightShift(num, shift);

            Assert.Equal<bool[]>(bits, output);
        }

        [Theory]
        [InlineData(new bool[] { false, }, new bool[] { true, })]
        [InlineData(new bool[] { true, }, new bool[] { false, })]
        [InlineData(new bool[] { true, true, }, new bool[] { false, false, })]
        [InlineData(new bool[] { true, true, false, true, false, true, true, true, false, true, true, false, false, true, true, false, true, false, false, false, true, false, true, true, true, false, true, true, false, true, true, }, new bool[] { false, false, true, false, true, false, false, false, true, false, false, true, true, false, false, true, false, true, true, true, false, true, false, false, false, true, false, false, true, false, false, })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, }, new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, })]
        public void InvertMustWorkCorrectly(bool[] num, bool[] bits)
        {
            bool[] output = BitwiseOperation.Invert(num);

            Assert.Equal<bool[]>(bits, output);
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(7, false)]
        [InlineData(8, true)]
        [InlineData(9, false)]
        [InlineData(127, true)]
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
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        [InlineData(4, 8)]
        [InlineData(7, 8)]
        [InlineData(8, 16)]
        [InlineData(9, 16)]
        [InlineData(127, 128)]
        [InlineData(217, 512)]
        [InlineData(219, 512)]
        [InlineData(12587495, 16777216)]
        [InlineData(1073741824, 2147483648)]
        [InlineData(1073701824, 2147483648)]
        public void NextPowerOfTwoMustWorkCorrectly(ulong num, ulong result)
        {
            Assert.Equal<ulong>(result, BitwiseOperation.NextPowerOfTwo(num));
        }

        [Theory]
        [InlineData(new bool[] { false, }, new bool[] { false, })]
        [InlineData(new bool[] { true, }, new bool[] { true, true, true, true, })]
        [InlineData(new bool[] { true, false, }, new bool[] { true, true, true, false, })]
        [InlineData(new bool[] { true, true, true, true, false, false, false, }, new bool[] { true, false, false, false, true, false, false, false, })]
        [InlineData(new bool[] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, }, new bool[] { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, })]
        public void MustWorkCorrectly(bool[] num, bool[] result)
        {
            bool[] output = BitwiseOperation.UnaryMinus(num);

            Assert.Equal<bool[]>(result, output);
        }
    }
}
