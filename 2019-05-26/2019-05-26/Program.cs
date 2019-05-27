using System;
using System.Linq;

namespace _2019_05_26
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba los numeros: ");

            var number = Console.ReadLine();
            Console.WriteLine(add(number));

            Console.ReadKey();
        }

        static string add(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return "0";

            int result = 1;
            string errors = "";
            string negatives = "";
            int position = 0;

            var numbers = number.Split(",");

            foreach(var num in numbers)
            {
                var fNum = num.Replace("\\n", "\n");

                if (fNum.StartsWith("\n"))
                    errors += $"Number expected but '\\n' found at position {position}.";

                var sNums = fNum.Split("\n");
                foreach(var sn in sNums)
                {
                    result *= validation(ref negatives, sn);
                }

                if (sNums.Count() == 0)
                    result *= validation(ref negatives, fNum);

                position += fNum.Count() + 1;
            }

            if (!string.IsNullOrWhiteSpace(negatives))
                errors += $"Negative not allowed : { negatives }";

            if (!string.IsNullOrWhiteSpace(errors))
                return errors;


            return result.ToString();
        }

        static int validation(ref string negatives, string val)
        {
            var value = int.Parse(val);

            if (value < 0)
                negatives += (string.IsNullOrWhiteSpace(negatives)) ? value.ToString() : $", {value.ToString()}";
            
            return value;
        }
    }
}
