using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_06_30
{
    public class RomanConverter
    {
        Dictionary<string, int> Romans = new Dictionary<string, int>
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
            { "DM", 900 },
            { "M", 1000 }
        };

        public string ConvertNumber(int value)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException();

            string result = "";

            foreach(var roman in Romans.OrderByDescending(x => x.Value))
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

            for(int i = 0; i < value.Length; i++)
            {
                int temp = Romans[value[i].ToString()];
                if (i < (value.Length - 1) && temp < Romans[value[i + 1].ToString()])
                    result += Romans[$"{value[i]}{value[++i]}"];
                else
                    result += temp;
            }

            return result;
        }
    }
}