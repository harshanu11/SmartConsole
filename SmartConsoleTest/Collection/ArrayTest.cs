using System;
using System.IO;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class ArrayTest
    {
        [Fact]
        public void InitilizeArr()
        {

            bool[] strArr = new bool[5];
            string[] strArr1 = new string[] { "ja", "tu" };
            string[] strArr2 = { "ja", "tu" };
        }
        [Fact]
        public void TypsOfArr()
        {
            int[] arr = new int[] { 5, 7 };
            int[][] jaggedArr = new int[3][];
            int[,] twoDArr = new int[3, 3];
            jaggedArr[0] = new int[3] { 1, 2, 3 };
            jaggedArr[1] = new int[3] { 4, 5, 6 };
            jaggedArr[2] = new int[3] { 7, 8, 9 };
            int left_to_right = 0;
            int reght_to_left = 0;
            int row = jaggedArr.Length;
            int columns = jaggedArr[0].Length;
            int i = 0;
            int j = 0;
            int k = 0;
            int l = jaggedArr.Length - 1;
            while (i < row && j < columns && k < row && l >= 0)
            {
                left_to_right += jaggedArr[i][j];
                reght_to_left += jaggedArr[k][l];
                i++;
                j++;
                k++;
                l--;
            }

            Console.WriteLine(Math.Abs(left_to_right - reght_to_left));

        }
        [Fact]
        public void TwoDArrayLengthTest()
        {
            int[,] arr = new int[3, 3];
            int input = 1;
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    arr[i1, j1] = input++;
                }
            }
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    Console.Write(arr[i1, j1] + " ");
                }
                Console.WriteLine("\n");
            }
            Assert.Equal(9, arr.Length);
        }
        [Fact]
        public void TwoDArrayTest()
        {
            int[,] arr = new int[3, 3];
            int input = 1;
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    arr[i1, j1] = input++;
                }
            }
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    Console.Write(arr[i1, j1] + " ");
                }
                Console.WriteLine("\n");
            }

        }
        [Fact]
        public void JaggedArrayTest()
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

        }

        [Fact]
        public void MethodArr()
        {
            #region Create
            Array stringArray = Array.CreateInstance(typeof(String), 6);
            int[] arr = new int[] { -59, -36, -13, 1, -53, -92, -2, -96, -54, -75 };
            int[] marks = new int[] { 99, 98, 92, 97, 95 };
            int[] arr_source_copy = { 1, 3, 4 };
            int[] newArr = new int[3];
            string[] arr_temp = new string[] { "1", "2" };

            #endregion

            #region Set
            stringArray.SetValue("Mango", 0);
            #endregion

            #region SortReverse
            Array.Sort(arr);
            Array.Sort(arr, 2, 6);
            Array.Reverse(arr);
            #endregion

            #region FindSerch
            int serchIndex = Array.IndexOf(marks, 97);
            int index = Array.BinarySearch(arr, 0, arr.Length, -96);
            string[] arr_Find = new string[] { "cam", "camcam" };
            string v1 = Array.Find(arr_Find,
            element => element.StartsWith("cam", StringComparison.Ordinal));
            var element = marks.ElementAt(2);

            #endregion

            #region Copy
            Array.Copy(arr_source_copy, 0, newArr, 0, 3);
            #endregion

            #region ConvertResize
            int[] arrInt = Array.ConvertAll(arr_temp, Int32.Parse);
            Array.Resize(ref arr_temp, 10);
            var convertToStr = string.Join("", new int[] { 1, 2 });
            #endregion

        }
    }
}
