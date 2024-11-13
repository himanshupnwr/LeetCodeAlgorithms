using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodeAlgorithms
{
    internal class StringToInteger
    {
        //Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer.
        //The algorithm for myAtoi(string s) is as follows:
        //Whitespace: Ignore any leading whitespace(" ").
        //Signedness: Determine the sign by checking if the next character is '-' or '+',
        //assuming positivity if neither present.
        //Conversion: Read the integer by skipping leading zeros until a non-digit character
        //is encountered or the end of the string is reached.If no digits were read, then the result is 0.
        //Rounding: If the integer is out of the 32-bit signed integer range [-231, 231 - 1],
        //then round the integer to remain in the range. Specifically, integers less than -231 should be rounded to -231,
        //and integers greater than 231 - 1 should be rounded to 231 - 1

        //Input: s = "42" Output: 42
        //Input: s = " -042" Output: -42
        //Input: s = "1337c0d3" Output: 1337

        public int MyAtoi(string s)
        {
            s = s.Trim();
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int i = 0, num = 0, sign = 1;

            if (s[0] == '+' || s[0] == '-')
            {
                sign = (s[0] == '-') ? -1 : 1;
                i++;
            }

            while (i < s.Length && Char.IsDigit(s[i]))
            {
                //check from chatgpt what this code does
                int digit = s[i] - '0';
                if (num > (Int32.MaxValue - digit) / 10)
                {
                    return (sign == 1) ? Int32.MaxValue : Int32.MinValue;
                }
                num = num * 10 + digit;
                i++;
            }

            return sign * num;
        }
    }
}
