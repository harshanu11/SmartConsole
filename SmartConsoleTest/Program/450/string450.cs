using System;
using Xunit;

namespace DSA450
{
    public class string450 {
        #region Reverse a String
        public void ReverseString(char[] s)
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
            Console.WriteLine(new String(s));
        }
        #endregion
        #region Check whether a String is Palindrome or not
        //public void isPalindrome(char str[])
        //{
        //    // Start from leftmost and rightmost corners of str
        //    int l = 0;
        //    int h = strlen(str) - 1;

        //    // Keep comparing characters while they are same
        //    while (h > l)
        //    {
        //        if (str[l++] != str[h--])
        //        {
        //            printf("%s is not a palindrome\n", str);
        //            return;
        //        }
        //    }
        //    //printf("%s is a palindrome\n", str);
        //}

        // Driver program to test above function
        //int main()
        //{
        //    isPalindrome("abba");
        //    isPalindrome("abbccbba");
        //    isPalindrome("geeks");
        //    return 0;
        //}
        #endregion
        #region Find Duplicate characters in a string
        static int NO_OF_CHARS = 256;

        /* Fills count array with
        frequency of characters */
        static void fillCharCounts(String str,
                                    int[] count)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        /* Print duplicates present in
        the passed string */
        static void printDups(String str)
        {

            // Create an array of size 256 and
            // fill count of every character in it
            int[] count = new int[NO_OF_CHARS];
            fillCharCounts(str, count);

            for (int i = 0; i < NO_OF_CHARS; i++)
                if (count[i] > 1)
                    Console.WriteLine((char)i + ", " +
                                "count = " + count[i]);
        }

        [Fact]
        public void printDupsTest()
        {
            String str = "test string";
            printDups(str);
        }
        #endregion
        #region Write a Code to check whether one string is a rotation of another
        /* Function checks if passed strings
(str1 and str2) are rotations of
each other */
        static bool areRotations(String str1,
                                    String str2)
        {

            // There lengths must be same and
            // str2 must be a substring of
            // str1 concatenated with str1.
            return (str1.Length == str2.Length)
                && ((str1 + str1).IndexOf(str2)
                                        != -1);
        }

        [Fact]
        public static void areRotationsTest()
        {
            String str1 = "FGABCDE";
            String str2 = "ABCDEFG";

            if (areRotations(str1, str2))
                Console.Write("Strings are"
                + " rotation s of each other");
            else
                Console.Write("Strings are "
            + "not rotations of each other");
        }
        #endregion
        #region Write a Program to check whether a string is a valid shuffle of two strings or not

        // length of result string should be equal to sum of two strings
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

        // this method converts the string to char array 
        // sorts the char array
        // convert the char array to string and return it
        static String sortString(String str)
        {

            char[] charArray = str.ToCharArray();
            Array.Sort(charArray);

            // convert char array back to string
            str = new string(charArray);

            return str;
        }

        // this method compares each character of the result with 
        // individual characters of the first and second string
        static bool shuffleCheck(String first, String second, String result)
        {

            // sort each string to make comparison easier
            first = sortString(first);
            second = sortString(second);
            result = sortString(result);

            // variables to track each character of 3 strings
            int i = 0, j = 0, k = 0;

            // iterate through all characters of result
            while (k != result.Length)
            {

                // check if first character of result matches
                // with first character of first string
                if (i < first.Length && first[i] == result[k])
                    i++;

                // check if first character of result matches
                // with the first character of second string
                else if (j < second.Length && second[j] == result[k])
                    j++;

                // if the character doesn't match
                else
                {
                    return false;
                }

                // access next character of result
                k++;
            }

            // after accessing all characters of result
            // if either first or second has some characters left
            if (i < first.Length || j < second.Length)
            {
                return false;
            }

            return true;
        }

        public static void main(String[] args)
        {

            String first = "XY";
            String second = "12";
            String[] results = { "1XY2", "Y1X2", "Y21XX" };

            // call the method to check if result string is
            // shuffle of the string first and second
            //for (String result : results)
            //{
            //    if (checkLength(first, second, result) == true && shuffleCheck(first, second, result) == true)
            //    {
            //        System.out.println(result + " is a valid shuffle of " + first + " and " + second);
            //    }
            //    else
            //    {
            //        System.out.println(result + " is not a valid shuffle of " + first + " and " + second);
            //    }
            //}
        }
        #endregion
    }
}
