using System;

namespace _2019_06_09
{
    class Program
    {
        static void Main(string[] args)
        {
            var characterSorter = new CharacterSorter();
            //Console.Write("Digite un texto: ");
            var text = "When not studying nuclear physics, Bambi likes to play beach volleyball."; //Console.ReadLine();

            var sorted = characterSorter.SortText(text);
            Console.WriteLine(sorted);
            Console.ReadKey();
        }
    }
}
