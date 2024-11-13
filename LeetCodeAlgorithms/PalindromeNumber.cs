using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class PalindromeNumber
    {
        //Time complexity:

        //First approach: O(N)
        //Second approach: O(N)

        //Space complexity:

        //First approach: O(N) - list stores up to n numbers
        //Second approach: O(1)


        //Create a list to store all digits, then go through the first half of the loop to check if
        //it reads the same forward and backward
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            List<int> storeNumber = new List<int>();
            while (x != 0)
            {
                storeNumber.Add(x % 10);
                x /= 10;
            }

            int length = storeNumber.Count;
            for (int i = 0; i < length / 2; i++)
            {
                if (storeNumber[i] != storeNumber[length - 1 - i])
                    return false;
            }
            return true;
        }

        //Calculate a new reversed number and then compare two numbers.If they are equal, return true
        public bool IsPalindromeTwo(int x)
        {
            if (x < 0) return false;

            int temp = x;
            int reverse = 0;

            while (temp != 0)
            {
                int digit = temp % 10;
                reverse = reverse * 10 + digit;
                temp /= 10;
            }
            return reverse == x;
               
        }
    }
}
