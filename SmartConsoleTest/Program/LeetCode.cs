using System.Diagnostics;
using System;
using System.Collections.Generic;
using Xunit;

namespace Program
{
    public class LeetCode
    {
        //https://leetcode.com/problems/minimum-changes-to-make-alternating-binary-string/submissions/
        [Fact]
        public void MinOperationsTest()
        {
            //minFlipToMakeStringAlternate("10010100");
            MinOperations("10010100");

        }
        /// <summary>
        /// Longest Consecutive Subsequence  https://www.geeksforgeeks.org/longest-consecutive-subsequence/
        /// </summary>
        [Fact]
        public static void LongestConsecutiveSubsequenceTest()
        {
            int[] arr = { 1, 9, 3, 10, 4, 20, 2 };
            int n = arr.Length;

            Debug.WriteLine("Length of the Longest " +
                              "contiguous subsequence is " +
                              findLongestConseqSubseq(arr, n));

        }
        static int findLongestConseqSubseq(int[] arr,
                                   int n)
        {

            // Sort the array
            Array.Sort(arr);

            int ans = 0, count = 0;

            List<int> v = new List<int>();
            v.Add(10);

            // Insert repeated elements
            // only once in the vector
            for (int i = 1; i < n; i++)
            {
                if (arr[i] != arr[i - 1])
                    v.Add(arr[i]);
            }

            // Find the maximum length
            // by traversing the array
            for (int i = 0; i < v.Count; i++)
            {

                // Check if the current element is
                // equal to previous element +1
                if (i > 0 && v[i] == v[i - 1] + 1)
                    count++;
                else
                    count = 1;

                // Update the maximum
                ans = Math.Max(ans, count);
            }
            return ans;
        }
        public int MinOperations(string s)
        {

            char[] arr = s.ToCharArray();
            int index = 1;
            int count = 0;
            //11
            //116464646464646464
            while (index < arr.Length)
            {
                if (arr[index - 1] == arr[index])
                {
                    arr[index] = arr[index] == '0' ? '1' : '0';
                    count++;
                }
                index++;
            }

            return count;

        }

        // Utility method to
        // flip a character
        public static char flip(char ch)
        {
            return (ch == '0') ? '1' : '0';
        }

        // Utility method to get minimum flips
        // when alternate string starts with
        // expected char
        public static int getFlipWithStartingCharcter(String str,
                                                    char expected)
        {
            int flipCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                // if current character is not
                // expected, increase flip count
                if (str[i] != expected)
                    flipCount++;

                // flip expected character each time
                expected = flip(expected);
            }
            return flipCount;
        }

        // method return minimum flip to
        // make binary string alternate
        public static int minFlipToMakeStringAlternate(string str)
        {
            // return minimum of following two
            // 1) flips when alternate string starts with 0
            // 2) flips when alternate string starts with 1
            return Math.Min(getFlipWithStartingCharcter(str, '0'),
                    getFlipWithStartingCharcter(str, '1'));
        }
    }
}
