using Xunit;

namespace TextFilterer.UnitTests
{
    public class VowelFiltererTests
    {
        readonly VowelFilterer sut;

        public VowelFiltererTests()
        {
            sut = new VowelFilterer();
        }

        [Fact]
        public void should_handle_empty_word()
        {
            string line = string.Empty;
            string expected = string.Empty;

            string result = sut.Filter(line);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("at", "")]
        [InlineData("doom", "")]
        [InlineData("floors", "")]
        public void should_filter_when_in_even_length_word(string word, string expected)
        {

            string result = sut.Filter(word);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("fat", "")]
        [InlineData("dom", "")]
        [InlineData("floor", "")]
        public void should_filter_when_in_odd_length_word(string word, string expected)
        {

            string result = sut.Filter(word);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_return_original_word_when_not_vowel()
        {
            string line = "middle";
            string expected = "middle";

            string result = sut.Filter(line);

            Assert.Equal(expected, result);
        }
    }
}