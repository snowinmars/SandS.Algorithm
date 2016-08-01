using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Extensions.ArrayExtension
{
    public static class ArrayExtension
    {
        public static int[] Parse(this int[] arr, int number)
        {
            int[] output = new int[10];

            const int decade = 10;
            int i = 0;
            while (number > 1)
            {
                output[i] = number % decade;
                i++;
                number /= decade;
                //decade *= 10;
            }

            return output;
        }
    }
}
