using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.PositionNamespace;
using Xunit;

namespace SandS.Algorithm.Library.OtherTest
{
    public class PositionUnitTest
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(10, 15)]
        [InlineData(-10, -15)]
        public void PositionCtorMustWork(float x, float y)
        {
            Position pos0 = new Position();
            Position pos1 = new Position(x,y);
            Position pos2 = new Position((int)x, (int)y);
            Position pos3 = new Position(new Point((int)x, (int)y));
            Position pos4 = new Position(new Vector2(x,y));
        }

        [Theory]
        [InlineData(0,0,0,0,0,0)]
        [InlineData(1, 1, 1, 1, 2, 2)]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(1,1,-1,-1,0,0)]
        [InlineData(10,15,-2,20,8,35)]
        [InlineData(-10, -15, 20, 30, 10, 15)]
        public void PositionOperatorPlusMustWork(int lx, int ly, int rx, int ry, int ex, int ey)
        {
            Position rhs = new Position(rx, ry);
            Position lhs = new Position(lx, ly);
            Position expected = new Position(ex, ey);

            Assert.Equal(expected, rhs + lhs);
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
            Position actual = rhs - lhs;

            Assert.Equal(expected, actual);
        }
    }
}
