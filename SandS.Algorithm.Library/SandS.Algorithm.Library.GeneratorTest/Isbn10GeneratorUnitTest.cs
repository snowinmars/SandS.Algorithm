using System;
using SandS.Algorithm.Library.Generator;
using Xunit;

namespace SandS.Algorithm.Library.GeneratorTest
{
    public class Isbn10GeneratorUnitTest
    {
        private readonly Isbn10Generator gen = new Isbn10Generator();

        [Theory]
        [InlineData(42)]
        public void IsbnGeneratorMustWork(int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                string isbn = this.gen.Generate();
                Assert.Equal(true, this.gen.ValidateIsbn(isbn));
            }
        }

        [Theory]
        [InlineData("ISBN 123456789X")]
        [InlineData("ISBN 0123-4567-89")]
        [InlineData("ISBN 184353066X")]
        public void IsbnValidationMustWork_Positive(string isbn)
        {
            Assert.True(this.gen.ValidateIsbn(isbn));
        }

        [Theory]
        [InlineData("ISBN 123 456 7890")]
        [InlineData("ISBN 184354066X")]
        public void IsbnValidationMustWork_Negative(string isbn)
        {
            Assert.False(this.gen.ValidateIsbn(isbn));
        }
    }
}
