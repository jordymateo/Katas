using System;
using System.Collections.Generic;

namespace _2019_07_06
{
    public class Wrapper
    {
        public static string Wrap(string text, int columns)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException();

            string result = "";
            
            int wordsInLine = 0;
            foreach(var word in text.Split(' '))
            {
                if (wordsInLine == columns)
                {
                    result += "\n";
                    wordsInLine = 0;
                }

                if (result != "" && wordsInLine != 0)
                    result += " ";

                result += word;
                wordsInLine++;
            }

            return result;
        }
    }
}