using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bigint = SandS.Algorithm.Library.BigInt.BigInt;

namespace SandS.Algorithm.Library.BigInt
{
    internal static class BigIntMathHelper
    {
        internal static int GetBlocksCount(bigint input)
        {
            int result = 0;
            bigint current = input;

            while ((object)current != null)
            {
                result++;

                current = current.PreviousBlock;
            }

            return result;
        }
    }
}
