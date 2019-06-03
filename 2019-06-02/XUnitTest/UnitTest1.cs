using _2019_06_02.Anagrams;
using System;
using System.Linq;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        /*
            AnagramsFinder -> 
            validate -> string, string
                -Numero de letras diferentes -> falso
                -Caso exitoso, las dos palabras son anagramas
                - Palabras no son anagramas
            GroupAnagram  ->
                - Identifica grupo
                    - Si existe la registra para ese grupo
                    - Si no, crea grupo nuevo
        */
        [Fact]
        public void Number_Letters_NotEquals_Returns_False()
        {
            var anagramsFinder = new AnagramsFinder();

            var actual = anagramsFinder.Validate("test1", "test");

            Assert.False(actual);
        }

        [Fact]
        public void Words_Are_Anagrams_Returns_True()
        {
            var anagramsFinder = new AnagramsFinder();

            var actual = anagramsFinder.Validate("test1", "1test");

            Assert.True(actual);
        }

        [Fact]
        public void Words_Are_Not_Anagrams_Returns_False()
        {
            var anagramsFinder = new AnagramsFinder();

            var actual = anagramsFinder.Validate("test1", "2test");

            Assert.False(actual);
        }

        [Fact]
        public void Exist_Anagram_Group_GroupNotIncress()
        {
            var anagramsFinder = new AnagramsFinder();

            anagramsFinder.GroupAnagram("test1");
            anagramsFinder.GroupAnagram("1test");

            var anagramsCount = anagramsFinder.Anagrams;
            var actual = anagramsCount.Count();

            Assert.Equal(1, actual);
        }

        [Fact]
        public void Not_Exist_Anagram_Group_GroupIncress()
        {
            var anagramsFinder = new AnagramsFinder();

            anagramsFinder.GroupAnagram("test1");
            anagramsFinder.GroupAnagram("test2");

            var anagramsCount = anagramsFinder.Anagrams;
            var actual = anagramsCount.Count();

            Assert.Equal(2, actual);
        }
    }
}
