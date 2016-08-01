using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SandS.Algorithm.Common;

namespace SandS.Algorithm.Library.Generator
{
    public class Isbn10Generator
    {
        private const string IsbnRegex = @"^ISBN(-1(?:0))?:?\x20(?=.{13}$)(?:[0-7]|8[0-9]|9[0-4]|9(?:[5-8][0-9]|9[0-3])|99[4-8][0-9]|999[0-9][0-9])-\d{1,7}-\d{1,7}-[\dX]$";

        public string Generate()
        {
            ISBN10 isbn = new ISBN10();

            int randLength = CommonValues.Random.Next(0, 5);

            switch (randLength)
            {
                case 0:
                    isbn.A = CommonValues.Random.Next(0, 7);
                    isbn.B = CommonValues.Random.Next(1000, 9999);
                    isbn.C = CommonValues.Random.Next(1000, 9999);
                    break;

                case 1:
                    isbn.A = CommonValues.Random.Next(80, 94);
                    isbn.B = CommonValues.Random.Next(100, 999);
                    isbn.C = CommonValues.Random.Next(1000, 9999);
                    break;

                case 2:
                    isbn.A = CommonValues.Random.Next(950, 993);
                    isbn.B = CommonValues.Random.Next(100, 999);
                    isbn.C = CommonValues.Random.Next(100, 999);
                    break;

                case 3:
                    isbn.A = CommonValues.Random.Next(9940, 9989);
                    isbn.B = CommonValues.Random.Next(10, 99);
                    isbn.C = CommonValues.Random.Next(100, 999);
                    break;

                case 4:
                    isbn.A = CommonValues.Random.Next(99900, 99999);
                    isbn.B = CommonValues.Random.Next(10, 99);
                    isbn.C = CommonValues.Random.Next(10, 99);
                    break;

                default:
                    break;
            }

            StringBuilder sb = new StringBuilder(32);
            sb.Append(isbn);

            // Remove "ISBN " word
            for (int i = 0; i < 5; i++)
            {
                sb[i] = ' ';
            }

            sb.Replace("-", "\x20").Replace(" ", string.Empty);
            int summ = 0;
            for (int i = 0; i < sb.Length - 1; i++)
            {
                summ += int.Parse(sb[i].ToString()) * (10 - i);
            }

            isbn.Control = summ % 11 == 0 ? 0 : 11 - (summ % 11);

            return isbn.ToString();
        }

        public bool ValidateIsbn(string isbn)
        {
            if (isbn == null)
            {
                return false;
            }

            if (!Regex.IsMatch(isbn, Isbn10Generator.IsbnRegex))
            {
                return false;
            }

            StringBuilder sb = new StringBuilder(32);
            sb.Append(isbn);

            // Remove "ISBN " word
            for (int i = 0; i < 5; i++)
            {
                sb[i] = ' ';
            }

            sb.Replace("-", "\x20").Replace(" ", string.Empty);

            int summ = 0;

            for (int i = 0; i < sb.Length; i++)
            {
                int digit = (sb[i] == 'x') || (sb[i] == 'X') ? 10 : int.Parse(sb[i].ToString());

                summ += digit * (10 - i);
            }

            return summ % 11 == 0;
        }
    }

    
}
