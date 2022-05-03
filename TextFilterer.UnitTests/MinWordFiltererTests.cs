using Xunit;

namespace TextFilterer.UnitTests
{

    public class MinWordFiltererTests
    {
        MinWordFilterer sut;

        public MinWordFiltererTests()
        {
            sut = new MinWordFilterer();
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
        [InlineData("he")]
        [InlineData("e")]
        [InlineData("")]
        public void should_filter_out_word_less_than_three(string value)
        {
            string expected = string.Empty;

            string result = sut.Filter(value);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_return_original_word_when_false()
        {
            string line = "HelloHello";
            string expected = "HelloHello";

            string result = sut.Filter(line);

            Assert.Equal(expected, result);
        }
        
    }
}