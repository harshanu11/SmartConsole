using System;
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
			Assert.Equal(9,arr.Length);
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
				left_to_right += arr[i][ j];
				right_to_left += arr[k][ l];
				i++;
				j++;
				k++;
				l--;
			}

		}

		[Fact]
		public void MethodArr()
		{
			int[] arr = new int[] { -59, -36, -13, 1, -53, -92, -2, -96, -54, -75 };

			long minAbs = 999999999;
			Array.Sort(arr);
		}
	}
}
