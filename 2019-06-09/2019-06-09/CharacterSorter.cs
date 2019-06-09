using System;

namespace _2019_06_09
{
    public class CharacterSorter
    {
        public string SortText(string text)
        {
            if (text == null)
                throw new ArgumentNullException();

            text = text.ToLower();
            string temp = "";

            foreach(var ch in text)
            {
                if (ch >= 'a' && ch <= 'z')
                    temp += ch;
            }

            char[] chars = temp.ToCharArray();

            bool cont;
            int count = chars.Length;
            do
            {
                cont = false;
                for(int i = 0; i < count - 1; ++i)
                {
                    if (chars[i] > chars[i + 1])
                    {
                        char tt = chars[i];
                        chars[i] = chars[i + 1];
                        chars[i + 1] = tt;
                        cont = true;
                    }
                }
                count--;
            } while (cont);

            return string.Join(string.Empty, chars);
        }
    }
}