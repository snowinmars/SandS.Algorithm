using SandS.Algorithm.CommonNamespace;
using System.Text;
using System.Text.RegularExpressions;

namespace SandS.Algorithm.Library.GeneratorNamespace
{
    public class IssnGenerator
    {
        internal const string IssnRegex = @"^ISSN\x20(?=.{9}$)\d{4}([- ])\d{3}(\d|X)$";

        public string Generate()
        {
            ISSN issn = new ISSN
            {
                A = CommonValues.Random.Next(1000, 9999),
                B = CommonValues.Random.Next(100, 999),
            };

            StringBuilder sb = new StringBuilder(32);
            sb.Append(issn);

            // Remove "ISSN " word
            for (int i = 0; i < 5; i++)
            {
                sb[i] = ' ';
            }

            sb.Replace("-", string.Empty).Replace(" ", string.Empty);

            int summ = 0;
            for (int i = 0; i < sb.Length - 1; i++)
            {
                summ += int.Parse(sb[i].ToString()) * (8 - i);
            }

            issn.Control = (summ % 11 == 0 ?
                                0 :
                                (11 - (summ % 11)));

            return issn.ToString();
        }

        public bool ValidateIssn(string issn)
        {
            if (issn == null)
            {
                return false;
            }

            if (!Regex.IsMatch(issn, IssnGenerator.IssnRegex))
            {
                return false;
            }

            StringBuilder sb = new StringBuilder(32);
            sb.Append(issn);

            // Remove "ISSN " word
            for (int i = 0; i < 5; i++)
            {
                sb[i] = ' ';
            }

            sb.Replace("-", string.Empty).Replace(" ", string.Empty);

            int summ = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                int digit = (sb[i] == 'x') || (sb[i] == 'X') ? 10 : int.Parse(sb[i].ToString());

                summ += digit * (8 - i);
            }

            return summ % 11 == 0;
        }
    }
}