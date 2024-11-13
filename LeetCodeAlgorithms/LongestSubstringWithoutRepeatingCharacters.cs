namespace LeetCodeAlgorithms
{
    internal class LongestSubstringWithoutRepeatingCharacters
    {
        /* Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.*/
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int max = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!dict.ContainsKey(c))
                {
                    dict.Add(c, i);
                    max = Math.Max(dict.Count, max);
                }
                else
                {
                    i = dict[c];
                    dict.Clear();
                }
            }
            return max;
        }
    }
}

//Time complexity: O(m + n) Space complexity: O(1)