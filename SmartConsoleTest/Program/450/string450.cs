using System;
using System.Diagnostics;
using Xunit;

namespace DSA450
{
    public class string450 {
        #region Reverse a String
        string ReverseString(char[] s)
        {
            int a_pointer = 0;
            int b_pointer = s.Length - 1;

            while (a_pointer <= b_pointer)
            {
                char temp = s[b_pointer];
                s[b_pointer] = s[a_pointer];
                s[a_pointer] = temp;
                a_pointer++;
                b_pointer--;
            }
            return new String(s);
        }
        [Fact]
        public void ReverseStringTest() 
        {
            string input = "Eds";
            var op = ReverseString(input.ToCharArray());
        }
        #endregion
        #region Check whether a String is Palindrome or not
        public bool isPalindrome(string str)
        {
            int l = 0;
            int h = str.Length - 1;

            while (h > l)
            {
                if (str[l++] != str[h--])
                {
                    //printf("%s is not a palindrome\n", str);
                    return false;
                }
            }
            //printf("%s is a palindrome\n", str);
            return true;
        }
        [Fact]
        public void isPalindromeTest()
        {
            var ans = false;
           ans=isPalindrome("abba");
           ans=isPalindrome("abbccbba");
           ans=isPalindrome("geeks");
            
        }
        #endregion
        #region Find Duplicate characters in a string
        static int NO_OF_CHARS = 256;
        static void fillCharCounts(String str,int[] count)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        static void printDups(String str)
        {
            int[] count = new int[NO_OF_CHARS];
            fillCharCounts(str, count);
            for (int i = 0; i < NO_OF_CHARS; i++)
                if (count[i] > 1)
                    Debug.WriteLine((char)i + ", " + "count = " + count[i]);

        }

        [Fact]
        public void printDupsTest()
        {
            String str = "test string";
            printDups(str);
        }
        #endregion
        #region Write a Code to check whether one string is a rotation of another
        static bool areRotations(String str1,String str2)
        {
            return (str1.Length == str2.Length) && ((str1 + str1).IndexOf(str2) != -1);
        }

        [Fact]
        public static void areRotationsTest()
        {
            String str1 = "FGABCDE";
            String str2 = "ABCDEFG";

            if (areRotations(str1, str2)) Debug.Write("Strings are" + " rotation s of each other");
            else
                Debug.Write("Strings are " + "not rotations of each other");
        }
        #endregion
        #region Write a Program to check whether a string is a valid shuffle of two strings or not
        static bool checkLength(String first, String second, String result)
        {
            if (first.Length + second.Length != result.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static String sortString(String str)
        {

            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);
            str = new string(charArray);
            return str;
        }
        static bool shuffleCheck(String first, String second, String result)
        {
            first = sortString(first);
            second = sortString(second);
            result = sortString(result);
            int i = 0, j = 0, k = 0;
            while (k != result.Length)
            {
                if (i < first.Length && first[i] == result[k])
                    i++;
                else if (j < second.Length && second[j] == result[k])
                    j++;
                else
                {
                    return false;
                }
                k++;
            }
            if (i < first.Length || j < second.Length)
            {
                return false;
            }
            return true;
        }
        [Fact]
        public void shuffleCheckTest()
        {
            String first = "XY";
            String second = "12";
            String[] results = { "1XY2", "Y1X2", "Y21XX" };
            for (int i = 0; i < results.Length; i++)
            {
                if (checkLength(first, second, results[i]) == true && shuffleCheck(first, second, results[i]) == true)
                {
                    Debug.WriteLine(results[i] + " is a valid shuffle of " + first + " and " + second);
                }
                else
                {
                    Debug.WriteLine(results[i] + " is not a valid shuffle of " + first + " and " + second);
                }
            }
        }
        #endregion
    }
}
