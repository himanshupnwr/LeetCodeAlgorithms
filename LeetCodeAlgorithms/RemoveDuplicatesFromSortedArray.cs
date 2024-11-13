using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    //Input: nums = [1,1,2]
    //Output: 2, nums = [1, 2, _]
    //Input: nums = [0,0,1,1,1,2,2,3,3,4]
    //Output: 5, nums = [0, 1, 2, 3, 4, _, _, _, _, _]

    //Time complexity - O(n) space complexity - O(1)
    internal class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}
