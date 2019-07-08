using System;

namespace _2019_07_07
{
    public class Wrapper
    {
        public static string Wrap(string text, int columns)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException();

            string result = "";

            int columnLine = 0;
            foreach(var word in text.Split(' '))
            {
                if (columnLine == columns)
                {
                    result += "\n";
                    columnLine = 0;
                }
                if (columnLine != 0 && result != "")
                    result += " ";
                result += word;
                columnLine++;
            }

            return result;
        }
    }
}