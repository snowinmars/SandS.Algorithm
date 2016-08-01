using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Extensions.StringBuilderExtension
{
    public static class StringBuilderExtension
    {
        public static void Trim(this StringBuilder sb, bool saveFirst, bool saveLast)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("Stringbuilder is null");
            }

            for (int i = 0; i < sb.Length - 1; i++)
            {
                if (saveFirst &&
                    (sb[i] == ' ') &&
                    (sb[i + 1] != ' '))
                {
                    break;
                }

                if (sb[i] == ' ')
                {
                    sb.Remove(i, 1);
                }
            }

            for (int i = sb.Length - 1; i > 1; i--)
            {
                if (saveLast &&
                    (sb[i] == ' ') &&
                    (sb[i - 1] != ' '))
                {
                    break;
                }

                if (sb[i] == ' ')
                {
                    sb.Remove(i, 1);
                }
            }
        }
    }
}
