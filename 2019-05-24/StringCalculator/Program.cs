using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escriba los numberos que desea sumar: ");
            var input = Console.ReadLine();

            var stringCalculator = new StringCalculator();
            var output = stringCalculator.add(input);

            Console.WriteLine($"El resultado es: {output}");
            Console.ReadKey();
        }



    }

    class StringCalculator
    {
        public string add(string number)
        {
            //if (string.IsNullOrWhiteSpace(number))
            //    return "";

            string[] numbers = number.Split(',');
            string errors = "";
            
            double sum = 0;

            foreach (var num in numbers)
            {

                if (num.IndexOf('\n') > -1)
                {
                    if (num.IndexOf('\n') > 2)
                    {
                        errors += $"Number expected but '\n' found at position {number.IndexOf(num)}";
                        continue;
                    }

                    var listSubNums = num.Split(new[] { @"\\n" }, StringSplitOptions.None);

                    foreach (var subNum in listSubNums)
                    {
                        sum += int.Parse(num);
                    }
                }

                sum += int.Parse(num);
            }

            if (errors.Count() > 0)
                return errors;
            //foreach(var number )
            return sum.ToString();
        }
    }
}
