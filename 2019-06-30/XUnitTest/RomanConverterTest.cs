using _2019_06_30;
using System;
using Xunit;

namespace XUnitTest
{
    public class RomanConverterTest
    {
        /*
        roman to decimal
        null -> return argumentNullex..
        1digitroman ->return decimal
        complexroman -> return decimal
         */
        [Fact]
        public void Number_IsZero_Throws_ArgumentOutOfRangeException()
        {
            //arrage
            RomanConverter romanConverter = new RomanConverter();

            //act
            Action actual = () => romanConverter.ConvertNumber(0);

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(actual);
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("V", 5)]
        [InlineData("X", 10)]
        [InlineData("L", 50)]
        [InlineData("C", 100)]
        [InlineData("D", 500)]
        [InlineData("M", 1000)]
        public void OneDigit_Number_Returns_Roman(string expected, int value)
        {
            //arrage
            RomanConverter romanConverter = new RomanConverter();

            //act
            string actual = romanConverter.ConvertNumber(value);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Complex_Number_Returns_Roman()
        {
            //arrage
            RomanConverter romanConverter = new RomanConverter();

            //act
            string actual = romanConverter.ConvertNumber(624);

            //assert
            Assert.Equal("DCXXIV", actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Roman_IsNullOrEmpty_Throws_ArgumentNullException(string value)
        {
            //arrage
            RomanConverter romanConverter = new RomanConverter();

            //act
            Action actual = () => romanConverter.ConvertRoman(value);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Theory]
        [InlineData( 1, "I")]
        [InlineData( 5, "V")]
        [InlineData( 10, "X")]
        [InlineData( 50, "L")]
        [InlineData( 100, "C")]
        [InlineData( 500, "D")]
        [InlineData( 1000, "M")]
        public void Simple_Roman_Returns_OneDigit_Number(int expected, string value)
        {
            //arrage
            RomanConverter romanConverter = new RomanConverter();

            //act
            int actual = romanConverter.ConvertRoman(value);

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Complex_Roman_Returns_Number()
        {
            //arrage
            RomanConverter romanConverter = new RomanConverter();

            //act
            int actual = romanConverter.ConvertRoman("DCXXIV");

            //assert
            Assert.Equal(624, actual);
        }
    }
}
