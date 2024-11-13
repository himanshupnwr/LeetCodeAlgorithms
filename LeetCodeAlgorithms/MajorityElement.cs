using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal static class MajorityElement
    {
        /// <summary>
        ///Find the element which is in majority count >(n/2) of n array items
        /// </summary>
        /// <param name="args"></param>
        /// 
        //Time complexity - O(n)
        //Space compelxity - O(n)
        /*static void Main(string[] args)
        {
            MajorityElementWithNoDict([1, 2, 3, 4, 4, 4, 4]);
            MajorityElementWithDict([1, 2, 3, 4, 4, 4, 4]);
        }*/
        public static int MajorityElementWithDict(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (int val in nums)
            {
                if (map.ContainsKey(val))
                    map[val]++;
                else
                    map[val] = 1;
            }

            foreach (var pair in map)
            {
                int freq = pair.Value;
                if (freq > n / 2)
                {
                    return pair.Key;
                }
            }
            return -1;
        }

        ////Time complexity - O(n)
        //Space compelxity - O(1)
        public static int MajorityElementWithNoDict(int[] nums)
        {
            int count = 0;
            int element = 0;

            foreach (int num in nums)
            {
                if (count == 0)
                {
                    element = num;
                }
                if (element == num)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            return element;
        }
    }
}
