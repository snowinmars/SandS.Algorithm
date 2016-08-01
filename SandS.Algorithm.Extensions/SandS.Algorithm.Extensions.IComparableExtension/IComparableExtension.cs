using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Extensions.IComparableExtension
{
    public static class IComparableExtension
    {
        public static bool Between<T>(this T number, T bound1, T bound2)
            where T : IComparable<T>
        {
            if (bound1.CompareTo(bound2) < 0)
            {
                return number.CompareTo(bound1) >= 0 && number.CompareTo(bound2) <= 0;
            }
            else
            {
                return number.CompareTo(bound2) >= 0 && number.CompareTo(bound1) <= 0;
            }
        }
    }
}
