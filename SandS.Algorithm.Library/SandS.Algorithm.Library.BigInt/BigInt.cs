using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.Bitwise;

namespace SandS.Algorithm.Library.BigInt
{
    public class BigInt
    {
        public BigInt PreviousBlock;
        public uint Value;

        public static BigInt One { get; } = new BigInt(1);
        public static BigInt Zero { get; } = new BigInt(0);

        #region ctor

        public BigInt(BigInt b)
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

        public static BigInt operator --(BigInt lhs)
            => BigIntMath.Subtract(lhs, BigInt.One);

        public static BigInt operator ++(BigInt lhs)
            => BigIntMath.Add(lhs, BigInt.One);

        #endregion unary

        #region binary

        public static BigInt operator -(BigInt lhs, BigInt rhs)
            => BigIntMath.Subtract(lhs, rhs);

        public static BigInt operator -(uint lhs, BigInt rhs)
            => BigIntMath.Subtract(new BigInt(lhs), rhs);

        public static BigInt operator -(BigInt lhs, uint rhs)
            => BigIntMath.Subtract(lhs, new BigInt(rhs));


        public static BigInt operator %(BigInt lhs, BigInt rhs)
            => BigIntMath.Reminder(lhs, rhs);

        public static BigInt operator %(uint lhs, BigInt rhs)
            => BigIntMath.Reminder(new BigInt(lhs), rhs);

        public static BigInt operator %(BigInt lhs, uint rhs)
            => BigIntMath.Reminder(lhs, new BigInt(rhs));


        public static BigInt operator *(BigInt lhs, BigInt rhs)
            => BigIntMath.Multiple(lhs, rhs);

        public static BigInt operator *(uint lhs, BigInt rhs)
            => BigIntMath.Multiple(new BigInt(lhs), rhs);

        public static BigInt operator *(BigInt lhs, uint rhs)
            => BigIntMath.Multiple(lhs, new BigInt(rhs));


        public static BigInt operator /(BigInt lhs, BigInt rhs)
            => BigIntMath.Divide(lhs, rhs);

        public static BigInt operator /(uint lhs, BigInt rhs)
            => BigIntMath.Divide(new BigInt(lhs), rhs);

        public static BigInt operator /(BigInt lhs, uint rhs)
            => BigIntMath.Divide(lhs, new BigInt(rhs));


        public static BigInt operator +(BigInt lhs, BigInt rhs)
            => BigIntMath.Add(lhs, rhs);

        public static BigInt operator +(uint lhs, BigInt rhs)
            => BigIntMath.Add(new BigInt(lhs), rhs);

        public static BigInt operator +(BigInt lhs, uint rhs)
            => BigIntMath.Add(lhs, new BigInt(rhs));

        #endregion binary

        #region eq

        public static bool operator !=(BigInt lhs, BigInt rhs)
            => !(lhs == rhs);

        public static bool operator !=(uint lhs, BigInt rhs)
            => !(lhs == rhs);

        public static bool operator !=(BigInt lhs, uint rhs)
            => !(lhs == rhs);


        public static bool operator <(BigInt lhs, BigInt rhs)
        {
            if ((object)lhs == null)
            {
                return false;
            }

            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator <(uint lhs, BigInt rhs)
            => new BigInt(lhs) < rhs;

        public static bool operator <(BigInt lhs, uint rhs)
            => lhs < new BigInt(rhs);


        public static bool operator <=(BigInt lhs, BigInt rhs)
            => lhs == rhs || lhs < rhs;

        public static bool operator <=(uint lhs, BigInt rhs)
            => lhs == rhs || lhs < rhs;

        public static bool operator <=(BigInt lhs, uint rhs)
            => lhs == rhs || lhs < rhs;


        public static bool operator ==(BigInt lhs, BigInt rhs)
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

        public static bool operator ==(uint lhs, BigInt rhs)
            => new BigInt(lhs) == rhs;

        public static bool operator ==(BigInt lhs, uint rhs)
            => lhs == new BigInt(rhs);


        public static bool operator >(BigInt lhs, BigInt rhs)
        {
            if ((object)lhs == null)
            {
                return false;
            }

            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator >(uint lhs, BigInt rhs)
            => new BigInt(lhs) > rhs;

        public static bool operator >(BigInt lhs, uint rhs)
            => lhs > new BigInt(rhs);


        public static bool operator >=(BigInt lhs, BigInt rhs)
            => lhs == rhs || lhs > rhs;

        public static bool operator >=(uint lhs, BigInt rhs)
            => lhs == rhs || lhs > rhs;

        public static bool operator >=(BigInt lhs, uint rhs)
            => lhs == rhs || lhs > rhs;


        public int CompareTo(object obj)
        {
            BigInt b = obj as BigInt;

            if (b == null)
            {
                return 1;
            }

            return this.CompareTo(b);
        }

        public int CompareTo(BigInt input)
        {
            if ((object)input == null)
            {
                return 1;
            }

            BigInt thiscopy = this;

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

            BigInt lhscopy = this/*.DeepClone()*/;
            BigInt rhscopy = input/*.DeepClone()*/; /*TO REALIZE*/

            BigInt lhscopyParent = lhscopy;
            BigInt rhscopyParent = rhscopy;

            BigInt tmp = new BigInt();

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
            BigInt b = obj as BigInt;

            if ((object) b == null)
            {
                return false;
            }

            return this == b;
        }

        public bool Equals(BigInt obj)
        {
            if ((object)obj == null)
            {
                return false;
            }

            return this == obj;
        }

        public override int GetHashCode()
        {
            BigInt tmp = this;

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

        public BigInt DeepClone()
        {
            BigInt tmp = this;
            BigInt result = new BigInt();
            BigInt current = result;

            while (tmp != null)
            {
                current.Value = tmp.Value;

                tmp = tmp.PreviousBlock;

                if (tmp != null)
                {
                    current.PreviousBlock = new BigInt();
                    current = current.PreviousBlock;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(32);

            BigInt current = this;

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
