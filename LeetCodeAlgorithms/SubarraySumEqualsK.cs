using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class SubarraySumEqualsK
    {
        /*Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.

        A subarray is a contiguous non-empty sequence of elements within an array.
        Example 1:

        Input: nums = [1,1,1], k = 2
        Output: 2

        Example 2:

        Input: nums = [1,2,3], k = 3
        Output: 2*/

        //array[1,1,1,2,3,4,5,6,7,1,2,3,4,5,6]

        // Time complexity: O(n)

        //Space complexity: O(n)

        public int SubarraySum(int[] nums, int k)
        {
            // ps = <int sum of the current prefix, count>
            var ps = new Dictionary<int, int>();
            ps[0] = 1;

            int sum = 0;
            int cnt = 0;
            int len = nums.Length;

            for (int i = 0; i < len; ++i)
            {
                sum = sum + nums[i];

                // See if the sum - what you're looking for exists in the map.
                // The map represents the element sums seen so far
                var prefixLookup = sum - k;
                if (ps.ContainsKey(prefixLookup))
                {
                    cnt += ps[prefixLookup];
                }

                // Add current sum frequency for later lookup
                ps[sum] = ps.ContainsKey(sum) ? ps[sum] + 1 : 1;
            }

            return cnt;
        }
        //running: 1, 2, 3, 5, 8, 12, 17, 23, 30, 31, 33, 36, 40, 45, 46
        //array:   1, 1, 1, 2, 3, 4,  5,  6,  7,  1,  2,  3,  4,  5,  6
        //key:    -5,-4,-3,-1, 2, 6, 11, 17, 24, 25, 27, 30, 34, 39, 40
    }
}
