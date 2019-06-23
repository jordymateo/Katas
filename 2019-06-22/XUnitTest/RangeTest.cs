using _2019_06_22;
using System;
using Xunit;

namespace XUnitTest
{
    public class RangeTest
    {
        /*
          If Params are null -> Throw argumentnull exception
          Range contains nums list -> Returns true {0, 1, 2, ..}
          Ranges not contains nums list -> Returns false
          Range contains other range -> Returns true
          Range not contains other range -> returns false
         */

        [Fact]
        public void Params_Are_Null_Throws_ArgumentNullException()
        {
            Action range = () => Range.Compare(null, null);

            Assert.Throws<ArgumentNullException>(range);
        }

        [Fact]
        public void Range_Contains_NumsList_Returns_True()
        {
            //arrage
            string range = "[0, 10]";
            string compare = "{2, 3, 4}";

            //act
            bool actual = Range.Compare(range, compare);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void Range_Not_Contains_NumsList_Returns_False()
        {
            //arrage
            string range = "[0, 10]";
            string compare = "{2, -1, 3, 4}";

            //act
            bool actual = Range.Compare(range, compare);

            //assert
            Assert.False(actual);
        }

        [Fact]
        public void Range_Contains_Range_Returns_True()
        {
            //arrage
            string range = "[0, 10]";
            string compare = "[0, 9)";

            //act
            bool actual = Range.Compare(range, compare);

            //assert
            Assert.True(actual);
        }

        [Fact]
        public void Range_Not_Contains_Range_Returns_False()
        {
            //arrage
            string range = "[0, 8)";
            string compare = "(0, 9]";

            //act
            bool actual = Range.Compare(range, compare);

            //assert
            Assert.False(actual);
        }
    }
}
