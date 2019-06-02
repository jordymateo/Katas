using _2019_06_01.Anagrams;
using Moq;
using System;
using Xunit;

namespace XUnitTest
{
    public class AngramsTest
    {
        /*
          Clase -> Metodos Principales para validar y en paquetar
          Interface -> Retornar la lista de palabras

          Clase -> Validar que reciba lista de palabras
            -> Null Exception
          Clase -> validar que dos palabras coincidan

        */

        [Fact]
        public void AnagramsFinder_ReturnsNull_Throw_NullReferenceException()
        {
            //Arrage
            var iAnagramsFinder = new Mock<IAnagramsFinder>();
            iAnagramsFinder.Setup(x => x.GetAnagrams()).Returns<string[]>(null);

            //Assert
            Assert.Throws<NullReferenceException>(() => new AnagramsManager(iAnagramsFinder.Object));
        }

        [Fact]
        public void AnagramsFinder_Returns_Items_AnagramsList_HasValue()
        {
            //Arrage
            string[] testData = new string[] { "test1", "test2" };
            var iAnagramsFinder = new Mock<IAnagramsFinder>();
            iAnagramsFinder.Setup(x => x.GetAnagrams()).Returns(testData);
            var anagramsManager = new AnagramsManager(iAnagramsFinder.Object);
            
            //Act
            var actual = anagramsManager.AnagramsList;

            //Assert
            Assert.Equal(testData, actual);
        }

        [Fact]
        public void Anagram_Validator_Params_Are_NotEquals_Returns_False()
        {
            //Arrage
            string[] testData = new string[] { "test1", "test2" };
            var iAnagramsFinder = new Mock<IAnagramsFinder>();
            iAnagramsFinder.Setup(x => x.GetAnagrams()).Returns(testData);

            var anagramsManager = new AnagramsManager(iAnagramsFinder.Object);

            //Act
            var actual = anagramsManager.Validator(testData[0], testData[1]);

            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void Anagram_Validator_Params_Are_Equals_Returns_True()
        {
            //Arrage
            string[] testData = new string[] { "test1", "1tesT" };
            var iAnagramsFinder = new Mock<IAnagramsFinder>();
            iAnagramsFinder.Setup(x => x.GetAnagrams()).Returns(testData);

            var anagramsManager = new AnagramsManager(iAnagramsFinder.Object);

            //Act
            var actual = anagramsManager.Validator(testData[0], testData[1]);

            //Assert
            Assert.True(actual);
        }
    }
}
