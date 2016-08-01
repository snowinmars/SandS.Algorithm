using SandS.Algorithm.Library.Generator;
using System;
using Xunit;

namespace SandS.Algorithm.Library.GeneratorTest
{
    public class PrimeGeneratorUnitTest
    {
        private readonly PrimeGenerator gen = new PrimeGenerator();
        private const int Count = 1000;
        private const int PrimeCount = 168;

        //private const int Count = 1000 * 1000; // yep, it works too, but too long
        //private const int PrimeCount = 78498;


        [Fact]
        public void AllPrimesArePrimes()
        {
            foreach (var item in this.gen.GetFirst(PrimeGeneratorUnitTest.Count))
            {
                for (int i = 2; i < item; i++)
                {
                    if (item % i == 0)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        [Fact]
        public void AllPrimesAreAll()
        {

            var primes = this.gen.GetFirst(PrimeGeneratorUnitTest.Count);

            Assert.Equal(PrimeCount, primes.Count);
        }
    }
}