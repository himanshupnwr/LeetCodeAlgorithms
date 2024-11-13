namespace LeetCodeAlgorithms
{
    internal class ContainerWithMostWater
    {
        /*You are given an integer array height of length n. 
        There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

        Find two lines that together with the x-axis form a container, such that the container contains the most water.

        Return the maximum amount of water a container can store.
        Input: height = [1,8,6,2,5,4,8,3,7]
        Output: 49
        Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. 
        In this case, the max area of water (blue section) the container can contain is 49.
         */

        //Solution
        //Two Pointer approach

        //Time complexity:
        //The algorithm runs in (O(n)) time, where(n) is the number of elements in the height array.
        //This is because we only pass through the array once with the two pointers.

        //Space complexity:
        //The space complexity is (O(1)) since we use a constant amount of extra space for variables(like pointers
        //and area calculations) regardless of the input size.

        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int maxArea = 0;

            while (left < right)
            {
                int currentArea = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, currentArea);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }
    }
}
