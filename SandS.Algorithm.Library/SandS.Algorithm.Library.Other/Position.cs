using Microsoft.Xna.Framework;
using System;

namespace SandS.Algorithm.Library.PositionNamespace
{
    public class Position : IComparable, IComparable<Position>, ICloneable
    {
        #region Public Constructors

        public Position() : this(0, 0)
        {
        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(double x, double y)
        {
            this.X = (int)x;
            this.Y = (int)y;
        }

        public Position(Point p) : this(p.X, p.Y)
        {
        }

        public Position(Vector2 v) : this(v.X, v.Y)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public int X { get; set; }
        public int Y { get; set; }

        #endregion Public Properties

        public void SetZero()
        {
            this.X = 0;
            this.Y = 0;
        }

        public void SetOne()
        {
            this.X = 1;
            this.Y = 1;
        }

        public void SetUnitVertical()
        {
            this.X = 0;
            this.Y = 1;
        }

        public void SetUnitHorizontal()
        {
            this.X = 1;
            this.Y = 0;
        }

        public static Position operator +(Position pos)
            => new Position(+pos.X, +pos.Y);

        public static Position operator -(Position pos)
            => new Position(-pos.X, -pos.Y);

        public static Position operator +(Position lhs, Position rhs)
            => new Position(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static Position operator -(Position lhs, Position rhs)
            => new Position(lhs.X - rhs.X, lhs.Y - rhs.Y);

        public static Position operator *(Position vector, int number)
            => new Position(vector.X * number, vector.Y * number);

        public static Position operator *(int number, Position vector)
            => vector * number;

        public double GetLegnth()
        {
            int x = Math.Abs(this.X);
            int y = Math.Abs(this.Y);

            return Math.Sqrt(x * x + y * y);
        }

        public static bool operator >(Position lhs, Position rhs)
        {
            double ldiagonal = lhs.GetLegnth();
            double rdiagonal = rhs.GetLegnth();

            return ldiagonal > rdiagonal;
        }

        public static bool operator <(Position lhs, Position rhs)
        {
            double ldiagonal = lhs.GetLegnth();
            double rdiagonal = rhs.GetLegnth();

            return ldiagonal < rdiagonal;
        }

        public static bool operator >=(Position lhs, Position rhs)
            => lhs > rhs || lhs == rhs;

        public static bool operator <=(Position lhs, Position rhs)
            => lhs < rhs || lhs == rhs;

        #region Convert

        public Point ToPoint()
        {
            return new Point(this.X, this.Y);
        }

        public Vector2 ToVector2()
        {
            return new Vector2(this.X, this.Y);
        }

        #endregion Convert

        public override string ToString()
        {
            return $"X: {this.X}, Y: {this.Y}";
        }

        #region Clone

        public Position Clone()
        {
            return new Position(this.X, this.Y);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion Clone

        #region Equals

        public static bool operator !=(Position lhs, Position rhs)
            => !(lhs == rhs);

        public static bool operator ==(Position lhs, Position rhs)
        {
            return object.ReferenceEquals(lhs, null) && lhs.CompareTo(rhs) == 0;
        }

        public int CompareTo(object obj)
        {
            Position pos = obj as Position;

            return this.CompareTo(pos);
        }

        public int CompareTo(Position pos)
        {
            if (object.ReferenceEquals(pos, null))
            {
                return -1;
            }

            if (this.X == pos.X &&
                this.Y == pos.Y)
            {
                return 0;
            }

            return (this > pos ? 1 : -1);
        }

        public override bool Equals(object obj)
        {
            Position pos = obj as Position;

            return this.Equals(pos);
        }

        public bool Equals(Position pos)
        {
            if (object.ReferenceEquals(pos, null))
            {
                return false;
            }

            return this.CompareTo(pos) == 0;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.X * 397) ^ this.Y;
            }
        }

        #endregion Equals
    }
}