using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class BestTimeToBuyAndSellStock2
    {
        /*You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
        On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at any time. However, you can buy it then immediately sell it on the same day.

        -> Find and return the maximum profit you can achieve.
        Example 1:

        Input: prices = [7,1,5,3,6,4]
        Output: 7
        Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
        Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
        Total profit is 4 + 3 = 7.

        Example 2:

        Input: prices = [1,2,3,4,5]
        Output: 4
        Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
        Total profit is 4.

        Example 3:

        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.
        */

        static void Main(string[] args)
        {
            //MaxProfit([7, 1, 5, 3, 6, 4]);
            //MaxProfit([1, 2, 3, 4, 5]);
            //MaxProfit([7, 6, 4, 3, 1]);
            //MaxProfit([1, 2, 4, 1, 8, 9, 3, 7, 1]);
            MaxProfit([1, 2, 2, 2, 6]);
            MaxProfitOptimizedSyntax([1, 2, 2, 2, 6]);
        }

        public static int MaxProfit(int[] prices)
        {
            int max = 0;
            int totalMaxProfit = 0;
            int min = prices[0];
            int arrLength = prices.Length;

            for (int i = 1; i < arrLength; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }

                if (i < arrLength - 1 && prices[i + 1] > prices[i])
                {
                    max = prices[i+1];
                }

                if ((i == arrLength - 1 && max == prices[arrLength - 1]) || 
                    (i < arrLength - 1 && max > prices[i + 1]))
                {
                    totalMaxProfit = totalMaxProfit + (max - min);
                    min = prices[i];
                    max = prices[i];
                }
            }
            Console.WriteLine(totalMaxProfit);
            return totalMaxProfit;
        }

        public static int MaxProfitOptimizedSyntax(int[] prices)
        {
            int max = 0;
            int start = prices[0];
            int len = prices.Length;
            for (int i = 1; i < len; i++)
            {
                if (start < prices[i])
                {
                    max += prices[i] - start;
                }
                start = prices[i];
            }
            return max;
        }
    }
}
