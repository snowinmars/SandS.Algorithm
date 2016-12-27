using Microsoft.Xna.Framework;
using System;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;
using SandS.Algorithm.CommonNamespace;

namespace SandS.Algorithm.Library.PositionNamespace
{
    public class PositionVector : IComparable, IComparable<PositionVector>, ICloneable
    {
        #region Public Constructors

        public PositionVector() : this(0, 0)
        {
        }

        public PositionVector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public PositionVector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public PositionVector(Point p) : this(p.X, p.Y)
        {
        }

        public PositionVector(Vector2 v) : this(v.X, v.Y)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public float X { get; set; }
        public float Y { get; set; }

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

        public static PositionVector operator +(PositionVector pos)
            => new PositionVector(+pos.X, +pos.Y);

        public static PositionVector operator -(PositionVector pos)
            => new PositionVector(-pos.X, -pos.Y);

        public static PositionVector operator +(PositionVector lhs, PositionVector rhs)
            => new PositionVector(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static PositionVector operator -(PositionVector lhs, PositionVector rhs)
            => new PositionVector(lhs.X - rhs.X, lhs.Y - rhs.Y);

        public static PositionVector operator *(PositionVector vector, int number)
            => new PositionVector(vector.X * number, vector.Y * number);

        public static PositionVector operator *(int number, PositionVector vector)
            => vector * number;

        public double GetLegnth()
        {
            float x = Math.Abs(this.X);
            float y = Math.Abs(this.Y);

            return Math.Sqrt(x * x + y * y);
        }

        public static bool operator >(PositionVector lhs, PositionVector rhs)
        {
            Contract.Requires<ArgumentNullException>(lhs != null, "Left-hand position is null");
            Contract.Requires<ArgumentNullException>(rhs != null, "Right-hand position is null");

            double ldiagonal = lhs.GetLegnth();
            double rdiagonal = rhs.GetLegnth();

            return ldiagonal > rdiagonal;
        }

        public static bool operator <(PositionVector lhs, PositionVector rhs)
        {
            Contract.Requires<ArgumentNullException>(lhs != null, "Left-hand position is null");
            Contract.Requires<ArgumentNullException>(rhs != null, "Right-hand position is null");

            double ldiagonal = lhs.GetLegnth();
            double rdiagonal = rhs.GetLegnth();

            return ldiagonal < rdiagonal;
        }

        public static bool operator >=(PositionVector lhs, PositionVector rhs)
            => lhs > rhs || lhs == rhs;

        public static bool operator <=(PositionVector lhs, PositionVector rhs)
            => lhs < rhs || lhs == rhs;

        #region Convert

        public Point ToPoint()
        {
            return new Point((int)this.X, (int)this.Y);
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

        public PositionVector Clone()
        {
            return new PositionVector(this.X, this.Y);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        #endregion Clone

        #region Equals

        public static bool operator !=(PositionVector lhs, PositionVector rhs)
            => !(lhs == rhs);

        public static bool operator ==(PositionVector lhs, PositionVector rhs)
        {
            return object.ReferenceEquals(lhs, null) && lhs.CompareTo(rhs) == 0;
        }

        public int CompareTo(object obj)
        {
            PositionVector pos = obj as PositionVector;

            return this.CompareTo(pos);
        }

        public int CompareTo(PositionVector pos)
        {
            if (object.ReferenceEquals(pos, null))
            {
                return -1;
            }

            if (Math.Abs(this.X - pos.X) < CommonValues.SmallValue &&
                Math.Abs(this.Y - pos.Y) < CommonValues.SmallValue)
            {
                return 0;
            }

            return (this > pos ? 1 : -1);
        }

        public override bool Equals(object obj)
        {
            PositionVector pos = obj as PositionVector;

            return this.Equals(pos);
        }

        public bool Equals(PositionVector pos)
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
                return (int)((this.X * 397) * 7 * this.Y);
            }
        }

        #endregion Equals
    }
}