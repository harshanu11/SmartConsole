using System;
using System.IO;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class ArrayTest
    {
        [Fact]
        public void TwoDArrayTest()
        {
            int[,] arr = new int[3, 3];
            int input = 1;
            // load data 
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    arr[i1, j1] = input++;
                }
            }
            // retreave data
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
        public void JaggedArrayTest()
        {
            int[][] arr = new int[3][];
            int input = 1;
            // load data
            for (int i1 = 0; i1 < 3; i1++)
            {
                arr[i1] = new int[] { input, input + 1, input + 2 };
                input += 2;
            }
            // retreave data 
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    Console.Write(arr[i1][j1] + " ");
                }
                Console.WriteLine("\n");
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
