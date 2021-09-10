using System.Diagnostics;
using System;
using System.Text;
using Xunit;

namespace CTCINs
{
    public class ArrayQus
    {
        #region Qus1
        /**
* Implement an algorithm to determine if a string has all unique characters. What
* if you cannot use additional data structures? (Assume string is ASCII based.)
*/
        internal bool hasUniqueChars(string str)
        {
            if (string.ReferenceEquals(str, null) || str.Length == 0)
            {
                return false;
            }
            if (str.Length > 256)
            {
                return false;
            }

            bool[] charSet = new bool[256];
            for (int i = 0; i < str.Length; ++i)
            {
                char ch = str[i];
                if (charSet[ch])
                {
                    return false;
                }
                else
                {
                    charSet[ch] = true;
                }
            }
            return true;
        }

        // use bit vector
        internal bool hasUniqueChars2(string str)
        {
            if (string.ReferenceEquals(str, null) || str.Length == 0)
            {
                return false;
            }
            if (str.Length > 256)
            {
                return false;
            }

            int bitVector = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                char ch = str[i];
                if ((bitVector & (1 << ch)) > 0)
                {
                    return false;
                }
                else
                {
                    bitVector |= (1 << ch);
                }
            }
            return true;
        }
        [Fact]
        public void hasUniqueChars1Test()
        {
            Assert.True(hasUniqueChars("123456"));
            Assert.False(hasUniqueChars("gsgdsg"));
        }
        [Fact]
        public void hasUniqueChars2Test()
        {
            Assert.True(hasUniqueChars2("123456"));
            Assert.False(hasUniqueChars2("gdfsgs"));
        }
        #endregion
        #region Qus2
        // Implement a function void reverse(char* str) in C
        // or C++ which reverses a null terminated string.
        unsafe void reverse(char* str)
        {
            if (str == null)
            {
                return;
            }

            char* end = str;
            while (Convert.ToBoolean(*end))
            {
                ++end;
            }
            --end;

            char tmp;
            while (str < end)
            {
                tmp = *str;
                *str = *end;
                *end = tmp;
                ++str;
                --end;
            }
        }

        [Fact]
        public unsafe void reverseTest()
        {
            //char*[] p ;
            //p = (char*[])(new char[]{'f'});
            //Assert.NotNull(reverse("123456"*));
        }
        #endregion
        #region Qus3
        /// <summary>
        /// Given two strings, write a method to decide if one is a permutation of the other.
        /// (Assume comparison is case-sensitive, space-significant, ASCII-based.)
        /// </summary>
        bool isPermutation(string s1, string s2)
        {
            if (string.ReferenceEquals(s1, null) && string.ReferenceEquals(s2, null))
            {
                return true;
            }
            if (string.ReferenceEquals(s1, null) || string.ReferenceEquals(s2, null))
            {
                return false;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }

            int[] charCount = new int[256];
            for (int i = 0; i < s1.Length; ++i)
            {
                ++charCount[s1[i]];
            }

            for (int i = 0; i < s2.Length; ++i)
            {
                if (--charCount[s2[i]] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        bool isPermutation2(string s1, string s2)
        {
            if (string.ReferenceEquals(s1, null) && string.ReferenceEquals(s2, null))
            {
                return true;
            }
            if (string.ReferenceEquals(s1, null) || string.ReferenceEquals(s2, null))
            {
                return false;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }

            char[] charArray1 = s1.ToCharArray();
            char[] charArray2 = s2.ToCharArray();
            Array.Sort(charArray1);
            Array.Sort(charArray2);
            return (new string(charArray1)).Equals(new string(charArray2));
        }

        [Fact]
        public void isPermutationTest()
        {
            Assert.False(isPermutation("123456", "1235456"));
            //Assert.False(isPermutation("gdfsgs"));
        }
        #endregion
        #region Qus4
        //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
        //	import static helpers.Printer.*;

        /// <summary>
        /// Write a method to replace all spaces in a string with'%20'. You may assume that
        /// the string has sufficient space at the end of the string to hold the additional
        /// characters, and that you are given the "true" length of the string. (Note: if
        /// implementing in Java, please use a character array so that you can perform this
        /// operation in place.)
        /// EXAMPLE
        /// Input:  "Mr John Smith    "
        /// Output: "Mr%20John%20Smith"
        /// </summary>
        internal static void replaceSpaces(char[] str, int length)
        {
            // 1st scan: count spaces
            int cnt = 0;
            foreach (char ch in str)
            {
                if (ch == ' ')
                {
                    ++cnt;
                }
            }

            // 2nd scan: replace spaces
            int p = length + 2 * cnt;
            str[p] = '\0'; //XXX
            --p;
            for (int i = length - 1; i >= 0; --i)
            {
                if (str[i] == ' ')
                {
                    str[p--] = '0';
                    str[p--] = '2';
                    str[p--] = '%';
                }
                else
                {
                    str[p--] = str[i];
                }
            }
        }

        //TEST----------------------------------
        //public static void Main(string[] args)
        //{
        //    char[] str = new char[] { 'a', 'b', ' ', 'c', ' ', 'd', '\0', '\0', '\0', '\0', '\0', '\0', '\0' };
        //    replaceSpaces(str, 6);
        //    printArray(str);
        //}
        [Fact]
        public void replaceSpacesTest()
        {
            char[] str = new char[] { 'a', 'b', ' ', 'c', ' ', 'd', '\0', '\0', '\0', '\0', '\0', '\0', '\0' };
            replaceSpaces(str, 6);
            Printer.printArray(str);
        }
        #endregion
        #region Qus5
        //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
        //	import static helpers.Printer.*;

        /// <summary>
        /// Implement a method to perform basic string compression using the counts of
        /// repeated characters. For example, the string aabcccccaaa would become
        /// a2blc5a3. If the "compressed" string would not become smaller than the original
        /// string, your method should return the original string.
        /// </summary>

        internal static string compress(string s)
        {
            if (string.ReferenceEquals(s, null) || s.Length == 0)
            {
                return s;
            }

            char prev = s[0];
            int cnt = 1;
            StringBuilder sb = new StringBuilder();
            sb.Append(prev);
            for (int i = 1; i < s.Length; ++i)
            {
                char curr = s[i];
                if (curr == prev)
                {
                    ++cnt;
                }
                else
                {
                    prev = curr;
                    sb.Append(cnt).Append(curr);
                    cnt = 1;
                }
            }
            sb.Append(cnt);

            return sb.ToString().Length >= s.Length ? s : sb.ToString();
        }

        //TEST----------------------------------
        //public static void Main(string[] args)
        //{
        //    println(compress("aabcccccaaa"));
        //    println(compress("aabbcc"));
        //    println(compress("aaaaaaaaaaaaaaaaaaaaa"));
        //    println(compress("abcdefg"));
        //    println(compress("a"));
        //}
        [Fact]
        public void CompressTest()
        {
            Debug.WriteLine(compress("aabcccccaaa"));
            Debug.WriteLine(compress("aabbcc"));
            Debug.WriteLine(compress("aaaaaaaaaaaaaaaaaaaaa"));
            Debug.WriteLine(compress("abcdefg"));
            Debug.WriteLine(compress("a"));
        }
        #endregion
        #region Qus6
        //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
        //	import static helpers.Printer.*;

        /// <summary>
        /// Given an image represented by an NxN matrix, where each pixel in
        /// the image is 4 bytes, write a method to rotate the image by 90
        /// degrees. Can you do this in place?
        /// </summary>
        // With extra space.
        internal static int[][] rotate(int[][] matrix)
        {
            int n = matrix.Length;
            //JAVA TO C# CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
            //ORIGINAL LINE: int[][] ret = new int[n][n];
            int[][] ret = RectangularArrays.RectangularIntArray(n, n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i][j] = matrix[n - 1 - j][i];
                }
            }
            return ret;
        }

        // In place.
        // Relation matrix[i][j] = matrix[n-1-j][i] holds.
        internal static void rotateInPlace(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n / 2; ++i)
            {
                for (int j = i; j < n - 1 - i; ++j)
                {
                    // save top
                    int tmp = matrix[i][j];
                    // left to top
                    matrix[i][j] = matrix[n - 1 - j][i];
                    // bottom to left
                    matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                    // right to bottom
                    matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                    // top to right
                    matrix[j][n - 1 - i] = tmp;
                }
            }
        }

        //TEST----------------------------------
        //public static void Main(string[] args)
        //{
        //    int[][] a = new int[][]
        //    {
        //    new int[] {1, 2, 3, 4, 5},
        //    new int[] {11, 22, 33, 44, 55},
        //    new int[] {5, 4, 3, 2, 1},
        //    new int[] {55, 44, 33, 22, 11},
        //    new int[] {6, 7, 8, 9, 0}
        //    };
        //    printArray(rotate(a));
        //    println();
        //    rotateInPlace(a);
        //    printArray(a);
        //}

        [Fact]
        public void rotateInPlaceTest()
        {
            int[][] a = new int[][]
            {
                new int[] {1, 2, 3, 4, 5},
                new int[] {11, 22, 33, 44, 55},
                new int[] {5, 4, 3, 2, 1},
                new int[] {55, 44, 33, 22, 11},
                new int[] {6, 7, 8, 9, 0}
            };
            Printer.printArray(rotate(a));
            Debug.WriteLine();
            rotateInPlace(a);
            Printer.printArray(a);
        }
        //Helper class added by Java to C# Converter:

        //----------------------------------------------------------------------------------------
        //	Copyright © 2007 - 2021 Tangible Software Solutions, Inc.
        //	This class can be used by anyone provided that the copyright notice remains intact.
        //
        //	This class includes methods to convert Java rectangular arrays (jagged arrays
        //	with inner arrays of the same length).
        //----------------------------------------------------------------------------------------
        internal static class RectangularArrays
        {
            public static int[][] RectangularIntArray(int size1, int size2)
            {
                int[][] newArray = new int[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }

                return newArray;
            }
        }

        #endregion
        #region Qus7
        //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
        //	import static helpers.Printer.*;

        /// <summary>
        /// Write an algorithm such that if an element in an MxN matrix is 0,
        /// its entire row and column are set to 0.
        /// </summary>

        // use boolean array
        internal static int[][] Zeros
        {
            set
            {
                bool[] rows = new bool[value.Length];
                bool[] cols = new bool[value[0].Length];

                // mark zero
                for (int i = 0; i < value.Length; ++i)
                {
                    for (int j = 0; j < value[0].Length; ++j)
                    {
                        if (value[i][j] == 0)
                        {
                            rows[i] = cols[j] = true;
                        }
                    }
                }

                // set zeros
                for (int i = 0; i < value.Length; ++i)
                {
                    for (int j = 0; j < value[0].Length; ++j)
                    {
                        if (rows[i] || cols[j])
                        {
                            value[i][j] = 0;
                        }
                    }
                }
            }
        }

        // use bit vector
        internal static int[][] Zeros2
        {
            set
            {
                long bitVecRows = 0;
                long bitVecCols = 0;

                // mark zero
                for (int i = 0; i < value.Length; ++i)
                {
                    for (int j = 0; j < value[0].Length; ++j)
                    {
                        if (value[i][j] == 0)
                        {
                            bitVecRows |= 1 << i;
                            bitVecCols |= 1 << j;
                        }
                    }
                }

                // set zeros
                for (int i = 0; i < value.Length; ++i)
                {
                    for (int j = 0; j < value[0].Length; ++j)
                    {
                        if ((bitVecRows & (1 << i)) != 0 || (bitVecCols & (1 << j)) != 0)
                        {
                            value[i][j] = 0;
                        }
                    }
                }
            }
        }

        //TEST----------------------------------
        public static void MakeZero()
        {
            int[][] a = new int[][]
            {
            new int[] {0, 2, 3, 4, 5},
            new int[] {1, 2, 3, 4, 5},
            new int[] {5, 4, 3, 0, 1},
            new int[] {5, 4, 3, 2, 1},
            new int[] {6, 7, 8, 9, 0}
            };
            Zeros2 = a;
            printArray(a);
        }

        public static void printArray(int[][] a)
        {
            foreach (int[] row in a)
            {
                foreach (int col in row)
                {
                    Console.Write(col + " ");
                }
                Debug.WriteLine();
            }
        }
        [Fact]
        public void ZerosTest()
        {
            MakeZero();
        }
        #endregion
        #region Qus8
        /// <summary>
        /// Assume you have a method isSubstring which checks if one word is a
        /// substring of another. Given two strings, si and s2, write code to check if s2 is
        /// a rotation of si using only one call to isSubstring (e.g.,"waterbottle" is a rotation
        /// of "erbottlewat").
        /// (Assume an empty string is a rotation of an empty string.)
        /// </summary>

        internal virtual bool isRotation(string s1, string s2)
        {
            if (string.ReferenceEquals(s1, null) || string.ReferenceEquals(s2, null))
            {
                return false;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }
            return isSubstring(s1 + s1, s2);
        }

        private bool isSubstring(string s1, string s2)
        {
            return s1.Contains(s2);
        }
        [Fact]
        public void IsRotationTest()
        {
            Assert.True(isRotation("waterbottle", "erbottlewat"));
            Assert.False(isRotation("waterbosttle", "erbottlewat"));
        }
        #endregion
    }
}
