using System.Collections.Generic;

namespace SandS.Algorithm.Library.GeneratorNamespace
{
    public class PrimeGenerator
    {
        /// <summary>
        /// Linear sieve of Eratosthenes
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<long> GetFirst(long n)
        {
            IList<long> output = new List<long>(64);
            long[] lp = new long[n];

            for (int i = 2; i < n; i++)
            {
                if (lp[i] == 0)
                {
                    lp[i] = i;
                    output.Add(i);
                }

                for (int j = 0; j < output.Count; j++)
                {
                    if ((output[j] <= lp[i]) &&
                        (output[j] * i <= n - 1))
                    {
                        lp[output[j] * i] = output[j];
                    }
                }
            }

            return output;
        }
    }
}