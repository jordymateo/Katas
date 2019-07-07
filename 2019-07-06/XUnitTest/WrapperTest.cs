using _2019_07_06;
using System;
using Xunit;

namespace XUnitTest
{
    public class WrapperTest
    {
        /*
         text is null or empty -> argumentNullException
         text has a word -> same result
         text -> separated
         text ignore last space if match with column ->
          */

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Text_IsNullOrEmpty_Throws_ArgumentNullException(string text)
        {
            //act
            Action actual = () => Wrapper.Wrap(text, 0);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Text_Has_A_Word_Returns_SameResult()
        {
            //act
            string actual = Wrapper.Wrap("Test", 2);

            //assert
            Assert.Equal("Test", actual);
        }

        [Fact]
        public void Text_Has_Eight_Words_Returns_Three_Lines()
        {
            //act
            string actual = Wrapper.Wrap("This is a test for unit testing, enjoyit", 3);

            //assert
            Assert.Equal("This is a\ntest for unit\ntesting, enjoyit", actual);
        }

        [Fact]
        public void Text_Last_Word_Match_With_Space_Returns_Text_WithOut_Last_Space()
        {
            //act
            string actual = Wrapper.Wrap("This is a test", 2);

            //assert
            Assert.Equal("This is\na test", actual);
        }
    }
}
