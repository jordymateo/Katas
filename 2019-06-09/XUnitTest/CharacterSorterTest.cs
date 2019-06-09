using _2019_06_09;
using System;
using Xunit;

namespace XUnitTest
{
    public class CharacterSorterTest
    {
        /*
         Si el parametro es nulo -> throw argumentnullexception 
         Las letras pasaran de mayusculas a minusculas -> retorn mins
         Se ignoraran los signos de puntuacion -> retorn without puntationsign
         Se concatenaran los caracteres de forma ascendente -> retorn sortedstring
        */
        [Fact]
        public void Text_IsNull_Throw_ArgumentNullException()
        {
            //arrage
            CharacterSorter characterSorter = new CharacterSorter();

            //act
            Action actual = () => characterSorter.SortText(null);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }

        [Fact]
        public void Text_Has_Mayus_Returns_Text_Minus()
        {
            //arrage
            CharacterSorter characterSorter = new CharacterSorter();

            //act
            string actual = characterSorter.SortText("AABZ");

            //assert
            Assert.Equal("aabz", actual);
        }

        [Fact]
        public void Text_Has_Special_Characters_Returns_Text_Without_Special_Characters()
        {
            //arrage
            CharacterSorter characterSorter = new CharacterSorter();

            //act
            string actual = characterSorter.SortText("A!A.bz");

            //assert
            Assert.Equal("aabz", actual);
        }

        [Fact]
        public void Text_Returns_Text_Sorted_By_Characters()
        {
            //arrage
            CharacterSorter characterSorter = new CharacterSorter();

            //act
            string actual = characterSorter.SortText("bzAa");

            //assert
            Assert.Equal("aabz", actual);
        }
    }
}
