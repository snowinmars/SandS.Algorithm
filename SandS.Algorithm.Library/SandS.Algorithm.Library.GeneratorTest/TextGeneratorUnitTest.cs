using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.Generator;
using Xunit;

namespace SandS.Algorithm.Library.GeneratorTest
{
    public class TextGeneratorUnitTest
    {
        private  readonly TextGenerator gen = new TextGenerator();

        #region getNewWord

        [Fact]
        public void GetNewWordFromTextGeneratorMustReturnWordWithoutSpaces()
        {
            string word = this.gen.GetNewWord(3, 12);
            Assert.Equal(false, word.Contains(this.gen.SpaceMark.ToString()));
        }

        [Fact]
        public void GetNewWordFromTextGeneratorWithFirstUpperLetterMustReturnItProperly()
        {
            string word = this.gen.GetNewWord(3, 12, isFirstLerretUp: true);
            Assert.Equal(true, Char.IsUpper(word[0]));
        }

        [Fact]
        public void GetNewWordFromTextGeneratorWithFirstLowerLetterMustReturnItProperly()
        {
            string word = this.gen.GetNewWord(3, 12, isFirstLerretUp: false);
            Assert.Equal(true, Char.IsLower(word[0]));
        }

        [Fact]
        public void GetNewWordFromTextGeneratorMustBeLongerThatMinimalLength()
        {
            const int minLength = 3;

            string word = this.gen.GetNewWord(minLength, 12);
            Assert.Equal(true, word.Length >= minLength);
        }

        [Fact]
        public void GetNewWordFromTextGeneratorMustBeShorterThatMaximalLength()
        {
            const int maxLength = 10;

            string word = this.gen.GetNewWord(3, maxLength);
            Assert.Equal(true, word.Length <= maxLength);
        }

        #endregion getNewWord

        #region getWords

        [Fact]
        public void GettingNWordsFromTextGeneratorMustGetNWords()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            Assert.Equal(true, words.Length == N);
        }

        [Fact]
        public void GettingWordsFromTextGeneratorMustEndedWithDot()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            string lastWord = words[words.Length - 1].Trim();

            Assert.Equal(true, lastWord[lastWord.Length - 1] == this.gen.DotMark);
        }

        [Fact]
        public void TextGeneratorsWordsMustHaveSpaceAfterDot()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == this.gen.DotMark)
                {
                    if (text[i + 1] != this.gen.SpaceMark)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        [Fact]
        public void TextGeneratorsWordsMustNotHaveSpaceBeforeDot()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == this.gen.DotMark)
                {
                    if (text[i - 1] == this.gen.SpaceMark)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        [Fact]
        public void TextGeneratorsWordsMustHaveSpaceAfterExclamation()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == this.gen.ExclamationMark)
                {
                    if (text[i + 1] != this.gen.SpaceMark)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        [Fact]
        public void TextGeneratorsWordsMustNotHaveSpaceBeforeExclamation()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == this.gen.DotMark)
                {
                    if (text[i - 1] == this.gen.ExclamationMark)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        [Fact]
        public void TextGeneratorsWordsMustHaveSpaceAfterQuestion()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == this.gen.QuestionMark)
                {
                    if (text[i + 1] != this.gen.SpaceMark)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        [Fact]
        public void TextGeneratorsWordsMustNotHaveSpaceBeforeQuestion()
        {
            const int N = 60;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == this.gen.DotMark)
                {
                    if (text[i - 1] == this.gen.QuestionMark)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        #region is

        [Fact]
        public void GettingWordsFromTextGeneratorWithoutDotsMustNotHaveDots()
        {
            const int N = 60;

            this.gen.IsUsingDots = false;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            Assert.Equal(false, text.Contains(this.gen.DotMark.ToString()));
        }

        [Fact]
        public void GettingWordsFromTextGeneratorWithoutCommasMustNotHaveCommas()
        {
            const int N = 60;

            this.gen.IsUsingCommas = false;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            Assert.Equal(false, text.Contains(this.gen.CommaMark.ToString()));
        }

        [Fact]
        public void GettingWordsFromTextGeneratorWithoutExclamationsMustNotHaveExclamations()
        {
            const int N = 60;

            this.gen.IsUsingExclamationMarks = false;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            Assert.Equal(false, text.Contains(this.gen.ExclamationMark.ToString()));
        }

        [Fact]
        public void GettingWordsFromTextGeneratorWithoutQuestionsMustNotHaveQuestions()
        {
            const int N = 60;

            this.gen.IsUsingQuestionMarks = false;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            Assert.Equal(false, text.Contains(this.gen.QuestionMark.ToString()));
        }

        [Fact]
        public void GettingWordsFromTextGeneratorWithoutThreeDotsMustNotHaveThreeDots()
        {
            const int N = 60;

            this.gen.IsUsingThreeDotsMark = false;

            string[] words = this.gen.GetWords(N).ToArray();

            StringBuilder sb = new StringBuilder(128);

            foreach (var item in words)
            {
                sb.Append(item);
            }

            string text = sb.ToString();

            Assert.Equal(false, text.Contains(this.gen.ThreeDotsMark.ToString()));
        }

        #endregion is

        #endregion getWords
    }
}
