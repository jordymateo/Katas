using _2019_07_07;
using System;
using Xunit;

namespace XUnitTest
{
    public class WrapperTest
    {
        /*
         if text is empty or null -> argument null exception
         columns is major than words -> return the same text
         columns is  less than words -> return divided text
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
        public void Text_Words_Are_Less_Than_Columns_Returns_Same_Text()
        {
            //act
            string actual = Wrapper.Wrap("This is a test", 5);

            //assert
            Assert.Equal("This is a test", actual);
        }

        [Fact]
        public void Text_Words_Are_Major_Than_Columns_Returns_Text_Divided()
        {
            //act
            string actual = Wrapper.Wrap("This is a test for xunit", 2);

            //assert
            Assert.Equal("This is\na test\nfor xunit", actual);
        }
    }
}
