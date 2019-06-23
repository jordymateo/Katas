using System;
using System.Linq;

namespace _2019_06_22
{
    public class Range
    {
        private static int[] ExtractRange(string range)
        {
            var nums = range.Substring(1, range.Length - 2)
                .Split(',')
                .Select(x => int.Parse(x.Trim()))
                .OrderBy(x => x)
                .ToArray();

            if (range[0] == '(')
                nums[0] = nums[0] + 1;

            if (range[range.Length - 1] == ')')
                nums[nums.Length - 1] = nums[nums.Length - 1] - 1;

            return nums;
        }

        public static bool Compare(string range, string compare)
        {
            if (string.IsNullOrWhiteSpace(range) || string.IsNullOrWhiteSpace(compare))
                throw new ArgumentNullException();

            //range
            var rangeNums = ExtractRange(range);

            //compare
            var compareNums = ExtractRange(compare);
            
            if (rangeNums[0] <= compareNums[0] && rangeNums[rangeNums.Length - 1] >= compareNums[compareNums.Length - 1])
                return true;
            
            return false;
        }
    }
}