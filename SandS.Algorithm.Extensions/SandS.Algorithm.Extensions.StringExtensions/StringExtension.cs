using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SandS.Algorithm.Extensions.StringExtension
{
    public static class StringExtensions
    {
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

        public static bool IsComprisesOnlyLatinOrOnlyCyrillicSymbols(this string str, char[] canContains = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            // See https://msdn.microsoft.com/en-us/library/ms972966.aspx for info about \P key

            //// return
            //// (
            ////	(
            ////		Regex.IsMatch(str, @"\P{IsCyrillic}") &&
            ////		Regex.IsMatch(str, @"\P{IsCyrillicSupplement}")
            ////	) ^
            ////	(
            ////		Regex.IsMatch(str, @"\P{IsBasicLatin}") &&
            ////		Regex.IsMatch(str, @"\P{IsLatin-1Supplement}") &&
            ////		Regex.IsMatch(str, @"\P{IsLatinExtended-A}") &&
            ////		Regex.IsMatch(str, @"\P{IsLatinExtended-B}") &&
            ////		Regex.IsMatch(str, @"\P{IsLatinExtendedAdditional}")
            ////	)
            //// )
            //// &&
            //// str.IsComprisesWithLetters();

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

            return
            (
               (
                   Regex.IsMatch(str, @"\P{IsCyrillic}") &&
                   Regex.IsMatch(str, @"\P{IsCyrillicSupplement}")
               ) ^
               (
                   Regex.IsMatch(str, @"\P{IsBasicLatin}") &&
                   Regex.IsMatch(str, @"\P{IsLatin-1Supplement}") &&
                   Regex.IsMatch(str, @"\P{IsLatinExtended-A}") &&
                   Regex.IsMatch(str, @"\P{IsLatinExtended-B}") &&
                   Regex.IsMatch(str, @"\P{IsLatinExtendedAdditional}")
               )
            )
            &&
            str.IsComprisesWithLetters();
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
