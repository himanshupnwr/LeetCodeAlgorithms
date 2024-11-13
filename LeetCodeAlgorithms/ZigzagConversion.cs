using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class ZigzagConversion
    {
        /*The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
         * (you may want to display this pattern in a fixed font for better legibility)

        P   A   H   N
        A P L S I I G
        Y   I   R

        And then read line by line: "PAHNAPLSIIGYIR"
        Write the code that will take a string and make this conversion given a number of rows:
        string convert(string s, int numRows);

        Example 1:
        Input: s = "PAYPALISHIRING", numRows = 3
        Output: "PAHNAPLSIIGYIR"

        Example 2:
        Input: s = "PAYPALISHIRING", numRows = 4
        Output: "PINALSIGYAHRPI"
        Explanation:
        P     I    N
        A   L S  I G
        Y A   H R
        P     I

        Example 3:
        Input: s = "A", numRows = 1
        Output: "A"
        */
        public string Convert(string inputString, int numRows)
        {
            if (numRows == 1) return inputString;

            List<StringBuilder> rows = new List<StringBuilder>(Math.Min(numRows, inputString.Length));
            for (int i = 0; i < Math.Min(numRows, inputString.Length); i++)
            {
                rows.Add(new StringBuilder());
            }

            int direction = -1;
            int currentRow = 0;

            foreach (char c in inputString)
            {
                rows[currentRow].Append(c);
                currentRow += (direction == -1) ? 1 : -1;

                if (currentRow == 0 || currentRow == numRows - 1)
                {
                    direction = -direction;
                }
            }

            StringBuilder result = new StringBuilder();
            foreach (StringBuilder row in rows)
            {
                result.Append(row);
            }

            return result.ToString();
        }
    }
}
