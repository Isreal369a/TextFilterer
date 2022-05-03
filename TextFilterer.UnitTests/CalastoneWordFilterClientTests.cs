using Moq;
using Xunit;

namespace TextFilterer.UnitTests
{
    public class CalastoneWordFilterClientTests
    {
        readonly CalastoneWordFilterClient sut;
        readonly Mock<ILineSplitter> lineSplitterMock;

        public CalastoneWordFilterClientTests()
        {
            lineSplitterMock = new Mock<ILineSplitter>();
            sut = new CalastoneWordFilterClient(lineSplitterMock.Object); ;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void should_return_line_when_empty_or_null(string line)
        {
            string result = sut.FilterLine(line, null);
            Assert.Equal(line, result);
        }

        [Fact]
        public void should_return_line_when_filter_is_null()
        {
            string line = "hello there";

            string result = sut.FilterLine(line, null);
            Assert.Equal(line, result);
        }

        [Fact]
        public void should_split_words()
        {
            string line = "hello there";
           IWordFilter filter = new CharacterWordFilter();
           
            
            string result = sut.FilterLine(line, filter);

            lineSplitterMock.Verify(x => x.Split(It.Is<string>(y => y.Equals(line)), It.Is<char>(z => z.Equals(' '))), Times.Once());
        }

        [Fact]
        public void should_filter_each_word()
        {
            string line = "hello there";
            string[] splits = new string[] { "hello", "there" };
            Mock<IWordFilter> filtererMock = new Mock<IWordFilter>();
            lineSplitterMock.Setup(x => x.Split(line, It.IsAny<char>())).Returns(splits);

            string result = sut.FilterLine(line, filtererMock.Object);

            filtererMock.Verify(x => x.Filter(It.IsAny<string>()), Times.Exactly(2));            
        }
    }
}
