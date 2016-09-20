using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SandS.Algorithm.Extensions.StringExtensionNamespace
{
    public static class StringExtensions
    {
        // Capitalize
        public static string FirstLetterToUpper(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "String is null");
            }

            if (!Char.IsLetter(str[0]))
            {
                return str;
            }

            StringBuilder sb = new StringBuilder(str.Length);
            sb.Append(str);
            sb[0] = Char.ToUpper(sb[0], CultureInfo.CurrentCulture);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="canContains">canContains is symbols, that string can contain besides latin or cyrillic.</param>
        /// <returns></returns>
        public static bool IsComprisesOnlyLatinOrOnlyCyrillicSymbols(this string str, char[] canContains = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            string tmp = null;
            StringBuilder sb = new StringBuilder(str.Length);
            sb.Append(str);

            if (canContains != null)
            {
                foreach (var item in canContains)
                {
                    sb.Replace(item.ToString(), string.Empty);
                }
            }

            tmp = sb.ToString();

            // See https://msdn.microsoft.com/en-us/library/ms972966.aspx for info about \P key
            return
            (
               (
                   Regex.IsMatch(tmp, @"\P{IsCyrillic}") &&
                   Regex.IsMatch(tmp, @"\P{IsCyrillicSupplement}")
               ) ^
               (
                   Regex.IsMatch(tmp, @"\P{IsBasicLatin}") &&
                   Regex.IsMatch(tmp, @"\P{IsLatin-1Supplement}") &&
                   Regex.IsMatch(tmp, @"\P{IsLatinExtended-A}") &&
                   Regex.IsMatch(tmp, @"\P{IsLatinExtended-B}") &&
                   Regex.IsMatch(tmp, @"\P{IsLatinExtendedAdditional}")
               )
            )
            &&
            tmp.IsComprisesWithLetters();
        }

        public static bool IsComprisesWithLetters(this string str)
        {
            if (str == null)
            {
                throw new ArgumentException("String is null");
            }

            return str.All(char.IsLetter);
        }

        public static bool IsFramedWith(this string str, string symbol)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return str.StartsWith(symbol, StringComparison.CurrentCulture) || str.EndsWith(symbol, StringComparison.CurrentCulture);
        }

        public static bool IsStartWithUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return char.IsUpper(str[0]);
        }
    }
}