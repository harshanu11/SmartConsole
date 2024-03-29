﻿using System.Diagnostics;
using CollectionTest;
using System;
using System.Numerics;
using System.Text.RegularExpressions;
using Xunit;

namespace Program
{
    public class ReadyToUse
    {
        [Fact]
        public void VeryLargeBinToDec()
        {
            string value = "100000101";
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }
            BinToDec("10101");
        }

        public static BigInteger BinToDec(string value)
        {
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;
            BigInteger max = 0;
            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                if (c == '1')
                {
                    res = BigInteger.Parse(res.ToString() + "1");
                    if (res > max)
                        max = res;
                }
                else
                {
                    res = BigInteger.Parse(res.ToString() + "0");
                    if (res > max)
                        max = res;
                }
            }

            return max;
        }
        public static void AllReadyToUse()
        {
            Debug.WriteLine(Convert.ToString(100, toBase: 2));//1100100
            Debug.WriteLine(Convert.ToString(100, toBase: 8));//144
            Debug.WriteLine(Convert.ToString(100, toBase: 10));//100
            Debug.WriteLine(Convert.ToString(100, toBase: 16));//64
        }
        [Fact]
        public void Palandrom()
        {
            
            Assert.True(IsPalindrome("A man, a plan, a canal: Panama"));// witth regex firlter replace
            Assert.Equal(1, CheckPalandromStr("abas7saba"));
            Assert.Equal(0, CheckPalandromStr("abas7seaba"));
            Assert.True(CheckPalandromInt(12321));
        }
        public static bool IsPalindrome(string s)
        {
            bool yes = true;

            Regex rg = new Regex("[^a-zA-Z0-9]");

            s = rg.Replace(s.ToUpper(), "");
            //Debug.WriteLine(s);

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                { yes = false; }
            }

            return yes;
        }

        private int CheckPalandromStr(string palan)
        {

            int myChecker = 0;
            for (int i = 0; i < palan.Length / 2; i++)
            {
                if (palan[i] == palan[palan.Length - 1 - i])
                {
                    myChecker += 1;
                }
            }

            if (myChecker == palan.Length / 2)
                return 1;
            else
                return 0;

        }
        private bool CheckPalandromInt(int palan)
        {
            int original = palan;
            int reverse = 0;
            while (palan != 0)
            {
                reverse = 10 * reverse + palan % 10;
                palan /= 10;
            }
            return reverse == original;

        }
        [Fact]
        public void Factorial()
        {
            int res = 1;
            for (int i = 0; i < 10; i++)
            {
                res *= i;
            }
            // res;


        }
        [Fact]
        public void Armstrong()
        {
            // 1 * 1 * 1 + 5 * 5 * 5 + 3 * 3 * 3 = 153

        }
        [Fact]
        public void bubbleSortTest()
        {

            bubbleSort(new int[] { 1 });
        }
        public static void bubbleSort(int[] numbers) //n^2
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = numbers.Length - 1; j > i; j--)
                {
                    if (numbers[j] < numbers[j - 1])
                    { swap(numbers, j, j - 1); }
                }
            }
            Debug.WriteLine(string.Join(",", new int[] { 20, 12, 45, 19, 91, 55 }));
        }
        public static void swap(int[] array, int from, int to)
        {
            int temp = array[from];
            array[from] = array[to];
            array[to] = temp;
        }

        [Fact]
        public void mergesortTest() //n^2 DivideNconquer
        {

            int[] input = { 87, 57, 370, 110, 90, 610, 02, 710, 140, 203, 150 };
            mergesort(input, 0, input.Length - 1);
        }


        private static void mergesort(int[] input, int start, int end)
        {

            // break problem into smaller structurally identical problems
            int mid = (start + end) / 2;
            if (start < end)
            {
                mergesort(input, start, mid);
                mergesort(input, mid + 1, end);
            }

            // merge solved pieces to get solution to original problem
            int i = 0, first = start, last = mid + 1;
            int[] tmp = new int[end - start + 1];




            while (first <= mid && last <= end)
            {
                tmp[i++] = input[first] < input[last] ? input[first++] : input[last++];
            }
            while (first <= mid)
            {
                tmp[i++] = input[first++];
            }
            while (last <= end)
            {
                tmp[i++] = input[last++];
            }
            i = 0;
            while (start <= end)
            {
                input[start++] = tmp[i++];
            }
        }
        public int BinarySearchFast1(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;
                if (nums[mid] == target)
                { return mid; }

                else if (nums[mid] > target)
                {
                    right = right - 1;
                }
                else
                {
                    left = left + 1;
                }
            }
            return -1;
        }
        public int BinarySearchFast2(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;
                if (nums[mid] == target)
                { return mid; }

                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
        [Fact]
        public void RepetedCharTest() 
        {

            String input = "Today is Monday"; //count number of "a" on this String.
            //counting occurrence of character with loop
            int charCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a')
                {
                    charCount++;
                }
            }
            Debug.WriteLine("count of character 'a' " + charCount);

            //a more elegant way of counting occurrence of character in String using foreach loop
            charCount = 0; //resetting character count
            var CharArray = input.ToCharArray();
            for (int ch = 0; ch < CharArray.Length; ch++)
            {
                if (CharArray[ch] == 'a')
                {
                    charCount++;
                }
            }
            Debug.WriteLine("count of character 'a' " + charCount);
        }
        [Fact]
        public void FirstNonRepetedCharTest() 
        {
            string str = "geeksforgeeks";
            int index = firstNonRepeating(str);

            Debug.WriteLine(index == -1 ? "Either " + "all characters are repeating or string " +
            "is empty" : "First non-repeating character"
            + " is " + str[index]);

        }
        static int NO_OF_CHARS = 256;
        static char[] count = new char[NO_OF_CHARS];

        /* calculate count of characters  
        in the passed string */
        static void getCharCountArray(string str)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        /* The method returns index of first non-repeating 
        character in a string. If all characters are  
        repeating then returns -1 */
        static int firstNonRepeating(string str)
        {
            getCharCountArray(str);
            int index = -1, i;

            for (i = 0; i < str.Length; i++)
            {
                if (count[str[i]] == 1)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public string ToLowerCase(string s)
        {
            char[] c = new char[s.Length];
            if (s.Length > 0)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (char.IsUpper(s[i]))
                    {
                        c[i] = (char)(s[i] + 32);
                    }
                    else
                    {
                        c[i] = s[i];
                    }
                }
                s = new String(c);
                Debug.WriteLine(s);
            }
            return s;
        }

        [Fact]
        public void TwoPointerTest()
        {
            string s = "sdfsf"; string t="sfsf";
            bool response = true;

            int sPoint = s.Length - 1;
            int tPoint = t.Length - 1;

            int sSkip = 0;
            int tSkip = 0;

            while (sPoint >= 0 || tPoint >= 0)
            {
                while (sPoint >= 0)
                {
                    if (s[sPoint] == '#')
                    {
                        sSkip++;
                        sPoint--;
                    }
                    else if (sSkip > 0)
                    {
                        sPoint--;
                        sSkip--;
                    }
                    else
                    {
                        break;
                    }
                }
                while (tPoint >= 0)
                {
                    if ('#' == t[tPoint])
                    {
                        tSkip++;
                        tPoint--;
                    }
                    else if (tSkip > 0)
                    {
                        tPoint--;
                        tSkip--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (sPoint >= 0 && tPoint >= 0 && s[sPoint] != t[tPoint])
                {
                    //return false;
                }
                if ((sPoint >= 0) != (tPoint >= 0))
                {
                   // return false;
                }
                tPoint--;
                sPoint--;

            }


           // return true;
        }
        [Fact]
        public void SlowFastPointerTest() {
            LLNode head = new LLNode(5) ;
            if (head == null) { 
               // return false;
            }

            LLNode Fast = head.nextNode;
            LLNode Slow = head;

            while (Slow != Fast)
            {
                if (Fast == null || Fast.nextNode == null) { }
                break;//return false;
                Slow = Slow.nextNode;
                Fast = Fast.nextNode.nextNode;
            }
        }
    }
}
