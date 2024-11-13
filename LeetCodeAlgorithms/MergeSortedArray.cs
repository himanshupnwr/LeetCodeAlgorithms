using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class MergeSortedArray
    {
       /*
       Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
       Output: [1,2,2,3,5,6]
       Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
       The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
       */
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) return;
            int len1 = nums1.Length;
            int end_idx = len1 - 1;
            while (n > 0 && m > 0)
            {
                if (nums2[n - 1] >= nums1[m - 1])
                {
                    nums1[end_idx] = nums2[n - 1];
                    n--;
                }
                else
                {
                    nums1[end_idx] = nums1[m - 1];
                    m--;
                }
                end_idx--;
            }
            while (n > 0)
            {
                nums1[end_idx] = nums2[n - 1];
                n--;
                end_idx--;
            }
        }
    }
}
