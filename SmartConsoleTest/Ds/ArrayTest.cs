using System;
using Xunit;

namespace CollectionTest
{
    public class ArrayTest
    {
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

	}
}
