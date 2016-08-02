using Xunit;

namespace SandS.Algorithm.Library.Generator
{
    internal class IssnGeneratorUnitTest
    {
        private readonly IssnGenerator gen = new IssnGenerator();

        [Theory]
        [InlineData(42)]
        public void IsbnGeneratorMustWork(int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                string isbn = this.gen.Generate();
                Assert.Equal(true, this.gen.ValidateIssn(isbn));
            }
        }

        [Theory]
        [InlineData("ISSN 0028-0836")]
        [InlineData("ISSN 0004-6337")]
        [InlineData("ISSN 1521 3994")]
        public void IsbnValidationMustWork_Positive(string isbn)
        {
            Assert.True(this.gen.ValidateIssn(isbn));
        }

        [Theory]
        [InlineData("ISSN 1521 399")]
        [InlineData("ISSN 1521-3-994")]
        public void IsbnValidationMustWork_Negative(string isbn)
        {
            Assert.False(this.gen.ValidateIssn(isbn));
        }
    }
}