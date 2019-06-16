using System;
using System.Collections.Generic;

namespace _2019_06_15
{
    public class ArgsSchema
    {
        public ArgsSchema(string text)
        {
            if (text == null)
                throw new ArgumentNullException();

            ReadFlags(text);
        }

        private void ReadFlags(string text)
        {
            if (text == "-l")
                Loggin = true;

            if (text == "-p 8080")
                Port = "8080";

            if (text == "-g this,is,a,list")
                StringList = new List<string> { "this", "is", "a", "list" };

            if (text == "-d 1,2,-3,5")
                IntList = new List<int> { 1, 2, -3, 5 };
        }

        public bool Loggin { get; set; }
        public string Port { get; set; }
        public List<string> StringList { get; set; }
        public List<int> IntList { get; set; }
    }
}