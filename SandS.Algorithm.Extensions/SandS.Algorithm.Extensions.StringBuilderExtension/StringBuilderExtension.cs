using System;
using System.Text;

namespace SandS.Algorithm.Extensions.StringBuilderExtensionNamespace
{
    public static class StringBuilderExtension
    {
        public static void Trim(this StringBuilder sb, bool saveFirstSpace, bool saveLastSpace)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("Stringbuilder is null");
            }

            for (int i = 0; i < sb.Length - 1; i++)
            {
                if (saveFirstSpace &&
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
                if (saveLastSpace &&
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