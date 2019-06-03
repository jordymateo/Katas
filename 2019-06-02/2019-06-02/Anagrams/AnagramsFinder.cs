using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2019_06_02.Anagrams
{
    public class AnagramsFinder
    {
        public List<AnagramGroup> Anagrams { get; set; } = new List<AnagramGroup>();

        public bool Validate(string v1, string v2)
        {
            if (v1.Count() != v2.Count())
                return false;

            var temp1 = v1.ToLower().Select(x => x).OrderBy(x => x);
            var temp2 = v2.ToLower().Select(x => x).OrderBy(x => x);
            var v1Sorted = string.Join("", temp1);
            var v2Sorted = string.Join("", temp2);
            
            return v1Sorted == v2Sorted;
        }

        public void GroupAnagram(string v)
        {
            bool existGroup = false;
            foreach(var item in Anagrams)
            {
                if (Validate(item.MainAnagram, v))
                {
                    item.Group.Add(v);
                    existGroup = true;
                }
            }
            if (!existGroup)
            {
                var newItem = new AnagramGroup
                {
                    MainAnagram = v,
                };
                newItem.Group.Add(v);
                Anagrams.Add(newItem);
            }
        }
    }

    public class AnagramGroup
    {
        public string MainAnagram { get; set; }
        public List<string> Group { get; set; } = new List<string>();
    }
}
