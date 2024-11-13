using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class LongestSubArrayWithSumK
    {
        /*Given an array and a sum k, we need to print the length of the longest subarray that sums to k..
        Example 1:

        Input Format: N = 3, k = 5, array[] = {2,3,5}
        Result: 2
        Explanation:
         The longest subarray with sum 5 is {2, 3}. And its length is 2.

        Example 2:

        Input Format: N = 3, k = 1, array[] = {-1, 1, 1}
        Result: 3
        Explanation: The longest subarray with sum 1 is {-1, 1, 1}. And its length is 3.*/
        public static int getLongestSubarray(int[] a, int k)
        {
            int n = a.Length; // size of the array.

            Dictionary<int, int> preSumMap = new Dictionary<int, int>();
            int sum = 0;
            int maxLen = 0;
            for (int i = 0; i < n; i++)
            {
                //calculate the prefix sum till index i:
                sum += a[i];

                // if the sum = k, update the maxLen:
                if (sum == k)
                {
                    maxLen = Math.Max(maxLen, i + 1);
                }

                // calculate the sum of remaining part i.e. x-k:
                int rem = sum - k;

                //Calculate the length and update maxLen:
                if (preSumMap.ContainsKey(rem))
                {
                    int len = i - preSumMap[rem];
                    maxLen = Math.Max(maxLen, len);
                }

                //Finally, update the map checking the conditions:
                if (!preSumMap.ContainsKey(sum))
                {
                    preSumMap.Add(sum, i);
                }
            }

            return maxLen;
        }
    }
}
