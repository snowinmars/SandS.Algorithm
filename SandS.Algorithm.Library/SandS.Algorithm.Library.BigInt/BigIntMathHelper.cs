using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.BigInt
{
    internal static class BigIntMathHelper
    {
        internal static int GetBlocksCount(BigInt input)
        {
            int result = 0;
            BigInt current = input;

            while ((object)current != null)
            {
                result++;

                current = current.PreviousBlock;
            }

            return result;
        }
    }
}
