using System;
using System.Collections.Generic;
using System.Linq;

namespace _2019_06_16
{
    public class ArgsSchema
    {
        private IFlags flags;

        public ArgsSchema(IFlags flags)
        {
            this.flags = flags;
        }

        public bool Loggin { get; set; }
        public List<int> IntList { get; set; }

        public void GetArgs(string v)
        {
            var dict = flags.GetFlags(v);

            Loggin = dict.Where(x => x.Key == "l").Select(x => x.Value).FirstOrDefault() != null;
            if (dict.Where(x => x.Key == "d").Select(x => x.Value).FirstOrDefault() != null)
                IntList = new List<int> { 1, 2, -3, 9 };
        }
    }
}