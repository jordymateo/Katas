using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2019_06_01.Anagrams
{
    public class AnagramsManager
    {
        public string[] AnagramsList { get; set; }
        public AnagramsManager(IAnagramsFinder finder)
        {
            AnagramsList = finder.GetAnagrams();
            if (AnagramsList == null)
                throw new NullReferenceException();
        }

        public bool Validator(string v1, string v2)
        {
            if (v1.Count() != v2.Count())
                return false;

            var temp1 = v1.ToLower().Select(x => x).OrderBy(x => x);
            var temp2 = v2.ToLower().Select(x => x).OrderBy(x => x);

            var v1Ordered = string.Join("", temp1);
            var v12Ordered = string.Join("", temp2);
            
            return v1Ordered == v12Ordered;
        }
    }
}
