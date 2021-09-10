using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class ArrayTest
    {
        [Fact]
        public void TwoDArrayTest()
        {
            Debug.WriteLine("Start Now");

            int[,] twoDarr = new int[4, 5];
            // get length of array 
            int rowLength = twoDarr.GetLength(0);
            int ColLength = twoDarr.GetLength(1);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    twoDarr[i, j] = i * j;
                }
            }
            Debug.WriteLine("two d array is loaded");

            Debug.WriteLine("This is time to print it");

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(twoDarr[i, j] + " ");
                }
                Debug.WriteLine("");
            }

            Debug.WriteLine("Tow d array done");
            Debug.WriteLine("");


        }
        [Fact]
        public void JaggedArrayTest()
        {
            Debug.WriteLine("now start to jagged array");
            int[][] jaggedArray = new int[4][];

            for (int i = 0; i < 4; i++)
            {
                jaggedArray[i] = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    jaggedArray[i][j] = -1 * (i + j);
                }
            }
            var len0 =jaggedArray.GetLength(0);

            //Array.Sort(jaggedArray);
            Debug.WriteLine("Jagged Array loaded now");
            Debug.WriteLine("Time to read data form jagged array");


            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Debug.WriteLine(" ");
            }

            Debug.WriteLine("Jagged arr reading is done now");
        }

        [Fact]
        public void MethodArr()
        {
            #region Create
            Array stringArray = Array.CreateInstance(typeof(String), 6);
            int[] arr = new int[] { -59, -36, -13, 1, -53, -92, -2, -96, -54, -75 };
            int[] marks = new int[] { 99, 98, 92, 97, 95 };
            int[] arr_source_copy = { 1, 3, 4 }; int[] newArr = new int[4];
            string[] arr_temp = new string[] { "1", "2" };
            //string[] lenAndShift = Console.ReadLine().Split(' ');
            stringArray.SetValue("Mango", 0);
            stringArray.GetValue(0);
			char[][] board = new char[4][];
            int[,] mat = {
                            { 1, 2, 3, 4 },
                            { 5, 6, 7, 8 },
                            { 9, 10, 11, 12 },
                            { 13, 14, 15, 16 }
                         };

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
            string v1 = Array.Find(arr_Find,element => element.StartsWith("cam", StringComparison.Ordinal));
            var element = marks.ElementAt(2);
            SortingAlgo.BubbleSort(arr);

            #endregion

            #region Copy
            for (int i = 0; i < 4; i++)
            {
                board[i] = new char[4];
                Array.Fill(board[i], '.');
            }
            Array.Copy(arr_source_copy, 0, newArr, 0, 3);
            #endregion

            #region ConvertResize
            int[] Aint = Array.ConvertAll(arr_temp, c => (int)Char.GetNumericValue(c[0]));
            int[] arrInt = Array.ConvertAll(arr_temp, Int32.Parse);
            Array.Resize(ref arr_temp, 10);
            var convertToStr = string.Join("", new int[] { 1, 2 });
            string[] test = new string[2];
            test[0] = "Hello";
            test[1] = "World!";

            string result = String.Concat(test);// hello world
            var resJoin = String.Join("", test);//Hello World!
            resJoin = String.Join(",", test);//Hello ,World!
            #endregion

            #region Compare
            #endregion
            #region Find
            var data= Array.Find(test, x=>x== "Hello");// return Hello
            #endregion
        }

        
    }
}
