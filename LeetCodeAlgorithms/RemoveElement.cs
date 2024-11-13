using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class RemoveElement
    {
        //TimeOnly complexity - O(n)
        //O(1) - In-place modification with no extra space used.

        //Remove all occurances of a given value from an array and
        //rearrange the array to be continuous after removing the val
        public static int RemoveElementFunc(int[] nums, int val)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[count++] = nums[i];

                }
            }
            return count;
        }
    }
}
