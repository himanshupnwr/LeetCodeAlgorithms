using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class ReverseInteger
    {
        //Given a signed 32-bit integer x, return x with its digits reversed.
        //If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
        //Input: x = 123 Output: 321, input: x = -123, Output: -321, input: x = 120, Output x = 12, 

        //Time complexity - O(n)
        public int Reverse(int x)
        {
            int temp = x, number = 0;
            long new_number = 0;

            if (x < 0)
                x = -x;

            //this will reverse the number
            while (x > 0)
            {
                new_number = new_number * 10 + x % 10;
                x = x / 10;
            }
            if (temp < 0)
                new_number = -new_number;
            if (new_number > Int32.MaxValue || new_number < Int32.MinValue)
                return 0;
            else
                number = (int)new_number;

            return number;
        }

        //converting the int to string and then reversing the string and converting to int
        public int ReverseString(int x)
        {
            string str = new string(x.ToString().Trim('-').Reverse().ToArray());
            bool tryInt32 = int.TryParse(str, out int intValue);
            return tryInt32 ? x.ToString().Contains("-") ? intValue * -1 : intValue : 0;
        }
    }
}
