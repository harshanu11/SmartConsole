using CollectionTest;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Program
{
    public class HackerRank
    {
        [Fact]
        public void SumOfJaggedDiagnolArryTest()
        {

            int[][] arr = new int[3][];
            int input = 1;
            for (int i1 = 0; i1 < 3; i1++)
            {
                arr[i1] = new int[] { input, input + 1, input + 2 };
                input += 2;
            }

            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    Console.Write(arr[i1][j1] + " ");
                }

                Console.WriteLine("\n");
            }

            int right_to_left = 0;
            int left_to_right = 0;
            int row = arr.Length;
            int col = arr.Length;
            int i = 0, j = 0, k = 0, l = arr.Length - 1;
            while (i < row && j < col && k < row && l >= 0)
            {
                left_to_right += arr[i][j];
                right_to_left += arr[k][l];
                i++;
                j++;
                k++;
                l--;
            }

            Console.WriteLine(right_to_left);
            Console.WriteLine(left_to_right);
            Console.WriteLine(Math.Abs(left_to_right - right_to_left));
            Assert.Equal(0, Math.Abs(left_to_right - right_to_left));
        }
        [Fact]
        public void LowestCommonAncestorTest()
        {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(4);
            nums.Insert(2);
            nums.Insert(3);
            nums.Insert(1);
            nums.Insert(7);
            nums.Insert(6);
            var result = lca(nums.root, 1, 7);
            Assert.Equal(4, result.Data);
        }
        [Fact]
        public void JumpingOnCloudTest()
        {
            int input = 0;
            string str = "";
            Console.WriteLine(CalculateJump(7, "0 0 1 0 0 1 0"));
            Console.WriteLine(CalculateJump(7, "0 0 0 0 1 0"));
            Assert.Equal(4, CalculateJump(7, "0 0 1 0 0 1 0"));
            Assert.Equal(3, CalculateJump(7, "0 0 0 0 1 0"));
        }
        [Fact]
        public void BalanceBracketTest()
        {
            string str = "";
            str = "{[()]}";
            Console.WriteLine(BalanceBracket(str));
            Assert.Equal("YES", BalanceBracket(str));
            str = "{[(]}}"; Console.WriteLine(BalanceBracket(str));
            Assert.Equal("NO", BalanceBracket(str));
            str = "{{[[(())]]}}"; Console.WriteLine(BalanceBracket(str));
            Assert.Equal("YES", BalanceBracket(str));

        }
        [Fact]
        public void NoOfValleyTest()
        {
            int count = 8;
            string str = "UDDDUDUU";
            Assert.Equal(1, NoOfValley(count, str));
        }
        [Fact]
        public void NoOfSocksTest()
        {
            int n = 9;
            int[] arr = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            HashSet<int> hs = new HashSet<int>();
            int numOfPair = 0;

            for (int i = 0; i < 9; i++)
            {
                if (!hs.Contains(arr[i])) { hs.Add(arr[i]); }
                else
                {
                    numOfPair++;
                    hs.Remove(arr[i]);
                }

            }
            Console.WriteLine(numOfPair);
            Assert.Equal(3, numOfPair);
        }
        [Fact]
        public void MinAbsDifferenceTest()
        {
            int arrLength = 10;
            int[] arr = new int[] { -59, -36, -13, 1, -53, -92, -2, -96, -54, -75 };

            long minAbs = 999999999;
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                long currentAbs = Math.Abs(arr[i] - arr[i + 1]);
                minAbs = Math.Min(minAbs, currentAbs);
            }
            Console.Write(minAbs);
            Assert.Equal(1, minAbs);

        }
        public static TreeNode lca(TreeNode root, int v1, int v2)
        {
            if (v1 > root.Data && v2 > root.Data)
            {
                return lca(root.Right, v1, v1);
            }
            if (v1 < root.Data && v2 < root.Data)
            {
                return lca(root.Left, v1, v2);
            }
            return root;
        }

        public static int CalculateJump(int input, string str)
        {
            double[] arr = str.Split(' ').Select(s => Convert.ToDouble(s)).ToArray();
            int i = 0;
            int inc = 0;
            while (i < arr.Length - 1)
            {
                if (i + 1 == arr.Length - 1 || arr[i + 2] == 1)
                {
                    i++;
                    inc++;
                }
                else
                {
                    i += 2;
                    inc++;
                }
            }
            return inc;
        }
        public static string BalanceBracket(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == '{' || str[i] == '(' || str[i] == '[')
                {
                    stack.Push(str[i]);
                }
                else
                {
                    if (stack.Count == 0) { return "NO"; }
                    else
                    {
                        char pop = stack.Pop();
                        if (str[i] == '}' && pop == '{') { return "YES"; }
                        if (str[i] == ']' && pop == '[') { return "YES"; }
                        if (str[i] == ')' && pop == '(') { return "YES"; }
                    }
                }
            }
            if (stack.Count == 0) { return "YES"; }
            else { return "NO"; }
        }

        public int NoOfValley(int count, string str)
        {
            int valley = 0;
            int increment = 0;
            for (int i = 0; i < count; i++)
            {
                if (str[i] == 'U')
                {
                    if (increment == -1)
                    {
                        valley++;
                    }

                    increment++;
                }
                else if (str[i] == 'D')
                {
                    increment--;
                }
            }

            return valley;
        }
    }
}
