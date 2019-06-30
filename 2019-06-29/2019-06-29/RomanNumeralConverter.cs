using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_06_29
{
    public class RomanNumeralConverter
    {

        Dictionary<string, int> RomanNumbers = new Dictionary<string, int>
        {
            { "I", 1 },
            { "IV", 4 },
            { "V", 5 },
            { "IX", 9 },
            { "X", 10 },
            { "XL", 40 },
            { "L", 50 },
            { "XC", 90 },
            { "C", 100 },
            { "CD", 400 },
            { "D", 500 },
            { "CM", 900 },
            { "M", 1000 }
        };
        public string ConvertNumber(int value)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException();

            string result = "";
            foreach(var roman in RomanNumbers.OrderByDescending(x => x.Value))
            {
                while(value >= roman.Value)
                {
                    value -= roman.Value;
                    result += roman.Key;
                }
            }

            return result;
        }

        public int ConvertRoman(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException();

            int result = 0;
            for(int i =0; i < value.Length; i++)
            {
                result += RomanNumbers[value[i].ToString()];
            }

            return result;
        }
    }
}