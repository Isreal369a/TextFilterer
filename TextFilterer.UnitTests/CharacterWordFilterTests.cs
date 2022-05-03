using Xunit;

namespace TextFilterer.UnitTests
{
    public class CharacterWordFilterTests
    {
        CharacterWordFilter sut;

        public CharacterWordFilterTests()
        {
            sut = new CharacterWordFilter();
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        public void should_handle_null_empty_word(string word, string expected)
        {
            var result  = sut.Filter(word);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("what", "")]
        [InlineData("t", "")]
        [InlineData("hello,t", "")]
        [InlineData("hello t", "")]
        public void should_filter_out_words_that_contain_t(string word, string expected)
        {
            var result = sut.Filter(word);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", "hello")]
        public void should_return_original_word_when_false(string word, string expected)
        {
            var result = sut.Filter(word);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_filter_word_based_on_character()
        {
            sut.Character = 'm';
            string expected = string.Empty;

            var result = sut.Filter("man");
            Assert.Equal(expected, result);
        }
    }
}