using CollectionTest;
using System;
using Xunit;
using static CollectionTest.BinarySearchTree;

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

        public static Node lca(Node root, int v1, int v2)
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
    }
}
