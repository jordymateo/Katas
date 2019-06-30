using _2019_06_29;
using System;
using Xunit;

namespace XUnitTest
{
    public class RomanNumeralConverterTest
    {
        /*
         Param is 0 -> throw ArgumentOutOfRange
         Convert Number -> return RomanNumber
         Convert complex number -> return RomanNumber

          param is null or empty -> argumentnullexception
          convert roman -> return number
          convert complex roman -> return number
          */

        [Fact]
        public void Number_IsNull_Returns_ArgumentOutOfRangeException()
        {
            //arrage
            RomanNumeralConverter romanNumeral = new RomanNumeralConverter();

            //act
            Action actual = () => romanNumeral.ConvertNumber(0);

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
        [InlineData("IV", 4)]
        [InlineData("IX", 9)]
        [InlineData("XL", 40)]
        [InlineData("CD", 400)]
        [InlineData("CM", 900)]
        public void Send_Simple_Number_Returns_RomanNumber(string excepected, int value)
        {
            //arrage
            RomanNumeralConverter romanNumeral = new RomanNumeralConverter();

            //act
            string actual = romanNumeral.ConvertNumber(value);

            //assert
            Assert.Equal(excepected, actual);
        }

        [Fact]
        public void Send_Complex_Number_Returns_RomanNumber()
        {
            //arrage
            RomanNumeralConverter romanNumeral = new RomanNumeralConverter();

            //act
            string actual = romanNumeral.ConvertNumber(327);

            //assert
            Assert.Equal("CCCXXVII", actual);
        }

        [Fact]
        public void Roman_IsNull_Throws_ArgumentNullException()
        {
            //arrage
            RomanNumeralConverter romanNumeral = new RomanNumeralConverter();

            //act
            Action actual = () => romanNumeral.ConvertRoman(null);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Send_Simple_Roman_Returns_Number()
        {
            //arrage
            RomanNumeralConverter romanNumeral = new RomanNumeralConverter();

            //act
            int actual = romanNumeral.ConvertRoman("I");

            //assert
            Assert.Equal(1, actual);
        }
    }
}
