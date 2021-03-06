﻿using bigint = SandS.Algorithm.Library.BigIntNamespace.BigInt;

namespace SandS.Algorithm.Library.BigIntNamespace
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