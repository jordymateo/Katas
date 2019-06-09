using _2019_06_08;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class BallsSorterTest
    {
        /*
            add -> 
                is empty -> balls is empty
                add one number -> balls has that number
                secuential nums -> add it to the list
                not secuential nums -> add it sorted to the list
        */
        [Fact]
        public void Never_call_add_Balls_willbe_Empty()
        {
            //arrage
            BallsSorter ballsSorter = new BallsSorter();

            //act
            var actual = ballsSorter.balls;
            List<int> emptyList = new List<int>();

            //assert
            Assert.Equal(emptyList, actual);
        }

        [Fact]
        public void Add_One_Number_Balls_Wll_Has_That_Number()
        {
            //arrage
            BallsSorter ballsSorter = new BallsSorter();

            //act
            ballsSorter.Add(1);
            var actual = ballsSorter.balls;

            //assert
            Assert.Equal(new[] { 1 }, actual);
        }

        [Fact]
        public void Add_Two_Secuential_Numbers_Balls_Will_Has_Those_Numbers()
        {
            //arrage
            BallsSorter ballsSorter = new BallsSorter();

            //act
            ballsSorter.Add(1);
            ballsSorter.Add(2);
            var actual = ballsSorter.balls;

            //assert
            Assert.Equal(new[] { 1, 2 }, actual);
        }

        [Fact]
        public void Add_Two_Not_Secuential_Numbers_Balls_Will_Has_Those_Numbers_Sorted()
        {
            //arrage
            BallsSorter ballsSorter = new BallsSorter();

            //act
            ballsSorter.Add(2);
            ballsSorter.Add(1);
            var actual = ballsSorter.balls;

            //assert
            Assert.Equal(new[] { 1, 2 }, actual);
        }

        [Fact]
        public void Add_Three_Not_Secuential_Numbers_Balls_Will_Has_Those_Numbers_Sorted()
        {
            //arrage
            BallsSorter ballsSorter = new BallsSorter();

            //act
            ballsSorter.Add(20);
            ballsSorter.Add(10);
            ballsSorter.Add(30);
            var actual = ballsSorter.balls;

            //assert
            Assert.Equal(new[] { 10, 20, 30 }, actual);
        }
    }
}
