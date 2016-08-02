using SandS.Algorithm.Common;
using SandS.Algorithm.Extensions.StringBuilderExtension;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SandS.Algorithm.Library.Generator
{
    public class TextGenerator
    {
        private char commaMark;

        private char dotMark;

        private char exclamationMark;

        private char questionMark;

        private char spaceMark;

        private char threeDotsMark;

        public TextGenerator Clone()
        {
            TextGenerator gen = new TextGenerator
            {
                commaMark = this.commaMark,
                CommaMark = this.CommaMark,
                CommaSentenceLength = this.CommaSentenceLength,
                dotMark = this.dotMark,
                DotMark = this.DotMark,
                exclamationMark = this.exclamationMark,
                ExclamationMark = this.ExclamationMark,
                IsUsingCommas = this.IsUsingCommas,
                IsUsingDots = this.IsUsingDots,
                IsUsingExclamationMarks = this.IsUsingExclamationMarks,
                IsUsingQuestionMarks = this.IsUsingQuestionMarks,
                IsUsingThreeDotsMark = this.IsUsingThreeDotsMark,
                questionMark = this.questionMark,
                QuestionMark = this.QuestionMark,
                SentenceLength = this.SentenceLength,
                spaceMark = this.spaceMark,
                SpaceMark = this.SpaceMark,
                threeDotsMark = this.threeDotsMark,
                ThreeDotsMark = this.ThreeDotsMark,
                WordMaxLength = this.WordMaxLength,
                WordMinLength = this.WordMinLength,
                IsFirstLetterAlwaysUpper = this.IsFirstLetterAlwaysUpper,
            };

            foreach (var item in this.Marks)
            {
                gen.Marks.Add(item);
            }

            return gen;
        }

        public TextGenerator()
        {
            this.Marks = new HashSet<char>();

            this.WordMaxLength = 12;
            this.WordMinLength = 3;
            this.SentenceLength = 12;
            this.CommaSentenceLength = 4;

            this.IsUsingThreeDotsMark = false;
            this.IsUsingDots = true;
            this.IsUsingCommas = true;
            this.IsUsingExclamationMarks = true;
            this.IsUsingQuestionMarks = true;
            this.IsFirstLetterAlwaysUpper = false;

            this.SpaceMark = ' ';
            this.DotMark = '.';
            this.CommaMark = ',';
            this.ExclamationMark = '!';
            this.QuestionMark = '?';
            this.ThreeDotsMark = '…';
        }

        public char CommaMark
        {
            get
            {
                return this.commaMark;
            }
            set
            {
                this.Marks.Remove(this.commaMark);
                this.commaMark = value;
                this.Marks.Add(value);
            }
        }

        public int CommaSentenceLength { get; set; }

        #region marks

        public char ThreeDotsMark
        {
            get
            {
                return this.threeDotsMark;
            }
            set
            {
                this.Marks.Remove(this.threeDotsMark);
                this.threeDotsMark = value;
                this.Marks.Add(value);
            }
        }

        public char DotMark
        {
            get
            {
                return this.dotMark;
            }
            set
            {
                this.Marks.Remove(this.dotMark);
                this.dotMark = value;
                this.Marks.Add(value);
            }
        }

        public char ExclamationMark
        {
            get
            {
                return this.exclamationMark;
            }
            set
            {
                this.Marks.Remove(this.exclamationMark);
                this.exclamationMark = value;
                this.Marks.Add(value);
            }
        }

        public bool IsUsingThreeDotsMark { get; set; }
        public bool IsUsingCommas { get; set; }
        public bool IsUsingDots { get; set; }
        public bool IsUsingExclamationMarks { get; set; }
        public bool IsUsingQuestionMarks { get; set; }
        public HashSet<char> Marks { get; }

        public char QuestionMark
        {
            get
            {
                return this.questionMark;
            }
            set
            {
                this.Marks.Remove(this.questionMark);
                this.questionMark = value;
                this.Marks.Add(value);
            }
        }

        public int SentenceLength { get; set; }

        public char SpaceMark
        {
            get
            {
                return this.spaceMark;
            }
            set
            {
                this.Marks.Remove(this.spaceMark);
                this.spaceMark = value;
                this.Marks.Add(value);
            }
        }

        #endregion marks

        public bool IsFirstLetterAlwaysUpper { get; set; }

        public int WordMaxLength { get; set; }
        public int WordMinLength { get; set; }

        public string GetNewWord(int wordMinLength, int wordMaxLength, bool isFirstLerretUp = false)
        {
            // I think, you have to create new StringBuilder due to way of StringBuilder's .ToString()
            StringBuilder sb = new StringBuilder(wordMaxLength);
            int wordLength = CommonValues.Random.Next(wordMinLength, wordMaxLength);

            for (int j = 0; j < wordLength; j++)
            {
                sb.Append(Convert.ToChar(CommonValues.Random.Next(97, 122))); // english symbols codes
            }

            if ((IsFirstLetterAlwaysUpper) || (isFirstLerretUp))
            {
                sb[0] = Char.ToUpper(sb[0], CultureInfo.CurrentCulture);
            }

            return sb.ToString();
        }

        public IEnumerable<string> GetWords(int count)
        {
            bool wasSentenceEnd = true;

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder(WordMaxLength);

                sb.Append(this.GetNewWord(this.WordMinLength, this.WordMaxLength));

                if ((IsFirstLetterAlwaysUpper) || (wasSentenceEnd))
                {
                    sb[0] = Char.ToUpper(sb[0]);
                    wasSentenceEnd = false;
                }

                if (this.IsUsingCommas)
                {
                    if ((CommonValues.Random.Next(0, this.CommaSentenceLength) == this.CommaSentenceLength - 1))
                    {
                        sb.Append(this.CommaMark);
                    }
                }

                if ((!wasSentenceEnd) &&
                    (this.IsUsingDots) &&
                    (!this.Marks.Contains(sb[sb.Length - 2])))
                {
                    wasSentenceEnd = AppendOnRandom(sb, this.DotMark);
                }

                if ((!wasSentenceEnd) &&
                    (this.IsUsingExclamationMarks) &&
                    (!this.Marks.Contains(sb[sb.Length - 2])))
                {
                    wasSentenceEnd = AppendOnRandom(sb, this.ExclamationMark);
                }

                if ((!wasSentenceEnd) &&
                    (this.IsUsingQuestionMarks) &&
                    (!this.Marks.Contains(sb[sb.Length - 2])))
                {
                    wasSentenceEnd = AppendOnRandom(sb, this.QuestionMark);
                }

                if ((!wasSentenceEnd) &&
                    (this.IsUsingThreeDotsMark) &&
                    (!this.Marks.Contains(sb[sb.Length - 2])))
                {
                    wasSentenceEnd = AppendOnRandom(sb, this.ThreeDotsMark);
                }

                // dot on the end of text
                if ((i == count - 1) &&
                    (this.IsUsingDots))
                {
                    sb.Trim(saveFirst: false, saveLast: false);

                    if (this.Marks.Contains(sb[sb.Length - 1]))
                    {
                        sb[sb.Length - 1] = this.DotMark;
                    }
                    else
                    {
                        sb.Append(this.DotMark);
                    }
                }

                sb.Append(this.SpaceMark);
                sb.Trim(saveFirst: false, saveLast: true);
                yield return sb.ToString();
            }
        }

        private bool AppendOnRandom(StringBuilder sb, char symbol)
        {
            if (!this.Marks.Contains(sb[sb.Length - 2]) &&
                (CommonValues.Random.Next(0, this.SentenceLength) == this.SentenceLength - 1) &&
                (sb.Length > 4))
            {
                if (this.Marks.Contains(sb[sb.Length - 2]))
                {
                    sb[sb.Length - 2] = symbol;
                }
                else
                {
                    sb[sb.Length - 1] = symbol;
                }

                sb.Append(this.SpaceMark);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}