using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    //remove some duplicates in-place such that each unique element appears at most twice.
    //The relative order of the elements should be kept the same.

    //Input: nums = [1,1,1,2,2,3]
    //Output: 5, nums = [1, 1, 2, 2, 3, _]

    //Input: nums = [0,0,1,1,1,1,2,3,3]
    //Output: 7, nums = [0, 0, 1, 1, 2, 3, 3, _, _]
    internal class RemoveDuplicatesFromSortedArray2
    {
        public int RemoveDuplicates(int[] nums)
        {
            int count = 0;
            bool isPrevTwice = false;
            for (int i = 1; i < nums.Length; i++)
            {
                bool isCurrentTwice = nums[count] == nums[i];
                if (!isCurrentTwice || !isPrevTwice)
                    nums[++count] = nums[i];
                isPrevTwice = isCurrentTwice;
            }
            return count + 1;
        }
    }
}
