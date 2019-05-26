using System;
using System.Linq;

namespace _2019_05_25
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite los numeros:");
            var number = Console.ReadLine();

            Console.WriteLine(add(number));

            Console.ReadKey();
        }

        static string add(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return "0";

            string separator = ",";
            int position = 0;
            int sum = 0;
            string errors = "";

            if (number.StartsWith("//"))
            {
                number = number.Replace("\\n", "\n");
                var separatorIndex = number.IndexOf("\n");
                separator = number.Substring(0, separatorIndex);
                separator = separator.Replace("//", "");

                int numberLength = number.Count() - (separatorIndex + 1);
                number = number.Substring(separatorIndex + 1, numberLength);
                position += 5;
            }

            var numbers = number.Split(separator);

            foreach (var num in numbers)
            {
                var xNum = num.Replace("\\n", "\n");

                if (string.IsNullOrWhiteSpace(xNum))
                {
                    errors += "Number expected but EOF found. \n";
                    continue;
                }


                if (xNum.IndexOf('\n') > -1)
                {

                    if (xNum.StartsWith('\n'))
                    {
                        errors = $"Number expected but '\\n' found at position {position}. \n";
                        continue;
                    }

                    var subNumbers = xNum.Split('\n');

                    foreach(var sn in subNumbers)
                    {
                        sum += int.Parse(sn);
                        position += sn.Count() + 1;
                    }
                    continue;
                }

                sum += int.Parse(xNum);
                position += xNum.Count() + 1;
            }

            if (!string.IsNullOrWhiteSpace(errors))
                return errors;

            return sum.ToString();
        }
    }
}
