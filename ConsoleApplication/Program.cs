using SandS.Algorithm.Library.PositionNamespace;

namespace ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int lx = 0;
            int ly = 0;
            int rx = 1;
            int ry = 1;
            int ex = -1;
            int ey = -1;
            Position rhs = new Position(rx, ry);
            Position lhs = new Position(lx, ly);
            Position expected = new Position(ex, ey);
            Position actual = rhs - lhs;
        }
    }
}