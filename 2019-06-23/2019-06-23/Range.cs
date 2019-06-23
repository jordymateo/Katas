using System;
using System.Linq;

namespace _2019_06_23
{
    public class Range
    {
        public int[] RangeNumbers { get; set; }

        public Range(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException();

            RangeNumbers = GetRange(value);
        }

        private int[] GetRange(string value)
        {
            var range = value.Substring(1, value.Length - 2).Split(',')
                .Select(x => int.Parse(x.Trim()))
                .OrderBy(x => x).ToArray();

            if (value[0] == '(')
                range[0]++;
            if (value[value.Length - 1] == ')')
                range[range.Length - 1]--;
            return range;
        }

        public bool Contains(string range)
        {
            if (string.IsNullOrWhiteSpace(range))
                throw new ArgumentNullException();

            var compareNums = GetRange(range);
            if (RangeNumbers[0] <= compareNums[0] && 
                RangeNumbers[RangeNumbers.Length - 1] >= compareNums[compareNums.Length - 1])
                return true;

            return false;
        }
    }
}