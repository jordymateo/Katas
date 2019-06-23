using _2019_06_23;
using System;
using Xunit;

namespace XUnitTest
{
    public class RangeTest
    {
        /*
         MainRange is null -> throw ArgumentNullException 
         MainRange has range -> rangelist is not null
         Range is null -> throw ArgumentNullException 
         
         MainRange contains numslist -> returns true
         MainRange not contains numslist -> returns false

         MainRange contains range -> returns true
         MainRange not contains range -> returns false

        */
        [Fact]
        public void MainRange_IsNull_Throws_ArgumentNullException()
        {
            //arrage
            Range range;

            //act
            Action actual = () => range = new Range(null);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void MainRange_HasValue_RangeNumbers_HasValue()
        {
            //arrage
            Range range = new Range("[0, 1]");

            //act
            int[] actual = range.RangeNumbers;

            //assert
            Assert.Equal(new int[] { 0, 1 } , actual);
        }

        [Fact]
        public void Range_To_Compare_IsNull_Throws_ArgumentNullException()
        {
            //arrage
            Range range = new Range("[0, 1]");

            //act
            Action actual = () => range.Contains(null);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Mainrange_Contains_NumsList_Returns_True()
        {
            //arrage
            Range range = new Range("[3, 8]");

            //act
            bool actual = range.Contains("{ 3, 4, 6 }");

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void Mainrange_Not_Contains_NumsList_Returns_False()
        {
            //arrage
            Range range = new Range("[3, 8]");

            //act
            bool actual = range.Contains("{ 3, -1, 4, 6 }");

            //assert
            Assert.False(actual);
        }

        [Theory]
        [InlineData("(2, 7]")]
        [InlineData("[3, 9)")]
        public void Mainrange_Contains_range_Returns_True(string numsRange)
        {
            //arrage
            Range range = new Range("[3, 8]");

            //act
            bool actual = range.Contains(numsRange);

            //assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData("(1, 7]")]
        [InlineData("[3, 10)")]
        public void Mainrange_Not_Contains_range_Returns_False(string numsRange)
        {
            //arrage
            Range range = new Range("[3, 8]");

            //act
            bool actual = range.Contains(numsRange);

            //assert
            Assert.False(actual);
        }
    }
}
