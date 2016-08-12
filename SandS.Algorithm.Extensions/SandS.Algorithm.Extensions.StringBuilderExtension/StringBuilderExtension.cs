using System;
using System.Text;

namespace SandS.Algorithm.Extensions.StringBuilderExtensionNamespace
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
                    sb.Remove(i, 1); // TODO
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