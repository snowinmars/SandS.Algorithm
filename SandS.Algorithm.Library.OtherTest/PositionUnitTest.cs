using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.PositionNamespace;
using System;
using Xunit;

namespace SandS.Algorithm.Library.OtherTest
{
    public class PositionUnitTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(10, 15)]
        [InlineData(-10, -15)]
        public void PositionCtorMustWork(float x, float y)
        {
            Position pos0 = new Position();
            Position pos1 = new Position(x, y);
            Position pos2 = new Position((int)x, (int)y);
            Position pos3 = new Position(new Point((int)x, (int)y));
            Position pos4 = new Position(new Vector2(x, y));
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(1, 1, -1, -1, 0, 0)]
        [InlineData(10, 15, -2, 20, 8, 35)]
        [InlineData(-10, -15, 20, 30, 10, 15)]
        public void PositionOperatorPlusMustWork(int lx, int ly, int rx, int ry, int ex, int ey)
        {
            Position rhs = new Position(rx, ry);
            Position lhs = new Position(lx, ly);
            Position expected = new Position(ex, ey);
            Position actual = rhs + lhs;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 0, 0)]
        [InlineData(0, 0, 1, 1, -1, -1)]
        [InlineData(1, 1, -1, -1, 2, 2)]
        [InlineData(10, 15, -2, 20, 12, -5)]
        [InlineData(-10, -15, 20, 30, -30, -45)]
        public void PositionOperatorMinusMustWork(int lx, int ly, int rx, int ry, int ex, int ey)
        {
            Position rhs = new Position(rx, ry);
            Position lhs = new Position(lx, ly);
            Position expected = new Position(ex, ey);
            Position actual = lhs - rhs;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 1)]
        [InlineData(0, 0, 1, 0, 0)]
        [InlineData(1, 1, -1, -1, -1)]
        [InlineData(10, 15, 4, 40, 60)]
        [InlineData(10, 15, -7, -70, -105)]
        public void PositionOperatorMultipleMustWork(int lx, int ly, int number, int ex, int ey)
        {
            Position vector = new Position(lx, ly);
            Position expected = new Position(ex, ey);
            Position actual = vector * number;

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
        public void PositionOperatorUnaryMinusMustWork(int x, int y)
        {
            Position actual = -new Position(x, y);
            Position expected = new Position(-x, -y);

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
        public void PositionOperatorUnaryPlusMustWork(int x, int y)
        {
            Position actual = +new Position(x, y);
            Position expected = new Position(+x, +y);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(1, 1, 2)]
        [InlineData(3, 4, 25)]
        [InlineData(3, 3, 18)]
        public void PositionGetLengthMustWork(int x, int y, int expectedSquare)
        {
            Position pos = new Position(x, y);
            double expected = Math.Sqrt(expectedSquare);
            double length = pos.GetLegnth();

            Assert.True(Math.Abs(expected - length) < 0.0001);
        }
    }
}