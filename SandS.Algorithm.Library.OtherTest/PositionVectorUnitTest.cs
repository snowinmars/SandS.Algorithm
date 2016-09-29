using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.PositionNamespace;
using System;
using Xunit;

namespace SandS.Algorithm.Library.OtherTest
{
    public class PositionVectorUnitTest
    {
        private static float small = 0.0001f;

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(10, 15)]
        [InlineData(-10, -15)]
        [InlineData(-1.85, 0)]
        [InlineData(0.001, -1)]
        [InlineData(10.2, 15.225)]
        [InlineData(-10.01, -15.155)]
        public void PositionVectorCtorMustWork(float x, float y)
        {
            PositionVector pos0 = new PositionVector();
            Assert.True(Math.Abs(pos0.X) < small);
            Assert.True(Math.Abs(pos0.Y) < small);

            PositionVector pos1 = new PositionVector(x, y);
            Assert.True(Math.Abs(pos1.X - x) < small);
            Assert.True(Math.Abs(pos1.Y - y) < small);

            PositionVector pos2 = new PositionVector((int)x, (int)y);
            Assert.True(pos2.X == (int)x);
            Assert.True(pos2.Y == (int)y);

            var point = new Point((int)x, (int)y);
            PositionVector pos3 = new PositionVector(point);
            Assert.True(pos3.X == point.X);
            Assert.True(pos3.Y == point.Y);

            var vector2 = new Vector2(x, y);
            PositionVector pos4 = new PositionVector(vector2);
            Assert.True(Math.Abs(pos4.X - vector2.X) < small);
            Assert.True(Math.Abs(pos4.Y - vector2.Y) < small);

        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(1, 1, -1, -1, 0, 0)]
        [InlineData(10, 15, -2, 20, 8, 35)]
        [InlineData(-10, -15, 20, 30, 10, 15)]
        public void PositionVectorOperatorPlusMustWork(int lx, int ly, int rx, int ry, int ex, int ey)
        {
            PositionVector rhs = new PositionVector(rx, ry);
            PositionVector lhs = new PositionVector(lx, ly);
            PositionVector expected = new PositionVector(ex, ey);
            PositionVector actual = rhs + lhs;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 0, 0)]
        [InlineData(0, 0, 1, 1, -1, -1)]
        [InlineData(1, 1, -1, -1, 2, 2)]
        [InlineData(10, 15, -2, 20, 12, -5)]
        [InlineData(-10, -15, 20, 30, -30, -45)]
        public void PositionVectorOperatorMinusMustWork(int lx, int ly, int rx, int ry, int ex, int ey)
        {
            PositionVector rhs = new PositionVector(rx, ry);
            PositionVector lhs = new PositionVector(lx, ly);
            PositionVector expected = new PositionVector(ex, ey);
            PositionVector actual = lhs - rhs;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(0, 0, 1, 0, 0)]
        [InlineData(1, 1, -1, -1, -1)]
        [InlineData(10, 15, 4, 40, 60)]
        [InlineData(10, 15, -7, -70, -105)]
        public void PositionVectorOperatorMultipleMustWork(int lx, int ly, int number, int ex, int ey)
        {
            PositionVector vector = new PositionVector(lx, ly);
            PositionVector expected = new PositionVector(ex, ey);
            PositionVector actual = vector * number;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        public void PositionVectorOperatorUnaryMinusMustWork(int x, int y)
        {
            PositionVector actual = -new PositionVector(x, y);
            PositionVector expected = new PositionVector(-x, -y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, -1)]
        public void PositionVectorOperatorUnaryPlusMustWork(int x, int y)
        {
            PositionVector actual = +new PositionVector(x, y);
            PositionVector expected = new PositionVector(+x, +y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(3, 4, 25)]
        [InlineData(3, 3, 18)]
        public void PositionVectorGetLengthMustWork(int x, int y, int expectedSquare)
        {
            PositionVector pos = new PositionVector(x, y);
            double expected = Math.Sqrt(expectedSquare);
            double length = pos.GetLegnth();

            Assert.True(Math.Abs(expected - length) < 0.0001);
        }
    }
}