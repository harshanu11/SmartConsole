using System.Collections.Generic;
namespace SmartConsoleTest
{
    public class CollectionTest
    {
        public void InitilizeArr()
        {

            bool[] strArr = new bool[5];
            string[] strArr1 = new string[] { "ja", "tu" };
            string[] strArr2 = { "ja", "tu" };
        }
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

        public void StackProblem()
        {
            Stack<string> bracketStack = new Stack<string>();

            bracketStack.Push("{");
            string pop = bracketStack.Pop();
        }
        public void HashSet()
        {
            HashSet<int> my_first_hashSet = new HashSet<int>();

            if (my_first_hashSet.Contains(9))
            {
                my_first_hashSet.Remove(9);
            }
            else
            {
                my_first_hashSet.Add(9);
            }

        }

    }
}
