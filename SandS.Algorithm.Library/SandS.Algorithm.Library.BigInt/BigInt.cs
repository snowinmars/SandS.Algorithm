using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.Bitwise;
using bigint = SandS.Algorithm.Library.BigInt.BigInt;

namespace SandS.Algorithm.Library.BigInt
{
    public class BigInt
    {
        public bigint PreviousBlock;
        public uint Value;

        public static bigint One { get; } = new bigint(1);
        public static bigint Zero { get; } = new bigint(0);

        #region ctor

        public BigInt(bigint b)
        {
            this.Value = b.Value;
            this.PreviousBlock = b.PreviousBlock;
        }

        public BigInt(uint v)
        {
            this.Value = v;
        }

        public BigInt()
        {
        }

        #endregion ctor

        #region operators

        #region unary

        public static bigint operator --(bigint lhs)
            => BigIntMath.Subtract(lhs, bigint.One);

        public static bigint operator ++(bigint lhs)
            => BigIntMath.Add(lhs, bigint.One);

        #endregion unary

        #region binary

        public static bigint operator -(bigint lhs, bigint rhs)
            => BigIntMath.Subtract(lhs, rhs);

        public static bigint operator -(uint lhs, bigint rhs)
            => BigIntMath.Subtract(new bigint(lhs), rhs);

        public static bigint operator -(bigint lhs, uint rhs)
            => BigIntMath.Subtract(lhs, new bigint(rhs));


        public static bigint operator %(bigint lhs, bigint rhs)
            => BigIntMath.Reminder(lhs, rhs);

        public static bigint operator %(uint lhs, bigint rhs)
            => BigIntMath.Reminder(new bigint(lhs), rhs);

        public static bigint operator %(bigint lhs, uint rhs)
            => BigIntMath.Reminder(lhs, new bigint(rhs));


        public static bigint operator *(bigint lhs, bigint rhs)
            => BigIntMath.Multiple(lhs, rhs);

        public static bigint operator *(uint lhs, bigint rhs)
            => BigIntMath.Multiple(new bigint(lhs), rhs);

        public static bigint operator *(bigint lhs, uint rhs)
            => BigIntMath.Multiple(lhs, new bigint(rhs));


        public static bigint operator /(bigint lhs, bigint rhs)
            => BigIntMath.Divide(lhs, rhs);

        public static bigint operator /(uint lhs, bigint rhs)
            => BigIntMath.Divide(new bigint(lhs), rhs);

        public static bigint operator /(bigint lhs, uint rhs)
            => BigIntMath.Divide(lhs, new bigint(rhs));


        public static bigint operator +(bigint lhs, bigint rhs)
            => BigIntMath.Add(lhs, rhs);

        public static bigint operator +(uint lhs, bigint rhs)
            => BigIntMath.Add(new bigint(lhs), rhs);

        public static bigint operator +(bigint lhs, uint rhs)
            => BigIntMath.Add(lhs, new bigint(rhs));

        #endregion binary

        #region eq

        public static bool operator !=(bigint lhs, bigint rhs)
            => !(lhs == rhs);

        public static bool operator !=(uint lhs, bigint rhs)
            => !(lhs == rhs);

        public static bool operator !=(bigint lhs, uint rhs)
            => !(lhs == rhs);


        public static bool operator <(bigint lhs, bigint rhs)
        {
            if ((object)lhs == null)
            {
                return false;
            }

            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator <(uint lhs, bigint rhs)
            => new bigint(lhs) < rhs;

        public static bool operator <(bigint lhs, uint rhs)
            => lhs < new bigint(rhs);


        public static bool operator <=(bigint lhs, bigint rhs)
            => lhs == rhs || lhs < rhs;

        public static bool operator <=(uint lhs, bigint rhs)
            => lhs == rhs || lhs < rhs;

        public static bool operator <=(bigint lhs, uint rhs)
            => lhs == rhs || lhs < rhs;


        public static bool operator ==(bigint lhs, bigint rhs)
        {
            object olhs = lhs as object;
            object orhs = rhs as object;

            if ((olhs == null) && (orhs == null))
            {
                return true;
            }

            if ((olhs == null) ^ (orhs == null))
            {
                return false;
            }

            return lhs.CompareTo(rhs) == 0;
        }

        public static bool operator ==(uint lhs, bigint rhs)
            => new bigint(lhs) == rhs;

        public static bool operator ==(bigint lhs, uint rhs)
            => lhs == new bigint(rhs);


        public static bool operator >(bigint lhs, bigint rhs)
        {
            if ((object)lhs == null)
            {
                return false;
            }

            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator >(uint lhs, bigint rhs)
            => new bigint(lhs) > rhs;

        public static bool operator >(bigint lhs, uint rhs)
            => lhs > new bigint(rhs);


        public static bool operator >=(bigint lhs, bigint rhs)
            => lhs == rhs || lhs > rhs;

        public static bool operator >=(uint lhs, bigint rhs)
            => lhs == rhs || lhs > rhs;

        public static bool operator >=(bigint lhs, uint rhs)
            => lhs == rhs || lhs > rhs;


        public int CompareTo(object obj)
        {
            bigint b = obj as bigint;

            if (b == null)
            {
                return 1;
            }

            return this.CompareTo(b);
        }

        public int CompareTo(bigint input)
        {
            if ((object)input == null)
            {
                return 1;
            }

            bigint thiscopy = this;

            //BigIntMathHelper.TrimStructure(ref thiscopy);
            //BigIntMathHelper.TrimStructure(ref input); TO REALIZE

            int lhsBlockCount = BigIntMathHelper.GetBlocksCount(this);
            int rhsBlockCount = BigIntMathHelper.GetBlocksCount(input);

            if (lhsBlockCount < rhsBlockCount)
            {
                return -1;
            }
            else if (lhsBlockCount > rhsBlockCount)
            {
                return 1;
            }

            bigint lhscopy = this/*.DeepClone()*/;
            bigint rhscopy = input/*.DeepClone()*/; /*TO REALIZE*/

            bigint lhscopyParent = lhscopy;
            bigint rhscopyParent = rhscopy;

            bigint tmp = new bigint();

            if (lhsBlockCount != 1)
            {
                while (lhscopy.PreviousBlock.PreviousBlock != null)
                {
                    lhscopy = lhscopy.PreviousBlock;
                    rhscopy = rhscopy.PreviousBlock;
                }

                if (lhscopy.PreviousBlock.Value > rhscopy.PreviousBlock.Value)
                {
                    return 1;
                }

                if (lhscopy.PreviousBlock.Value < rhscopy.PreviousBlock.Value)
                {
                    return -1;
                }

                lhscopy.PreviousBlock = null;
                rhscopy.PreviousBlock = null;

                return lhscopyParent.CompareTo(rhscopyParent);
            }

            if (lhscopy.Value > rhscopy.Value)
            {
                return 1;
            }

            if (lhscopy.Value < rhscopy.Value)
            {
                return -1;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            bigint b = obj as bigint;

            if ((object) b == null)
            {
                return false;
            }

            return this == b;
        }

        public bool Equals(bigint obj)
        {
            if ((object)obj == null)
            {
                return false;
            }

            return this == obj;
        }

        public override int GetHashCode()
        {
            bigint tmp = this;

            int result = 0;
            while (tmp != null)
            {
                result += (int)tmp.Value;

                tmp = tmp.PreviousBlock;
            }

            return result;
        }

        #endregion eq

        #endregion operators

        public bigint DeepClone()
        {
            bigint tmp = this;
            bigint result = new bigint();
            bigint current = result;

            while (tmp != null)
            {
                current.Value = tmp.Value;

                tmp = tmp.PreviousBlock;

                if (tmp != null)
                {
                    current.PreviousBlock = new bigint();
                    current = current.PreviousBlock;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(32);

            bigint current = this;

            while (current != null)
            {
                int count = 0;
                byte a = 0;

                sb.Append("[ ");

                foreach (var item in BitwiseOperation.GetNextBit(current.Value).Reverse())
                {
                    sb.Append(item ? '1' : '0');

                    if (a == 3)
                    {
                        sb.Append(' ');
                        a = 0;
                    }
                    else
                    {
                        a++;
                    }
                    count++;
                }

                while (count < 32)
                {
                    sb.Append('0');

                    if (a == 3)
                    {
                        sb.Append(' ');
                        a = 0;
                    }
                    else
                    {
                        a++;
                    }

                    count++;
                }

                sb.Append("] ");
                current = current.PreviousBlock;
            }

            return sb.ToString();
        }
    }
}
