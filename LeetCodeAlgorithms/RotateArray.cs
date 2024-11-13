using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class RotateArray
    {
        //Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5, 6, 7, 1, 2, 3, 4]
        //Explanation:
        //rotate 1 steps to the right: [7, 1, 2, 3, 4, 5, 6]
        //rotate 2 steps to the right: [6, 7, 1, 2, 3, 4, 5]
        //rotate 3 steps to the right: [5, 6, 7, 1, 2, 3, 4]

        /*static void Main(string[] args)
        {
            RotateOption1([1, 2, 3, 4, 5, 6, 7], 3);
        }*/

        //Time Complexity O(n), space complexity - O(n)
        public static void RotateOption1(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                res[(i + k) % n] = nums[i];
            }
            for (int i = 0; i < n; i++)
            {
                nums[i] = res[i];
            }
        }

        //Time Complexity O(n), space complexity - O(1)
        public static void RotateOption2(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n; // reduce k to the smallest positive integer equivalent

            Reverse(nums, 0, n - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, n - 1);
        }

        private static void Reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }
    }
}
