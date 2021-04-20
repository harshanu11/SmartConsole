using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartConsoleTest.Program
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
