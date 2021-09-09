using CollectionTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class DsAlgo450
    {
        #region 1array
        #region rvereseArray
        static void rvereseArray(int[] arr, int start, int end)
        {
            int temp;
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }
        [Fact]
        public void rvereseArrayTest()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6 };
            rvereseArray(arr, 0, 5);
            Console.Write("Reversed array is \n");
        }
        #endregion
        #region Find the maximum and minimum element in an array
        class Pair
        {
            public int min;
            public int max;
        }

        static Pair getMinMax1(int[] arr, int n)
        {
            Pair minmax = new Pair();
            int i;
            if (n == 1)
            {
                minmax.max = arr[0];
                minmax.min = arr[0];
                return minmax;
            }
            if (arr[0] > arr[1])
            {
                minmax.max = arr[0];
                minmax.min = arr[1];
            }
            else
            {
                minmax.max = arr[1];
                minmax.min = arr[0];
            }

            for (i = 2; i < n; i++)
            {
                if (arr[i] > minmax.max)
                {
                    minmax.max = arr[i];
                }
                else if (arr[i] < minmax.min)
                {
                    minmax.min = arr[i];
                }
            }
            return minmax;
        }

        [Fact]
        public void getMinMaxTest()
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = getMinMax1(arr, arr_size);
            Console.Write("Minimum element is {0}",
                                    minmax.min);
            Console.Write("\nMaximum element is {0}",
                                        minmax.max);
        }
        #endregion
        #region Find the "Kth" max and min element of an array 
        internal virtual void swap(int[] arr, int l, int r)
        {
            int tmp = arr[l];
            arr[l] = arr[r];
            arr[r] = tmp;
        }

        internal virtual int randomPartition(int[] arr, int l, int r)
        {
            int n = r - l + 1;
            Random rd = new Random();
            int pivot = rd.Next(n);
            swap(arr, l + pivot, r);
            return partition(arr, l, r);
        }

        internal virtual int kthSmallest(int[] arr, int l, int r, int k)
        {
            // If k is smaller than number of elements in array
            if (k > 0 && k <= r - l + 1)
            {
                // find a position for random partition
                int pos = randomPartition(arr, l, r);

                // if this pos gives the kth smallest element, then return
                if (pos - l == k - 1)
                {
                    return arr[pos];
                }

                // else recurse for the left and right half accordingly
                if (pos - l > k - 1)
                {
                    return kthSmallest(arr, l, pos - 1, k);
                }
                return kthSmallest(arr, pos + 1, r, k - pos + l - 1);
            }

            return int.MaxValue;
        }

        internal virtual int partition(int[] arr, int l, int r)
        {
            int x = arr[r], i = l;
            for (int j = l; j <= r - 1; j++)
            {
                if (arr[j] <= x)
                {
                    swap(arr, i, j);
                    i++;
                }
            }
            swap(arr, i, r);
            return i;
        }

        #endregion
        #region Given an array which consists of only 0, 1 and 2. Sort the array without using any sorting algo
        public static void sort012(int[] a, int n)
        {
            int low = 0, high = n - 1, mid = 0;
            while (mid <= high)
            {
                if (a[mid] == 0)
                {
                    int temp = a[low];
                    a[low] = a[mid];
                    a[mid] = temp;
                    low++;
                    mid++;
                }
                else if (a[mid] == 1)
                {
                    mid++;
                }
                else
                {
                    int temp = a[mid];
                    a[mid] = a[high];
                    a[high] = temp;
                    high--;
                }
            }
        }

        #endregion
        #region Move all the negative elements to one side of the array 
        static void rearrange(int[] arr, int n)
        {
            int j = 0, temp;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] < 0)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }
        }

        [Fact]
        public void rearrangeNegative()
        {
            int[] arr = { -1, 2, -3, 4, 5, 6, -7, 8, 9 };
            int n = arr.Length;

            rearrange(arr, n);
        }
        #endregion
        #endregion

        #region 2Bit Manipulation
        #region Count set bits in an integer
        internal virtual int setBits(int N)
        {
            int count = 0;
            while (N > 0)
            {
                N &= (N - 1);
                count++;
            }
            return count;
        }

        #endregion
        #region Find the two non-repeating elements in an array of repeating elements
        static void UniqueNumbers2(int[] arr, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = (sum ^ arr[i]);
            }
            // Bitwise & the sum with it's 2's Complement
            // Bitwise & will give us the sum containing
            // only the rightmost set bit
            sum = (sum & -sum);

            // sum1 and sum2 will contains 2 unique
            // elements elements initialized with 0 box
            // number xored with 0 is number itself
            int sum1 = 0;
            int sum2 = 0;

            // Traversing the array again
            for (int i = 0; i < arr.Length; i++)
            {

                // Bitwise & the arr[i] with the sum
                // Two possibilities either result == 0
                // or result > 0
                if ((arr[i] & sum) > 0)
                {

                    // If result > 0 then arr[i] xored
                    // with the sum1
                    sum1 = (sum1 ^ arr[i]);
                }
                else
                {

                    // If result == 0 then arr[i]
                    // xored with sum2
                    sum2 = (sum2 ^ arr[i]);
                }
            }

            // Print the the two unique numbers
            Console.WriteLine("The non-repeating "
                            + "elements are " + sum1 + " and "
                            + sum2);
        }

        [Fact]
        public void UniqueNumbers2Test()
        {
            int[] arr = { 2, 3, 7, 9, 11, 2, 3, 11 };
            int n = arr.Length;

            UniqueNumbers2(arr, n);
        }
        #endregion
        #region Count number of bits to be flipped to convert A to B
        public int countSetBits1(int n)
        {
            int count = 0;
            while (n > 0)
            {

                //AND operation of n and 1 gives us the rightmost bit. 
                //counter variable is increased if we get 1 as the rightmost bit.
                count += n & 1;

                //Right Shift n by 1 to remove the rightmost bit.
                n >>= 1;
            }
            return count;
        }
        public int countBitsFlip(int a, int b)
        {

            //XOR operation gives set bits only when there are dissimilar bits.
            //We store the value of XOR operation of a and b.
            int ans = a ^ b;

            //returning the number of set bits in resultant.
            return countSetBits1(ans);

        }

        #endregion
        #region Count total set bits in all numbers from 1 to n
        public int countSetBits(int n)
        {
            n += 1;
            int count = 0;
            for (int x = 2; x / 2 < n; x = x * 2)
            {
                //Total count of pairs of 0s and 1s.
                int quotient = n / x;
                //quotient gives the complete count of pairs of 1s.
                //Multiplying it with the (current power of 2)/2 will give
                //the count of 1s in the current bit.
                count += quotient * x / 2;

                int remainder = n % x;
                //If the count of pairs is odd then we add the remaining 1s 
                //which could not be grouped together. 
                if (remainder > x / 2)
                    count += remainder - x / 2;
            }
            return count;
        }
        #endregion
        #region Program to find whether a no is power of two
        //Complete this function
        public bool isPowerofTwo(long n)
        {
            if (n == 0)
            {
                return false;
            }

            //We use a counter variable to count number of set bits.
            int count = 0;
            while (n > 0)
            {
                //Increment of counter variable if we get 1 as the rightmost bit.
                count += (int)(n & 1);
                //Right Shift n to remove the rightmost bit.
                n >>= 1;
            }
            //returning true if number of set bits is 1 otherwise false.
            return count == 1;
        }
        #endregion
        #endregion

        #region 3BackTracking
        #region Rat in a maze Problem
        // List to store all the possible paths
        static List<String> possiblePaths = new List<String>();
        static String path = "";
        static readonly int MAX = 5;

        // Function returns true if the
        // move taken is valid else 
        // it will return false.
        static bool isSafe1(int row, int col, int[,] m,
                              int n, bool[,] visited)
        {
            if (row == -1 || row == n || col == -1 ||
                 col == n || visited[row, col] ||
                             m[row, col] == 0)
                return false;
            return true;
        }

        // Function to print all the possible
        // paths from (0, 0) to (n-1, n-1).
        static void printPathUtil(int row, int col, int[,] m,
                                  int n, bool[,] visited)
        {

            // This will check the initial point
            // (i.e. (0, 0)) to start the paths.
            if (row == -1 || row == n || col == -1 ||
                 col == n || visited[row, col] ||
                             m[row, col] == 0)
                return;

            // If reach the last cell (n-1, n-1)
            // then store the path and return
            if (row == n - 1 && col == n - 1)
            {
                possiblePaths.Add(path);
                return;
            }

            // Mark the cell as visited
            visited[row, col] = true;

            // Try for all the 4 directions (down, left, 
            // right, up) in the given order to get the
            // paths in lexicographical order

            // Check if downward move is valid
            if (isSafe1(row + 1, col, m, n, visited))
            {
                path += 'D';
                printPathUtil(row + 1, col, m, n,
                              visited);
                path = path.Substring(0, path.Length - 1);
            }

            // Check if the left move is valid
            if (isSafe1(row, col - 1, m, n, visited))
            {
                path += 'L';
                printPathUtil(row, col - 1, m, n,
                              visited);
                path = path.Substring(0, path.Length - 1);
            }

            // Check if the right move is valid
            if (isSafe1(row, col + 1, m, n, visited))
            {
                path += 'R';
                printPathUtil(row, col + 1, m, n,
                              visited);
                path = path.Substring(0, path.Length - 1);
            }

            // Check if the upper move is valid
            if (isSafe1(row - 1, col, m, n, visited))
            {
                path += 'U';
                printPathUtil(row - 1, col, m, n,
                              visited);
                path = path.Substring(0, path.Length - 1);
            }

            // Mark the cell as unvisited for 
            // other possible paths
            visited[row, col] = false;
        }

        // Function to store and print
        // all the valid paths 
        static void printPath(int[,] m, int n)
        {
            bool[,] visited = new bool[n, MAX];

            // Call the utility function to
            // find the valid paths 
            printPathUtil(0, 0, m, n, visited);

            // Print all possible paths
            for (int i = 0; i < possiblePaths.Count; i++)
                Console.Write(possiblePaths[i] + " ");
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[,] m = { { 1, 0, 0, 0, 0 },
                  { 1, 1, 1, 1, 1 },
                  { 1, 1, 1, 0, 1 },
                  { 0, 0, 0, 0, 1 },
                  { 0, 0, 0, 0, 1 } };
            int n = m.GetLength(0);
            printPath(m, n);
        }

        #endregion
        #region Printing all solutions in N-Queen Problem

        static List<List<int>> result = new List<List<int>>();

        /* A utility function to check if a queen can
        be placed on board[row,col]. Note that this
        function is called when "col" queens are
        already placed in columns from 0 to col -1.
        So we need to check only left side for
        attacking queens */
        static bool isSafe2(int[,] board, int row, int col,
                        int N)
        {
            int i, j;

            /* Check this row on left side */
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        /* A recursive utility function
        to solve N Queen problem */
        static bool solveNQUtil(int[,] board, int col, int N)
        {
            /* base case: If all queens are placed
            then return true */

            if (col == N)
            {
                List<int> v = new List<int>();
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < N; j++)
                    {
                        if (board[i, j] == 1)
                            v.Add(j + 1);
                    }
                result.Add(v);
                return true;
            }

            /* Consider this column and try placing
            this queen in all rows one by one */
            bool res = false;
            for (int i = 0; i < N; i++)
            {
                /* Check if queen can be placed on
                board[i,col] */
                if (isSafe2(board, i, col, N))
                {
                    /* Place this queen in board[i,col] */
                    board[i, col] = 1;

                    // Make result true if any placement
                    // is possible
                    res = solveNQUtil(board, col + 1, N) || res;

                    /* If placing queen in board[i,col]
                    doesn't lead to a solution, then
                    remove queen from board[i,col] */
                    board[i, col] = 0; // BACKTRACK
                }
            }

            /* If queen can not be place in any row in
                this column col then return false */
            return res;
        }

        /* This function solves the N Queen problem using
        Backtracking. It mainly uses solveNQUtil() to
        solve the problem. It returns false if queens
        cannot be placed, otherwise return true and
        prints placement of queens in the form of 1s.
        Please note that there may be more than one
        solutions, this function prints one of the
        feasible solutions.*/
        static List<List<int>> solveNQ(int n)
        {
            result.Clear();
            int[,] board = new int[n, n];

            solveNQUtil(board, 0, n);
            return result;
        }
        [Fact]
        public static void TestNQueen()
        {
            int n = 4;
            List<List<int>> res = solveNQ(n);
            for (int i = 0; i < res.Count; i++)
            {
                Console.Write("[");
                for (int j = 0; j < res[i].Count; j++)
                {
                    Console.Write(res[i][j] + " ");
                }
                Console.Write("]");
            }
        }
        #endregion
        #region Word Break Problem using Backtracking
        internal static void wordBreak(int n, IList<string> dict, string s)
        {
            string ans = "";
            wordBreakUtil(n, s, dict, ans);
        }

        internal static void wordBreakUtil(int n, string s, IList<string> dict, string ans)
        {
            for (int i = 1; i <= n; i++)
            {

                // Extract substring from 0 to i in prefix
                string prefix = s.Substring(0, i);

                // If dictionary conatins this prefix, then
                // we check for remaining string. Otherwise
                // we ignore this prefix (there is no else for
                // this if) and try next
                if (dict.Contains(prefix))
                {
                    // If no more elements are there, print it
                    if (i == n)
                    {

                        // Add this element to previous prefix
                        ans += prefix;
                        Console.WriteLine(ans);
                        return;
                    }
                    wordBreakUtil(n - i, s.Substring(i, n - i), dict, ans + prefix + " ");
                }
            }
        }

        // main function
        public void WordBreakBTrackTest(string[] args)
        {
            string str1 = "iloveicecreamandmango"; // for first test case
            string str2 = "ilovesamsungmobile"; // for second test case
            int n1 = str1.Length; // length of first string
            int n2 = str2.Length; // length of second string

            // List of strings in dictionary
            IList<string> dict = new List<string> { "mobile", "samsung", "sam", "sung", "man", "mango", "icecream", "and", "go", "i", "love", "ice", "cream" };
            Console.WriteLine("First Test:");

            // call to the method
            wordBreak(n1, dict, str1);
            Console.WriteLine("\nSecond Test:");

            // call to the method
            wordBreak(n2, dict, str2);
        }

        #endregion
        #region Remove Invalid Parentheses
        private void Combinator(IList<int> indices2Remove, int[] buffer, int start, int index, ISet<string> res, ref string s)
        {
            if (index == buffer.Length)
            {
                StringBuilder sb = new StringBuilder(s.Length);

                for (int i = 0; i < s.Length; i++)
                {
                    if (!buffer.Contains(i))
                    {
                        sb.Append(s[i]);
                    }
                }

                var candidate = sb.ToString();

                int opened = 0;
                for (int i = 0; i < candidate.Length; i++)
                {
                    if (candidate[i] == '(')
                    {
                        opened++;
                        continue;
                    }

                    if (candidate[i] == ')')
                    {
                        if (opened == 0)
                        {
                            return;
                        }

                        opened--;
                    }
                }

                if (opened == 0)
                {
                    res.Add(candidate);
                }

                return;
            }

            for (int i = start; i < indices2Remove.Count; i++)
            {
                buffer[index] = indices2Remove[i];
                Combinator(indices2Remove, buffer, i + 1, index + 1, res, ref s);
            }
        }

        private ISet<string> Combine(IList<int> indices2Remove, int k, ref string s)
        {
            ISet<string> res = new HashSet<string>();
            int[] buffer = new int[k];
            Combinator(indices2Remove, buffer, 0, 0, res, ref s);
            return res;
        }

        private int MinRemoveToMakeValid(string s)
        {
            ISet<int> removeSet = new HashSet<int>();
            Stack<int> openedStack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (c == '(')
                {
                    openedStack.Push(i);
                    continue;
                }

                if (c == ')')
                {
                    if (openedStack.Count == 0)
                    {
                        removeSet.Add(i);
                    }
                    else
                    {
                        openedStack.Pop();
                    }
                }
            }

            while (openedStack.Count != 0)
            {
                removeSet.Add(openedStack.Pop());
            }

            return removeSet.Count;
        }


        public IList<string> RemoveInvalidParentheses(string s)
        {
            var min = MinRemoveToMakeValid(s);
            IList<int> indices2Remove = new List<int>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == ')')
                {
                    indices2Remove.Add(i);
                }
            }
            ISet<string> res = Combine(indices2Remove, min, ref s);
            return res.ToArray();
        }
        #endregion
        #region Sudoku Solver
        // N is the size of the 2D matrix   N*N
        static int N = 9;

        /* Takes a partially filled-in grid and attempts
          to assign values to all unassigned locations in
          such a way to meet the requirements for
          Sudoku solution (non-duplication across rows,
          columns, and boxes) */
        static bool solveSuduko(int[,] grid, int row,
                                int col)
        {

            /*if we have reached the 8th
                   row and 9th column (0
                   indexed matrix) ,
                   we are returning true to avoid further
                   backtracking       */
            if (row == N - 1 && col == N)
                return true;

            // Check if column value  becomes 9 ,
            // we move to next row
            // and column start from 0
            if (col == N)
            {
                row++;
                col = 0;
            }

            // Check if the current position
            // of the grid already
            // contains value >0, we iterate
            // for next column
            if (grid[row, col] != 0)
                return solveSuduko(grid, row, col + 1);

            for (int num = 1; num < 10; num++)
            {

                // Check if it is safe to place
                // the num (1-9)  in the
                // given row ,col ->we move to next column
                if (isSafe(grid, row, col, num))
                {

                    /*  assigning the num in the current
                            (row,col)  position of the grid and
                            assuming our assigned num in the position
                            is correct */
                    grid[row, col] = num;

                    // Checking for next
                    // possibility with next column
                    if (solveSuduko(grid, row, col + 1))
                        return true;
                }
                /* removing the assigned num , since our
                         assumption was wrong , and we go for next
                         assumption with diff num value   */
                grid[row, col] = 0;
            }
            return false;
        }

        /* A utility function to print grid */
        static void print(int[,] grid)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(grid[i, j] + " ");
                Console.WriteLine();
            }
        }

        // Check whether it will be legal
        // to assign num to the
        // given row, col
        static bool isSafe(int[,] grid, int row, int col,
                           int num)
        {

            // Check if we find the same num
            // in the similar row , we
            // return false
            for (int x = 0; x <= 8; x++)
                if (grid[row, x] == num)
                    return false;

            // Check if we find the same num
            // in the similar column ,
            // we return false
            for (int x = 0; x <= 8; x++)
                if (grid[x, col] == num)
                    return false;

            // Check if we find the same num
            // in the particular 3*3
            // matrix, we return false
            int startRow = row - row % 3, startCol
              = col - col % 3;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[i + startRow, j + startCol] == num)
                        return false;

            return true;
        }

        [Fact]
        static void SudokuTest()
        {
            int[,] grid = { { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
                   { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                   { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                   { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                   { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
                   { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                   { 0, 0, 5, 2, 0, 6, 3, 0, 0 } };

            if (solveSuduko(grid, 0, 0))
                print(grid);
            else
                Console.WriteLine("No Solution exists");
        }
        #endregion
        #endregion

        #region 4BT
        #region level order traversal
        public class NodeBT1
        {
            public int data;
            public NodeBT1 left, right;
            public NodeBT1(int item)
            {
                data = item;
                left = right = null;
            }
        }

        // Root of the Binary Tree
        public NodeBT1 root1;

        public void BinaryTree1()
        {
            root1 = null;
        }

        public virtual void printLevelOrder()
        {
            int h = height1(root1);
            int i;
            for (i = 1; i <= h; i++)
            {
                printCurrentLevel(root1, i);
            }
        }

        public int height1(NodeBT1 root)
        {
            if (root1 == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height1(root.left);
                int rheight = height1(root.right);

                /* use the larger one */
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }

        /* Print nodes at the current level */
        public virtual void printCurrentLevel(NodeBT1 root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.data + " ");
            }
            else if (level > 1)
            {
                printCurrentLevel(root.left, level - 1);
                printCurrentLevel(root.right, level - 1);
            }
        }

        [Fact]
        public void LevelOrderTest()
        {
            this.root1 = new NodeBT1(1);
            this.root1.left = new NodeBT1(2);
            this.root1.right = new NodeBT1(3);
            this.root1.left.left = new NodeBT1(4);
            this.root1.left.right = new NodeBT1(5);
            Console.WriteLine("Level order traversal " +
                                "of binary tree is ");
            this.printLevelOrder();
        }
        #endregion
        #region Reverse Level Order traversal
        public class BinaryTree
        {
            public NodeBT1 root;


            void reverseLevelOrder(NodeBT1 node)
            {
                int h = height(node);
                int i;
                for (i = h; i >= 1; i--)

                // THE ONLY LINE DIFFERENT
                // FROM NORMAL LEVEL ORDER
                {
                    printGivenLevel(node, i);
                }
            }


            void printGivenLevel(NodeBT1 node, int level)
            {
                if (node == null)
                    return;
                if (level == 1)
                    Console.Write(node.data + " ");
                else if (level > 1)
                {
                    printGivenLevel(node.left, level - 1);
                    printGivenLevel(node.right, level - 1);
                }
            }

            /* Compute the "height" of a tree --
            the number of nodes along the longest
            path from the root node down to the
            farthest leaf node.*/
            int height(NodeBT1 node)
            {
                if (node == null)
                    return 0;
                else
                {
                    /* compute the height of each subtree */
                    int lheight = height(node.left);
                    int rheight = height(node.right);

                    /* use the larger one */
                    if (lheight > rheight)
                        return (lheight + 1);
                    else
                        return (rheight + 1);
                }
            }

            [Fact]
            public void ReverseTraversalTest()
            {
                BinaryTree tree = new BinaryTree();

                // Let us create trees shown
                // in above diagram
                tree.root = new NodeBT1(1);
                tree.root.left = new NodeBT1(2);
                tree.root.right = new NodeBT1(3);
                tree.root.left.left = new NodeBT1(4);
                tree.root.left.right = new NodeBT1(5);

                Console.WriteLine("Level Order traversal " +
                                    "of binary tree is : ");
                tree.reverseLevelOrder(tree.root);
            }
        }
        #endregion
        #region Height of a tree

        int maxDepth(NodeBT1 node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = maxDepth(node.left);
                int rDepth = maxDepth(node.right);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }

        [Fact]
        public void TreeHeight()
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new NodeBT1(1);
            tree.root.left = new NodeBT1(2);
            tree.root.right = new NodeBT1(3);
            tree.root.left.left = new NodeBT1(4);
            tree.root.left.right = new NodeBT1(5);

            Console.WriteLine("Height of tree is : " +
                                        maxDepth(tree.root));
        }
        #endregion
        #region Diameter of a tree
        class Solution
        {
            // Function to find the diameter of a Binary Tree.
            int diameterUtil(NodeBT1 n, ref int dia)
            {
                // if node becomes null, we return 0.
                if (n == null) return 0;

                // calling the function recursively for the left and
                // right subtrees to find their heights.
                int l = diameterUtil(n.left, ref dia);
                int r = diameterUtil(n.right, ref dia);

                // storing the maximum possible value of l+r+1 in diameter.
                if (l + r + 1 > dia) dia = l + r + 1;

                // returning height of subtree.
                return 1 + Math.Max(l, r);
            }
            // Function to return the diameter of a Binary Tree.
            public int diameter(NodeBT1 root)
            {
                int dia = 0;
                // calling the function to find the result.
                diameterUtil(root, ref dia);
                // returning the result.
                return dia;
            }
        }
        #endregion
        #region Mirror of a tree
        // Helper function that allocates
        // a new node with the given data
        // and null left and right pointers
        public static NodeBT1 createNode(int val)
        {
            NodeBT1 newNode = new NodeBT1(0);
            newNode.data = val;
            newNode.left = null;
            newNode.right = null;
            return newNode;
        }

        // Helper function to print Inorder traversal
        public static void inorder(NodeBT1 root)
        {
            if (root == null)
            {
                return;
            }
            inorder(root.left);
            Console.Write("{0:D} ", root.data);
            inorder(root.right);
        }

        public static NodeBT1 mirrorify(NodeBT1 root)
        {
            if (root == null)
            {
                return null;

            }

            // Create new mirror node from original tree node
            NodeBT1 mirror = createNode(root.data);
            mirror.right = mirrorify(root.left);
            mirror.left = mirrorify(root.right);
            return mirror;
        }

        // Driver code
        public static void Main()
        {

            NodeBT1 tree = createNode(5);
            tree.left = createNode(3);
            tree.right = createNode(6);
            tree.left.left = createNode(2);
            tree.left.right = createNode(4);

            // Print inorder traversal of the input tree
            Console.Write("Inorder of original tree: ");
            inorder(tree);
            NodeBT1 mirror = null;
            mirror = mirrorify(tree);

            // Print inorder traversal of the mirror tree
            Console.Write("\nInorder of mirror tree: ");
            inorder(mirror);
        }
        #endregion
        #endregion

        #region 5BST
        public class BinarySearchTree
        {
            public BSTSNode1 root;
        }
        #region Fina a value in a BST

        public class BSTSNode1
        {
            public int key;
            public BSTSNode1 left, right;

            public BSTSNode1(int item)
            {
                key = item;
                left = right = null;
            }
        }

        // Root of BST
        BSTSNode1 rootbst;


        // This method mainly calls insertRec()
        void insert(int key)
        {
            rootbst = insertRec(rootbst, key);
        }

        BSTSNode1 insertRec(BSTSNode1 root, int key)
        {

            // If the tree is empty,
            // return a new node
            if (root == null)
            {
                root = new BSTSNode1(key);
                return root;
            }

            // Otherwise, recur down the tree
            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);

            // Return the (unchanged) node pointer
            return root;
        }

        // This method mainly calls InorderRec()
        void inorder()
        {
            inorderRec(rootbst);
        }
        void inorderRec(BSTSNode1 root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.WriteLine(root.key);
                inorderRec(root.right);
            }
        }
        [Fact]
        public void FindValInBstTest()
        {
            /* Let us create following BST
                50
            /	 \
            30	 70
            / \ / \
        20 40 60 80 */
            insert(50);
            insert(30);
            insert(20);
            insert(40);
            insert(70);
            insert(60);
            insert(80);

            // Print inorder traversal of the BST
            inorder();
        }
        #endregion
        #region Deletion of a node in a BST
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (root.Data > key)
                root.Left = DeleteNode(root.Left, key);
            else if (root.Data < key)
                root.Right = DeleteNode(root.Right, key);
            else
            {
                // case 1
                if (root.Left == null && root.Right == null)
                    return null;
                // case 2
                else if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                else
                {
                    // case 3
                    var minElement = GetMinElement(root.Right);
                    root.Data = minElement.Data;
                    root.Right = DeleteNode(root.Right, root.Data);
                }
            }

            return root;
        }

        private TreeNode GetMinElement(TreeNode root)
        {
            var current = root;

            while (current.Left != null)
                current = current.Left;

            return current;
        }
        #endregion
        #region Find min and max value in a BST
        public static BSTNode head;
        public virtual BSTNode insert(BSTNode node, int data)
        {
            if (node == null)
            {
                return (new BSTNode(data));
            }
            else
            {
                if (data <= node.Data)
                {
                    node.Left = insert(node.Left, data);
                }
                else
                {
                    node.Right = insert(node.Right, data);
                }
                return node;
            }
        }
        public virtual int minvalue(BSTNode node)
        {
            BSTNode current = node;

            /* loop down to find the leftmost leaf */
            while (current.Left != null)
            {
                current = current.Left;
            }
            return (current.Data);
        }
        [Fact]
        public void FindMinMaxTest()
        {
            BSTNode root = null;
            root = insert(root, 4);
            insert(root, 2);
            insert(root, 1);
            insert(root, 3);
            insert(root, 6);
            insert(root, 5);

            Console.WriteLine("Minimum value of BST is " + minvalue(root));
        }
        #endregion
        #region Find inorder successor and inorder predecessor in a BST
        static BSTNode pre = new BSTNode(), suc = new BSTNode();

        static void findPreSuc(BSTNode root, int key)
        {

            // Base case
            if (root == null)
                return;

            // If key is present at root
            if (root.Data == key)
            {

                // The maximum value in left
                // subtree is predecessor
                if (root.Left != null)
                {
                    BSTNode tmp = root.Left;
                    while (tmp.Right != null)
                        tmp = tmp.Right;

                    pre = tmp;
                }

                // The minimum value in
                if (root.Right != null)
                {
                    BSTNode tmp = root.Right;

                    while (tmp.Left != null)
                        tmp = tmp.Left;

                    suc = tmp;
                }
                return;
            }

            if (root.Data > key)
            {
                suc = root;
                findPreSuc(root.Left, key);
            }

            // Go to right subtree
            else
            {
                pre = root;
                findPreSuc(root.Right, key);
            }
        }

        static BSTNode insert1(BSTNode node, int key)
        {
            if (node == null)
                return new BSTNode(key);
            if (key < node.Data)
                node.Left = insert1(node.Left, key);
            else
                node.Right = insert1(node.Right, key);

            return node;
        }

        [Fact]
        public void InorderSuccessor()
        {

            // Key to be searched in BST
            int key = 65;

            /*
            * Let us create following BST
            *		 50
            *		 / \
            *	 30 70
            *	 / \ / \
            *	 20 40 60 80
            */

            BSTNode root = new BSTNode();
            root = insert(root, 50);
            insert(root, 30);
            insert(root, 20);
            insert(root, 40);
            insert(root, 70);
            insert(root, 60);
            insert(root, 80);

            findPreSuc(root, key);
            if (pre != null)
                Console.WriteLine("Predecessor is " + pre.Data);
            else
                Console.WriteLine("No Predecessor");

            if (suc != null)
                Console.WriteLine("Successor is " + suc.Data);
            else
                Console.WriteLine("No Successor");
        }
        #endregion
        #region Check if a tree is a BST or not 

        public virtual bool BST
        {
            get
            {
                return isBSTUtil(rootbst, int.MinValue, int.MaxValue);
            }
        }

        public virtual bool isBSTUtil(BSTSNode1 node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            /* false if this node violates the min/max constraints */
            if (node.key < min || node.key > max)
            {
                return false;
            }

            return (isBSTUtil(node.left, min, node.key - 1) && isBSTUtil(node.right, node.key + 1, max));
        }

        [Fact]
        public void IsBstTest()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.root = new BSTSNode1(4);
            tree.root.left = new BSTSNode1(2);
            tree.root.right = new BSTSNode1(5);
            tree.root.left.left = new BSTSNode1(1);
            tree.root.left.right = new BSTSNode1(3);

            if (isBSTUtil(tree.root, int.MinValue, int.MaxValue))
            {
                Console.WriteLine("IS BST");
            }
            else
            {
                Console.WriteLine("Not a BST");
            }
        }
        #endregion
        #endregion

        #region 6Complexity

        #endregion

        #region 7DP
        #region Coin ChangeProblem
        public virtual long count(int[] S, int m, int n)
        {
            long[] table = new long[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                table[i] = 0;
            }
            table[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = S[i]; j <= n; j++)
                {
                    table[j] += table[j - S[i]];
                }
            }

            return table[n];

        }

        #endregion
        #region Knapsack Problem

        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that
        // can be put in a knapsack of
        // capacity W
        static int knapSack(int W, int[] wt,
                            int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom
            // up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;

                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(
                            val[i - 1]
                            + K[i - 1, w - wt[i - 1]],
                            K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

        [Fact]
        static void KnapsackTestDp()
        {
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;

            Console.WriteLine(knapSack(W, wt, val, n));
        }
        #endregion
        #region Binomial CoefficientProblem
        // Returns value of Binomial
        // Coefficient C(n, k)
        static int binomialCoeff(int n, int k)
        {

            // Base Cases
            if (k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;

            // Recur
            return binomialCoeff(n - 1, k - 1)
                + binomialCoeff(n - 1, k);
        }

        [Fact]
        public void binomialCoeffTest()
        {
            int n = 5, k = 2;
            Console.Write("Value of C(" + n + "," + k + ") is "
                        + binomialCoeff(n, k));
        }
        #endregion
        #region Permutation CoefficientProblem
        static int permutationCoeff(int n,
                                int k)
        {
            int[,] P = new int[n + 2, k + 2];

            // Calculate value of Permutation
            // Coefficient in bottom up manner
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0;
                    j <= Math.Min(i, k);
                    j++)
                {
                    // Base Cases
                    if (j == 0)
                        P[i, j] = 1;

                    // Calculate value using previosly
                    // stored values
                    else
                        P[i, j] = P[i - 1, j] +
                                (j * P[i - 1, j - 1]);

                    // This step is important
                    // as P(i,j)=0 for j>i
                    P[i, j + 1] = 0;
                }
            }
            return P[n, k];
        }

        [Fact]
        public void permutationCoeffTest()
        {
            int n = 10, k = 2;
            Console.WriteLine("Value of P( " + n +
                            "," + k + ")" + " is " +
                            permutationCoeff(n, k));
        }
        #endregion
        #region Program for nth Catalan Number
        // A recursive function to find
        // nth catalan number
        static int catalan(int n)
        {
            int res = 0;

            // Base case
            if (n <= 1)
            {
                return 1;
            }
            for (int i = 0; i < n; i++)
            {
                res += catalan(i)
                    * catalan(n - i - 1);
            }
            return res;
        }

        [Fact]
        public void catalanTest()
        {
            for (int i = 0; i < 10; i++)
                Console.Write(catalan(i) + " ");
        }
        #endregion
        #endregion

        #region 8Graph
        #region Create a Graph, print it

        #endregion
        #region Implement BFS algorithm 
        public class GraphNode1
        {
            // No. of vertices	
            private int _V;

            //Adjacency Lists
            LinkedList<int>[] _adj;

            public GraphNode1(int V)
            {
                _adj = new LinkedList<int>[V];
                for (int i = 0; i < _adj.Length; i++)
                {
                    _adj[i] = new LinkedList<int>();
                }
                _V = V;
            }
            public void AddEdge(int v, int w)
            {
                _adj[v].AddLast(w);

            }
            public void BFS(int s)
            {

                // Mark all the vertices as not
                // visited(By default set as false)
                bool[] visited = new bool[_V];
                for (int i = 0; i < _V; i++)
                    visited[i] = false;

                // Create a queue for BFS
                LinkedList<int> queue = new LinkedList<int>();

                // Mark the current node as
                // visited and enqueue it
                visited[s] = true;
                queue.AddLast(s);

                while (queue.Any())
                {

                    // Dequeue a vertex from queue
                    // and print it
                    s = queue.First();
                    Console.Write(s + " ");
                    queue.RemoveFirst();

                    // Get all adjacent vertices of the
                    // dequeued vertex s. If a adjacent
                    // has not been visited, then mark it
                    // visited and enqueue it
                    LinkedList<int> list = _adj[s];

                    foreach (var val in list)
                    {
                        if (!visited[val])
                        {
                            visited[val] = true;
                            queue.AddLast(val);
                        }
                    }
                }
            }
            void DFSUtil(int v, bool[] visited)
            {
                // Mark the current node as visited
                // and print it
                visited[v] = true;
                Console.Write(v + " ");

                // Recur for all the vertices
                // adjacent to this vertex
                List<int> vList = adj[v];
                foreach (var n in vList)
                {
                    if (!visited[n])
                        DFSUtil(n, visited);
                }
            }
            public void DFS(int v)
            {
                // Mark all the vertices as not visited
                // (set as false by default in c#)
                bool[] visited = new bool[V];

                // Call the recursive helper function
                // to print DFS traversal
                DFSUtil(v, visited);
            }

        }
        [Fact]
        public void BfsGraphTest()
        {
            GraphNode1 g = new GraphNode1(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.Write("Following is Breadth First " +
                        "Traversal(starting from " +
                        "vertex 2)\n");
            g.BFS(2);
        }
        #endregion
        #region Implement DFS Algo 
        [Fact]
        public static void DfsGraphTest()
        {
            GraphNode1 g = new GraphNode1(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine(
                "Following is Depth First Traversal "
                + "(starting from vertex 2)");

            g.DFS(2);
            Console.ReadKey();
        }
        #endregion
        #region Detect Cycle in Directed Graph using BFS/DFS Algo 
        private readonly int V;
        private readonly List<List<int>> adj;

        private bool isCyclicUtil(int i, bool[] visited,
                                        bool[] recStack)
        {

            // Mark the current node as visited and
            // part of recursion stack
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (isCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

        public void addEdge(int sou, int dest)
        {
            adj[sou].Add(dest);
        }

        private bool isCyclic()
        {

            // Mark all the vertices as not visited and
            // not part of recursion stack
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];


            // Call the recursive helper function to
            // detect cycle in different DFS trees
            for (int i = 0; i < V; i++)
                if (isCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }

        [Fact]
        public void isCyclicTest()
        {
            GraphNode1 g = new GraphNode1(4);
            //graph.addEdge(0, 1);
            //graph.addEdge(0, 2);
            //graph.addEdge(1, 2);
            //graph.addEdge(2, 0);
            //graph.addEdge(2, 3);
            //graph.addEdge(3, 3);

            //if (graph.isCyclic())
            //    Console.WriteLine("Graph contains cycle");
            //else
            //    Console.WriteLine("Graph doesn't "
            //                            + "contain cycle");
        }
        #endregion
        #region Detect Cycle in UnDirected Graph using BFS/DFS Algo      

        // Driver Code
        public static void UnDirectedCyclicTeat(String[] args)
        {
            // Create a graph given in the above diagram
            GraphNode1 g = new GraphNode1(5);
            //g1.addEdge(1, 0);
            //g1.addEdge(0, 2);
            //g1.addEdge(2, 1);
            //g1.addEdge(0, 3);
            //g1.addEdge(3, 4);
            //if (g1.isCyclic())
            //    Console.WriteLine("Graph contains cycle");
            //else
            //    Console.WriteLine("Graph doesn't contains cycle");

            //GraphNode1 g = new GraphNode1(3);
            //g2.addEdge(0, 1);
            //g2.addEdge(1, 2);
            //if (g2.isCyclic())
            Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");
        }
        #endregion
        #endregion

        #region 9Greedy
        #region Activity Selection Problem
        public static void printMaxActivities(int[] s,
                                    int[] f, int n)
        {
            int i, j;

            Console.Write("Following activities are selected : ");

            // The first activity always gets selected
            i = 0;
            Console.Write(i + " ");

            // Consider rest of the activities
            for (j = 1; j < n; j++)
            {
                // If this activity has start time greater than or
                // equal to the finish time of previously selected
                // activity, then select it
                if (s[j] >= f[i])
                {
                    Console.Write(j + " ");
                    i = j;
                }
            }
        }

        [Fact]
        public void printMaxActivitiesTest()
        {
            int[] s = { 1, 3, 0, 5, 8, 5 };
            int[] f = { 2, 4, 6, 7, 9, 9 };
            int n = s.Length;

            printMaxActivities(s, f, n);
        }
        #endregion
        #region Job SequencingProblem
        class GFG : IComparer<Job>
        {
            public int Compare(Job x, Job y)
            {
                if (x.profit == 0 || y.profit == 0)
                {
                    return 0;
                }

                // CompareTo() method
                return (y.profit).CompareTo(x.profit);

            }
        }


        public class Job
        {

            // Each job has a unique-id,
            // profit and deadline
            char id;
            public int deadline, profit;

            // Constructors
            public Job() { }

            public Job(char id, int deadline, int profit)
            {
                this.id = id;
                this.deadline = deadline;
                this.profit = profit;
            }

            // Function to schedule the jobs take 2
            // arguments arraylist and no of jobs to schedule
            void printJobScheduling(List<Job> arr, int t)
            {
                // Length of array
                int n = arr.Count;

                GFG gg = new GFG();
                // Sort all jobs according to
                // decreasing order of profit
                arr.Sort(gg);

                // To keep track of free time slots
                bool[] result = new bool[t];

                // To store result (Sequence of jobs)
                char[] job = new char[t];

                // Iterate through all given jobs
                for (int i = 0; i < n; i++)
                {
                    // Find a free slot for this job
                    // (Note that we start from the
                    // last possible slot)
                    for (int j
                        = Math.Min(t - 1, arr[i].deadline - 1);
                        j >= 0; j--)
                    {

                        // Free slot found
                        if (result[j] == false)
                        {
                            result[j] = true;
                            job[j] = arr[i].id;
                            break;
                        }
                    }
                }

                // Print the sequence
                foreach (char jb in job)
                {
                    Console.Write(jb + " ");
                }
                Console.WriteLine();
            }

            // Driver code
            static public void Main()
            {

                List<Job> arr = new List<Job>();

                arr.Add(new Job('a', 2, 100));
                arr.Add(new Job('b', 1, 19));
                arr.Add(new Job('c', 2, 27));
                arr.Add(new Job('d', 1, 25));
                arr.Add(new Job('e', 3, 15));

                // Function call
                Console.WriteLine("Following is maximum "
                                + "profit sequence of jobs");

                Job job = new Job();

                // Calling function
                job.printJobScheduling(arr, 3);

            }
        }
        #endregion
        #region Huffman Coding
        //checked utube


        #endregion
        #region Water Connection Problem
        // number of houses and number
        // of pipes
        static int n, p;

        static int[] rd = new int[1100];

        static int[] wt = new int[1100];

        static int[] cd = new int[1100];

        static List<int> a =
                new List<int>();

        static List<int> b =
                new List<int>();

        static List<int> c =
                new List<int>();

        static int ans;

        static int dfs(int w)
        {
            if (cd[w] == 0)
                return w;
            if (wt[w] < ans)
                ans = wt[w];

            return dfs(cd[w]);
        }

        // Function to perform calculations.
        static void solve(int[,] arr)
        {
            int i = 0;

            while (i < p)
            {

                int q = arr[i, 0];
                int h = arr[i, 1];
                int t = arr[i, 2];

                cd[q] = h;
                wt[q] = t;
                rd[h] = q;
                i++;
            }

            a = new List<int>();
            b = new List<int>();
            c = new List<int>();

            for (int j = 1; j <= n; ++j)

                /*If a pipe has no ending vertex
                but has starting vertex i.e is
                an outgoing pipe then we need
                to start DFS with this vertex.*/
                if (rd[j] == 0 && cd[j] > 0)
                {
                    ans = 1000000000;
                    int w = dfs(j);

                    // We put the details of
                    // component in final output
                    // array
                    a.Add(j);
                    b.Add(w);
                    c.Add(ans);
                }

            Console.WriteLine(a.Count);

            for (int j = 0; j < a.Count; ++j)
                Console.WriteLine(a[j] + " "
                    + b[j] + " " + c[j]);
        }

        [Fact]
        public void WaterConnectionProblem()
        {
            n = 9;
            p = 6;

            // set the value of the araray
            // to zero
            for (int i = 0; i < 1100; i++)
                rd[i] = cd[i] = wt[i] = 0;

            int[,] arr = { { 7, 4, 98 },
                        { 5, 9, 72 },
                        { 4, 6, 10 },
                        { 2, 8, 22 },
                        { 9, 7, 17 },
                        { 3, 1, 66 } };
            solve(arr);
        }
        #endregion
        #region Fractional Knapsack Problem
        class item
        {
            public int value;
            public int weight;

            public item(int value, int weight)
            {
                this.value = value;
                this.weight = weight;
            }
        }

        class cprCompare : IComparer
        {
            public int Compare(Object x, Object y)
            {
                item item1 = (item)x;
                item item2 = (item)y;
                double cpr1 = (double)item1.value /
                            (double)item1.weight;
                double cpr2 = (double)item2.value /
                            (double)item2.weight;

                if (cpr1 < cpr2)
                    return 1;

                return cpr1 > cpr2 ? -1 : 0;
            }
        }

        // Main greedy function to solve problem
        static double FracKnapSack(item[] items, int w)
        {

            // Sort items based on cost per units
            cprCompare cmp = new cprCompare();
            Array.Sort(items, cmp);


            // Traverse items, if it can fit,
            // take it all, else take fraction
            double totalVal = 0f;
            int currW = 0;

            foreach (item i in items)
            {
                float remaining = w - currW;

                // If the whole item can be
                // taken, take it
                if (i.weight <= remaining)
                {
                    totalVal += (double)i.value;
                    currW += i.weight;
                }

                // dd fraction untill we run out of space
                else
                {
                    if (remaining == 0)
                        break;

                    double fraction = remaining / (double)i.weight;
                    totalVal += fraction * (double)i.value;
                    currW += (int)(fraction * (double)i.weight);
                }
            }
            return totalVal;
        }

        [Fact]
        static void FracKnapSackJobTest()
        {
            item[] arr = { new item(60, 10),
                new item(100, 20),
                new item(120, 30) };

            Console.WriteLine("Maximum value we can obtain = " +
                                FracKnapSack(arr, 50));
        }
        #endregion
        #endregion

        #region 10Heap
        #region Implement a Maxheap/MinHeap using arrays and recursion.
        public class BuildHeap
        {
            static void heapify(int[] arr, int n, int i)
            {
                int largest = i; // Initialize largest as root
                int l = 2 * i + 1; // left = 2*i + 1
                int r = 2 * i + 2; // right = 2*i + 2

                // If left child is larger than root
                if (l < n && arr[l] > arr[largest])
                    largest = l;

                // If right child is larger than largest so far
                if (r < n && arr[r] > arr[largest])
                    largest = r;

                // If largest is not root
                if (largest != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[largest];
                    arr[largest] = swap;

                    // Recursively heapify the affected sub-tree
                    heapify(arr, n, largest);
                }
            }

            static void buildHeap(int[] arr, int n)
            {
                // Index of last non-leaf node
                int startIdx = (n / 2) - 1;

                // Perform reverse level order traversal
                // from last non-leaf node and heapify
                // each node
                for (int i = startIdx; i >= 0; i--)
                {
                    heapify(arr, n, i);
                }
            }
            static void printHeap(int[] arr, int n)
            {
                Console.WriteLine("Array representation of Heap is:");

                for (int i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");

                Console.WriteLine();
            }
            [Fact]
            public static void BuildHeapTest()
            {
                // Binary Tree Representation
                // of input array
                // 1
                //	 / \
                // 3		 5
                // / \	 / \
                // 4	 6 13 10
                // / \ / \
                // 9 8 15 17
                int[] arr = { 1, 3, 5, 4, 6, 13, 10,
                    9, 8, 15, 17 };

                int n = arr.Length;

                buildHeap(arr, n);

                printHeap(arr, n);
            }
        }
        #endregion
        #region Sort an Array using heap. (HeapSort)

        void printKMax(int[] arr, int n, int k)
        {
            int j, max;

            for (int i = 0; i <= n - k; i++)
            {

                max = arr[i];

                for (j = 1; j < k; j++)
                {
                    if (arr[i + j] > max)
                        max = arr[i + j];
                }
                Console.Write(max + " ");
            }
        }
        [Fact]
        public void SortArrayusingheap()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 3;
            printKMax(arr, arr.Length, k);
        }
        #endregion
        #region Maximum of all subarrays of size k.


        [Fact]
        public void aximumAllSubarraySsizek()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 3;
            printKMax(arr, arr.Length, k);
        }
        #endregion
        #region “k” largest element in an array
        public static void kLargest(int[] arr, int k)
        {
            // Sort the given array arr in reverse order
            // This method doesn't work with primitive data
            // types. So, instead of int, Integer type
            // array will be used
            Array.Sort(arr);
            Array.Reverse(arr);

            // Print the first kth largest elements
            for (int i = 0; i < k; i++)
                Console.Write(arr[i] + " ");
        }

        [Fact]
        public void kLargestTest()
        {
            int[] arr = new int[] { 1, 23, 12, 9,
                                30, 2, 50 };
            int k = 3;
            kLargest(arr, k);
        }
        #endregion
        #region Kth smallest and largest element in an unsorted array
        // Function to return k'th smallest
        // element in a given array
        public static int kthSmallest(int[] arr, int k)
        {

            // Sort the given array
            Array.Sort(arr);

            // Return k'th element in
            // the sorted array
            return arr[k - 1];
        }

        [Fact]
        public static void kthSmallestTest()
        {
            int[] arr = new int[] { 12, 3, 5,
                                7, 19 };
            int k = 2;
            Console.Write("K'th smallest element"
                        + " is " + kthSmallest(arr, k));
        }
        #endregion
        #endregion

        #region 11LinkedList
        #region Write a Program to reverse the Linked List. (Both Iterative and recursive)
        [Fact]
        public void LLReverseTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(new LinkedList<int>().AddLast(85));
            list.AddLast(new LinkedList<int>().AddLast(15));
            list.AddLast(new LinkedList<int>().AddLast(4));
            list.AddLast(new LinkedList<int>().AddLast(20));

            // List before reversal
            Console.WriteLine("Given linked list:");
            //PrintList();

            // Reverse the list
            //SReverseList();

            // List after reversal
            Console.WriteLine("Reversed linked list:");
            //list.PrintList();
        }

        #endregion
        #region Reverse a Linked List in group of Given Size. [Very Imp]
        ////LLNode head; // head of list

        ///* Linked list Node*/
        //class LLNode
        //{
        //    public int data;
        //    public Node next;
        //    public LLNode(int d)
        //    {
        //        data = d;
        //        next = null;
        //    }
        //}

        //LLNode reverse(LLNode head, int k)
        //{
        //    if (head == null)
        //        return null;
        //    LLNode current = head;
        //    LLNode next = null;
        //    LLNode prev = null;

        //    int count = 0;

        //    /* Reverse first k nodes of linked list */
        //    while (count < k && current != null)
        //    {
        //        next = current.next;
        //        current.next = prev;
        //        prev = current;
        //        current = next;
        //        count++;
        //    }

        //    /* next is now a pointer to (k+1)th node
        //        Recursively call for the list starting from
        //    current. And make rest of the list as next of
        //    first node */
        //    if (next != null)
        //        head.next = reverse(next, k);

        //    // prev is now head of input list
        //    return prev;
        //}

        ///* Utility functions */

        ///* Inserts a new Node at front of the list. */
        //public void push(int new_data)
        //{
        //    /* 1 & 2: Allocate the Node &
        //            Put in the data*/
        //    Node new_node = new Node(new_data);

        //    /* 3. Make next of new Node as head */
        //    new_node.next = head;

        //    /* 4. Move the head to point to new Node */
        //    head = new_node;
        //}

        ///* Function to print linked list */
        //void printList()
        //{
        //    Node temp = head;
        //    while (temp != null)
        //    {
        //        Console.Write(temp.data + " ");
        //        temp = temp.next;
        //    }
        //    Console.WriteLine();
        //}

        ///* Driver code*/
        //public static void Main(String[] args)
        //{
        //    LinkedList llist = new LinkedList();

        //    /* Constructed Linked List is 1->2->3->4->5->6->
        //    7->8->8->9->null */
        //    llist.push(9);
        //    llist.push(8);
        //    llist.push(7);
        //    llist.push(6);
        //    llist.push(5);
        //    llist.push(4);
        //    llist.push(3);
        //    llist.push(2);
        //    llist.push(1);

        //    Console.WriteLine("Given Linked List");
        //    llist.printList();

        //    llist.head = llist.reverse(llist.head, 3);

        //    Console.WriteLine("Reversed list");
        //    llist.printList();
        //}
        #endregion
        #region Write a program to Detect loop in a linked list.
        public bool detectLoop(Node head)
        {
            //using two pointers and moving one pointer(slow) by one node and 
            //another pointer(fast) by two nodes in each iteration.
            Node fast = head.next;
            Node slow = head;

            while (fast != slow)
            {
                //if the node pointed by first pointer(fast) or the node 
                //next to it is null, we return false.
                if (fast == null || fast.next == null)
                    return false;

                fast = fast.next.next;
                slow = slow.next;
            }
            //if we reach here it means both the pointers fast and slow point to 
            //same node which shows the presence of loop so we return true.
            return true;
        }

        #endregion
        #region Write a program to Delete loop in a linked list.
        //Complete this function
        //public void removeLoop(Node head)
        //{
        //    //using two pointers and moving one pointer(slow) by one node and 
        //    //another pointer(fast) by two nodes in each iteration.
        //    Node fast = head.next;
        //    Node slow = head;

        //    while (fast != slow)
        //    {
        //        //if the node pointed by first pointer(fast) or the node 
        //        //next to it is null, then loop is not present so we return 0.
        //        if (fast == null || fast.next == null)
        //            return;

        //        fast = fast.next.next;
        //        slow = slow.next;
        //    }
        //    //both pointers now point to the same node in the loop.

        //    int size = 1;
        //    fast = fast.next;
        //    //we start iterating the loop with first pointer and continue till 
        //    //both pointers point to same node again.
        //    while (fast != slow)
        //    {
        //        fast = fast.next;
        //        //incrementing the counter which stores length of loop..
        //        size += 1;
        //    }

        //    //updating the pointers again to starting node.
        //    slow = head;
        //    fast = head;

        //    //moving pointer (fast) by (size-1) nodes.
        //    for (int i = 0; i < size - 1; i++)
        //        fast = fast.next;

        //    //now we keep iterating with both pointers till fast reaches a node such
        //    //that the next node is pointed by slow. At this situation slow is at
        //    //the node where loop starts and first at last node so we simply 
        //    //update the link part of first.
        //    while (fast.next != slow)
        //    {
        //        fast = fast.next;
        //        slow = slow.next;
        //    }
        //    //storing null in link part of the last node.
        //    fast.next = null;
        //}
        #endregion
        #region Find the starting point of the loop. 

        //class Node
        //{
        //    public int key;
        //    public Node next;
        //};

        //static Node newNode(int key)
        //{
        //    Node temp = new Node();
        //    temp.key = key;
        //    temp.next = null;
        //    return temp;
        //}

        //// A utility function to
        //// print a linked list
        //static void printList(Node head)
        //{
        //    while (head != null)
        //    {
        //        Console.Write(head.key + " ");
        //        head = head.next;
        //    }
        //    Console.WriteLine();
        //}

        //// Function to detect and remove loop
        //// in a linked list that may contain loop
        //static Node detectAndRemoveLoop(Node head)
        //{
        //    // If list is empty or has
        //    // only one node without loop
        //    if (head == null || head.next == null)
        //        return null;

        //    Node slow = head, fast = head;

        //    // Move slow and fast 1
        //    // and 2 steps ahead
        //    // respectively.
        //    slow = slow.next;
        //    fast = fast.next.next;

        //    // Search for loop using
        //    // slow and fast pointers
        //    while (fast != null &&
        //            fast.next != null)
        //    {
        //        if (slow == fast)
        //            break;
        //        slow = slow.next;
        //        fast = fast.next.next;
        //    }

        //    // If loop does not exist
        //    if (slow != fast)
        //        return null;

        //    // If loop exists. Start slow from
        //    // head and fast from meeting point.
        //    slow = head;
        //    while (slow != fast)
        //    {
        //        slow = slow.next;
        //        fast = fast.next;
        //    }

        //    return slow;
        //}

        //// Driver code
        //public static void Main(String[] args)
        //{
        //    Node head = newNode(50);
        //    head.next = newNode(20);
        //    head.next.next = newNode(15);
        //    head.next.next.next = newNode(4);
        //    head.next.next.next.next = newNode(10);

        //    // Create a loop for testing
        //    head.next.next.next.next.next =
        //                        head.next.next;

        //    Node res = detectAndRemoveLoop(head);

        //    if (res == null)
        //        Console.Write("Loop does not exist");
        //    else
        //        Console.Write("Loop starting node is " +
        //                    res.key);
        //}
        #endregion
        #endregion

        #region 12Matrix
        #region Find row with maximum no. of 1's
        public static int R = 4, C = 4;

        // Function to find the index of first index
        // of 1 in a boolean array arr[]
        public static int first(int[] arr,
                                int low, int high)
        {
            if (high >= low)
            {
                // Get the middle index
                int mid = low + (high - low) / 2;

                // Check if the element at middle
                // index is first 1
                if ((mid == 0 || (arr[mid - 1] == 0)) &&
                                arr[mid] == 1)
                {
                    return mid;
                }

                // If the element is 0, recur
                // for right side
                else if (arr[mid] == 0)
                {
                    return first(arr, (mid + 1), high);
                }

                // If element is not first 1, recur
                // for left side
                else
                {
                    return first(arr, low, (mid - 1));
                }
            }
            return -1;
        }

        // Function that returns index of row
        // with maximum number of 1s.
        public static int rowWithMax1s(int[][] mat)
        {
            // Initialize max values
            int max_row_index = 0, max = -1;

            // Traverse for each row and count number
            // of 1s by finding the index of first 1
            int i, index;
            for (i = 0; i < R; i++)
            {
                index = first(mat[i], 0, C - 1);
                if (index != -1 && C - index > max)
                {
                    max = C - index;
                    max_row_index = i;
                }
            }

            return max_row_index;
        }

        // Driver Code
        public static void Main(string[] args)
        {
            int[][] mat = new int[][]
            {
        new int[] {0, 0, 0, 1},
        new int[] {0, 1, 1, 1},
        new int[] {1, 1, 1, 1},
        new int[] {0, 0, 0, 0}
            };
            Console.WriteLine("Index of row with maximum 1s is " +
                                            rowWithMax1s(mat));
        }
        #endregion
        #region Print elements in sorted order using row-column wise sorted matrix
        static int SIZE = 10;

        // function to sort the given matrix
        static void sortMat(int[,] mat, int n)
        {
            // temporary matrix of size n^2
            int[] temp = new int[n * n];
            int k = 0;

            // copy the elements of matrix
            // one by one into temp[]
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    temp[k++] = mat[i, j];

            // sort temp[]
            Array.Sort(temp);

            // copy the elements of temp[]
            // one by one in mat[][]
            k = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    mat[i, j] = temp[k++];
        }

        // function to print the given matrix
        static void printMat(int[,] mat, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(mat[i, j] + " ");
                Console.WriteLine();
            }
        }

        // Driver code
        public static void Main()
        {
            int[,] mat = { { 5, 4, 7 },
                        { 1, 3, 8 },
                        { 2, 9, 6 } };
            int n = 3;

            Console.WriteLine("Original Matrix:");
            printMat(mat, n);

            sortMat(mat, n);

            Console.WriteLine("Matrix After Sorting:");
            printMat(mat, n);
        }
        #endregion
        #region Spiral traversal on a Matrix
        static void spiralPrint(int m, int n, int[,] a)
        {
            int i, k = 0, l = 0;
            /* k - starting row index
            m - ending row index
            l - starting column index
            n - ending column index
            i - iterator
            */

            while (k < m && l < n)
            {
                // Print the first row
                // from the remaining rows
                for (i = l; i < n; ++i)
                {
                    Console.Write(a[k, i] + " ");
                }
                k++;

                // Print the last column from the
                // remaining columns
                for (i = k; i < m; ++i)
                {
                    Console.Write(a[i, n - 1] + " ");
                }
                n--;

                // Print the last row from
                // the remaining rows
                if (k < m)
                {
                    for (i = n - 1; i >= l; --i)
                    {
                        Console.Write(a[m - 1, i] + " ");
                    }
                    m--;
                }

                // Print the first column from
                // the remaining columns
                if (l < n)
                {
                    for (i = m - 1; i >= k; --i)
                    {
                        Console.Write(a[i, l] + " ");
                    }
                    l++;
                }
            }
        }

        // Driver Code
        public static void Main()
        {
            int R = 3;
            int C = 6;
            int[,] a = { { 1, 2, 3, 4, 5, 6 },
                    { 7, 8, 9, 10, 11, 12 },
                    { 13, 14, 15, 16, 17, 18 } };

            // Function Call
            spiralPrint(R, C, a);
        }
        #endregion
        #region Search an element in a matriix
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int rows = matrix.Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = matrix[i].Length - 1; j >= 0; j--)
                {
                    if (matrix[i][j] == target)
                        return true;
                    if (matrix[i][j] < target)
                        break;
                }
            }
            return false;
        }
        #endregion
        #region Find median in a row wise sorted matrix

        // Function to find median
        // in the matrix
        static int binaryMedian(int[,] m,
                                int r, int c)
        {
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < r; i++)
            {
                // Finding the minimum
                // element
                if (m[i, 0] < min)
                    min = m[i, 0];

                // Finding the maximum
                // element
                if (m[i, c - 1] > max)
                    max = m[i, c - 1];
            }

            int desired = (r * c + 1) / 2;
            while (min < max)
            {
                int mid = min + (max - min) / 2;
                int place = 0;
                int get = 0;

                // Find count of elements
                // smaller than mid
                for (int i = 0; i < r; ++i)
                {
                    get = Array.BinarySearch(
                            GetRow(m, i), mid);

                    // If element is not found
                    // in the array the binarySearch()
                    // method returns (-(insertion_
                    // point) - 1). So once we know
                    // the insertion point we can
                    // find elements Smaller than
                    // the searched element by the
                    // following calculation
                    if (get < 0)
                        get = Math.Abs(get) - 1;

                    // If element is found in the
                    // array it returns the index(any
                    // index in case of duplicate). So
                    // we go to last index of element
                    // which will give the number of
                    // elements smaller than the number
                    // including the searched element.
                    else
                    {
                        while (get < GetRow(m, i).GetLength(0) &&
                            m[i, get] == mid)
                            get += 1;
                    }

                    place = place + get;
                }

                if (place < desired)
                    min = mid + 1;
                else
                    max = mid;
            }
            return min;
        }

        public static int[] GetRow(int[,] matrix,
                                int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new int[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row, i];

            return rowVector;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int r = 3, c = 3;
            int[,] m = {{1,3,5},
            {2,6,9},
            {3,6,9} };

            Console.WriteLine("Median is " +
                                binaryMedian(m, r, c));
        }
        #endregion
        #endregion

        #region 13Math

        #endregion

        #region 14String
        #region Reverse a String
        public void ReverseString(char[] s)
        {
            int a_pointer = 0;
            int b_pointer = s.Length - 1;

            while (a_pointer <= b_pointer)
            {
                char temp = s[b_pointer];
                s[b_pointer] = s[a_pointer];
                s[a_pointer] = temp;
                a_pointer++;
                b_pointer--;
            }
            Console.WriteLine(new String(s));
        }
        #endregion
        #region Check whether a String is Palindrome or not
        void isPalindrome(char str[])
        {
            // Start from leftmost and rightmost corners of str
            int l = 0;
            int h = strlen(str) - 1;

            // Keep comparing characters while they are same
            while (h > l)
            {
                if (str[l++] != str[h--])
                {
                    printf("%s is not a palindrome\n", str);
                    return;
                }
            }
            printf("%s is a palindrome\n", str);
        }

        // Driver program to test above function
        int main()
        {
            isPalindrome("abba");
            isPalindrome("abbccbba");
            isPalindrome("geeks");
            return 0;
        }
        #endregion
        #region Find Duplicate characters in a string
        static int NO_OF_CHARS = 256;

        /* Fills count array with
        frequency of characters */
        static void fillCharCounts(String str,
                                    int[] count)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        /* Print duplicates present in
        the passed string */
        static void printDups(String str)
        {

            // Create an array of size 256 and
            // fill count of every character in it
            int[] count = new int[NO_OF_CHARS];
            fillCharCounts(str, count);

            for (int i = 0; i < NO_OF_CHARS; i++)
                if (count[i] > 1)
                    Console.WriteLine((char)i + ", " +
                                "count = " + count[i]);
        }

        // Driver Method
        public static void Main()
        {
            String str = "test string";
            printDups(str);
        }
        #endregion
        #region Write a Code to check whether one string is a rotation of another
        /* Function checks if passed strings
(str1 and str2) are rotations of
each other */
        static bool areRotations(String str1,
                                    String str2)
        {

            // There lengths must be same and
            // str2 must be a substring of
            // str1 concatenated with str1.
            return (str1.Length == str2.Length)
                && ((str1 + str1).IndexOf(str2)
                                        != -1);
        }

        // Driver method
        public static void Main()
        {
            String str1 = "FGABCDE";
            String str2 = "ABCDEFG";

            if (areRotations(str1, str2))
                Console.Write("Strings are"
                + " rotation s of each other");
            else
                Console.Write("Strings are "
            + "not rotations of each other");
        }
        #endregion
        #region Write a Program to check whether a string is a valid shuffle of two strings or not

        // length of result string should be equal to sum of two strings
        static boolean checkLength(String first, String second, String result)
        {
            if (first.length() + second.length() != result.length())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // this method converts the string to char array 
        // sorts the char array
        // convert the char array to string and return it
        static String sortString(String str)
        {

            char[] charArray = str.toCharArray();
            Arrays.sort(charArray);

            // convert char array back to string
            str = String.valueOf(charArray);

            return str;
        }

        // this method compares each character of the result with 
        // individual characters of the first and second string
        static boolean shuffleCheck(String first, String second, String result)
        {

            // sort each string to make comparison easier
            first = sortString(first);
            second = sortString(second);
            result = sortString(result);

            // variables to track each character of 3 strings
            int i = 0, j = 0, k = 0;

            // iterate through all characters of result
            while (k != result.length())
            {

                // check if first character of result matches
                // with first character of first string
                if (i < first.length() && first.charAt(i) == result.charAt(k))
                    i++;

                // check if first character of result matches
                // with the first character of second string
                else if (j < second.length() && second.charAt(j) == result.charAt(k))
                    j++;

                // if the character doesn't match
                else
                {
                    return false;
                }

                // access next character of result
                k++;
            }

            // after accessing all characters of result
            // if either first or second has some characters left
            if (i < first.length() || j < second.length())
            {
                return false;
            }

            return true;
        }

        public static void main(String[] args)
        {

            String first = "XY";
            String second = "12";
            String[] results = { "1XY2", "Y1X2", "Y21XX" };

            // call the method to check if result string is
            // shuffle of the string first and second
            for (String result : results)
            {
                if (checkLength(first, second, result) == true && shuffleCheck(first, second, result) == true)
                {
                    System.out.println(result + " is a valid shuffle of " + first + " and " + second);
                }
                else
                {
                    System.out.println(result + " is not a valid shuffle of " + first + " and " + second);
                }
            }
        }
        #endregion
        #endregion

        #region 15Stack & Queue
        #region  Implement Stack from Scratch

        #endregion
        #region  Implement Queue from Scratch

        #endregion
        #region Implement 2 stack in an array
        //Function to push an integer into the stack1.
        public void push1(int x, TwoStack sq)
        {
            //if there is space between the top of both stacks 
            //we push the element at top1+1.
            if (sq.top1 < sq.top2 - 1)
            {
                sq.top1++;
                sq.arr[sq.top1] = x;
            }
        }

        //Function to push an integer into the stack2.
        public void push2(int x, TwoStack sq)
        {
            //if there is space between the top of both stacks 
            //we push the element at top2-1.
            if (sq.top1 < sq.top2 - 1)
            {
                sq.top2--;
                sq.arr[sq.top2] = x;
            }
        }

        //Function to remove an element from top of the stack1.
        public int pop1(TwoStack sq)
        {
            //if top1==-1, stack1 is empty so we return -1 else we 
            //return the top element of stack1.
            if (sq.top1 >= 0)
            {
                int x = sq.arr[sq.top1];
                sq.top1--;
                return x;
            }
            else
                return -1;
        }

        //Function to remove an element from top of the stack2.
        public int pop2(TwoStack sq)
        {
            //if top2==size of array, stack2 is empty so we return -1 else we 
            //return the top element of stack2.
            if (sq.top2 < sq.size)
            {
                int x = sq.arr[sq.top2];
                sq.top2++;
                return x;
            }
            else
                return -1;
        }
        #endregion
        #region Implement "N" stacks in an Array
        // A c# class to represent k stacks in a single array of size n
        public class KStack
        {
            public int[] arr; // Array of size n to store actual content to be stored in stacks
            public int[] top; // Array of size k to store indexes of top elements of stacks
            public int[] next; // Array of size n to store next entry in all stacks
                               // and free list
            public int n, k;
            public int free; // To store beginning index of free list

            //constructor to create k stacks in an array of size n
            public KStack(int k1, int n1)
            {
                // Initialize n and k, and allocate memory for all arrays
                k = k1;
                n = n1;
                arr = new int[n];
                top = new int[k];
                next = new int[n];

                // Initialize all stacks as empty
                for (int i = 0; i < k; i++)
                {
                    top[i] = -1;
                }

                // Initialize all spaces as free
                free = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    next[i] = i + 1;
                }
                next[n - 1] = -1; // -1 is used to indicate end of free list
            }

            // A utility function to check if there is space available
            public virtual bool Full
            {
                get
                {
                    return (free == -1);
                }
            }

            // To push an item in stack number 'sn' where sn is from 0 to k-1
            public virtual void push(int item, int sn)
            {
                // Overflow check
                if (Full)
                {
                    Console.WriteLine("Stack Overflow");
                    return;
                }

                int i = free; // Store index of first free slot

                // Update index of free slot to index of next slot in free list
                free = next[i];

                // Update next of top and then top for stack number 'sn'
                next[i] = top[sn];
                top[sn] = i;

                // Put the item in array
                arr[i] = item;
            }

            // To pop an from stack number 'sn' where sn is from 0 to k-1
            public virtual int pop(int sn)
            {
                // Underflow check
                if (isEmpty(sn))
                {
                    Console.WriteLine("Stack Underflow");
                    return int.MaxValue;
                }

                // Find index of top item in stack number 'sn'
                int i = top[sn];

                top[sn] = next[i]; // Change top to store next of previous top

                // Attach the previous top to the beginning of free list
                next[i] = free;
                free = i;

                // Return the previous top item
                return arr[i];
            }

            // To check whether stack number 'sn' is empty or not
            public virtual bool isEmpty(int sn)
            {
                return (top[sn] == -1);
            }

        }

        // Driver program
        public static void Main(string[] args)
        {
            // Let us create 3 stacks in an array of size 10
            int k = 3, n = 10;

            KStack ks = new KStack(k, n);

            ks.push(15, 2);
            ks.push(45, 2);

            // Let us put some items in stack number 1
            ks.push(17, 1);
            ks.push(49, 1);
            ks.push(39, 1);

            // Let us put some items in stack number 0
            ks.push(11, 0);
            ks.push(9, 0);
            ks.push(7, 0);

            Console.WriteLine("Popped element from stack 2 is " + ks.pop(2));
            Console.WriteLine("Popped element from stack 1 is " + ks.pop(1));
            Console.WriteLine("Popped element from stack 0 is " + ks.pop(0));
        }
        #endregion
        #region find the middle element of a stack
        /* A Doubly Linked List Node */
        public class DLLNode
        {
            public DLLNode prev;
            public int data;
            public DLLNode next;
            public DLLNode(int d) { data = d; }
        }

        /* Representation of the stack
        data structure that supports
        findMiddle() in O(1) time. The
        Stack is implemented using
        Doubly Linked List. It maintains
        pointer to head node, pointer
        to middle node and count of
        nodes */
        public class myStack
        {
            public DLLNode head;
            public DLLNode mid;
            public int count;
        }

        /* Function to create the stack data structure */
        myStack createMyStack()
        {
            myStack ms = new myStack();
            ms.count = 0;
            return ms;
        }

        /* Function to push an element to the stack */
        void push(myStack ms, int new_data)
        {

            /* allocate DLLNode and put in data */
            DLLNode new_DLLNode = new DLLNode(new_data);

            /* Since we are adding at the beginning,
            prev is always NULL */
            new_DLLNode.prev = null;

            /* link the old list off the new DLLNode */
            new_DLLNode.next = ms.head;

            /* Increment count of items in stack */
            ms.count += 1;

            /* Change mid pointer in two cases
            1) Linked List is empty
            2) Number of nodes in linked list is odd */
            if (ms.count == 1)
            {
                ms.mid = new_DLLNode;
            }
            else
            {
                ms.head.prev = new_DLLNode;

                // Update mid if ms->count is odd
                if ((ms.count % 2) != 0)
                    ms.mid = ms.mid.prev;
            }

            /* move head to point to the new DLLNode */
            ms.head = new_DLLNode;
        }

        /* Function to pop an element from stack */
        int pop(myStack ms)
        {
            /* Stack underflow */
            if (ms.count == 0)
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }

            DLLNode head = ms.head;
            int item = head.data;
            ms.head = head.next;

            // If linked list doesn't become empty,
            // update prev of new head as NULL
            if (ms.head != null)
                ms.head.prev = null;

            ms.count -= 1;

            // update the mid pointer when
            // we have even number of elements
            // in the stack, i,e move down
            // the mid pointer.
            if (ms.count % 2 == 0)
                ms.mid = ms.mid.next;

            return item;
        }

        // Function for finding middle of the stack
        int findMiddle(myStack ms)
        {
            if (ms.count == 0)
            {
                Console.WriteLine("Stack is empty now");
                return -1;
            }
            return ms.mid.data;
        }

        // Driver code
        public static void Main(String[] args)
        {
            GFG ob = new GFG();
            myStack ms = ob.createMyStack();
            ob.push(ms, 11);
            ob.push(ms, 22);
            ob.push(ms, 33);
            ob.push(ms, 44);
            ob.push(ms, 55);
            ob.push(ms, 66);
            ob.push(ms, 77);

            Console.WriteLine("Item popped is " + ob.pop(ms));
            Console.WriteLine("Item popped is " + ob.pop(ms));
            Console.WriteLine("Middle Element is "
                            + ob.findMiddle(ms));
        }
        #endregion
        #endregion

        #region 16Searching & Sorting
        #region Find first and last positions of an element in a sorted array
        // Function for finding first and
        // last occurrence of an elements
        static void findFirstAndLast(int[] arr,
                                    int x)
        {
            int n = arr.Length;
            int first = -1, last = -1;

            for (int i = 0; i < n; i++)
            {
                if (x != arr[i])
                    continue;
                if (first == -1)
                    first = i;
                last = i;
            }
            if (first != -1)
            {
                Console.WriteLine("First "
                                + "Occurrence = " + first);
                Console.Write("Last "
                            + "Occurrence = " + last);
            }
            else
                Console.Write("Not Found");
        }

        // Driver code
        public static void Main()
        {
            int[] arr = { 1, 2, 2, 2, 2, 3,
                    4, 7, 8, 8 };
            int x = 8;
            findFirstAndLast(arr, x);
        }
        #endregion
        #region Find a Fixed Point (Value equal to index) in a given array
        static int linearSearch(int[] arr, int n)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                if (arr[i] == i)
                    return i;
            }

            /* If no fixed point present
            then return -1 */
            return -1;
        }
        // Driver code
        public static void Main()
        {
            int[] arr = { -10, -1, 0, 3, 10, 11, 30, 50, 100 };
            int n = arr.Length;
            Console.Write("Fixed Point is " + linearSearch(arr, n));
        }
        #endregion
        #region Search in a rotated sorted array
        public int Search(int[] nums, int target)
        {
            var low = 0;
            var high = nums.Length - 1;

            while (low <= high)
            {
                var mid = (low + high) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] < nums[high])
                {
                    if (target > nums[mid] && target <= nums[high])
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
                else
                {
                    if (target >= nums[low] && target < nums[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
            }

            return -1;
        }
        #endregion
        #region square root of an integer
        static int floorSqrt(int x)
        {
            // Base cases
            if (x == 0 || x == 1)
                return x;

            // Staring from 1, try all
            // numbers until i*i is
            // greater than or equal to x.
            int i = 1, result = 1;

            while (result <= x)
            {
                i++;
                result = i * i;
            }
            return i - 1;
        }

        // Driver Code
        static public void Main()
        {
            int x = 11;
            Console.WriteLine(floorSqrt(x));
        }
        #endregion
        #region Maximum and minimum of an array using minimum number of comparisons
        static Pair getMinMax(int[] arr, int n)
        {
            Pair minmax = new Pair();
            int i;

            /* If there is only one element
            then return it as min and max both*/
            if (n == 1)
            {
                minmax.max = arr[0];
                minmax.min = arr[0];
                return minmax;
            }

            /* If there are more than one elements,
            then initialize min and max*/
            if (arr[0] > arr[1])
            {
                minmax.max = arr[0];
                minmax.min = arr[1];
            }
            else
            {
                minmax.max = arr[1];
                minmax.min = arr[0];
            }

            for (i = 2; i < n; i++)
            {
                if (arr[i] > minmax.max)
                {
                    minmax.max = arr[i];
                }
                else if (arr[i] < minmax.min)
                {
                    minmax.min = arr[i];
                }
            }
            return minmax;
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            Pair minmax = getMinMax(arr, arr_size);
            Console.Write("Minimum element is {0}",
                                    minmax.min);
            Console.Write("\nMaximum element is {0}",
                                        minmax.max);
        }
        #endregion
        #endregion

        #region 17Trie
        #region Construct a trie from scratch
        public class Trie
        {
            static readonly int ALPHABET_SIZE = 26;
            class TrieNode
            {
                public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

                // isEndOfWord is true if the node represents
                // end of a word
                public bool isEndOfWord;

                public TrieNode()
                {
                    isEndOfWord = false;
                    for (int i = 0; i < ALPHABET_SIZE; i++)
                        children[i] = null;
                }
            };
            static TrieNode root;
            static void insert(String key)
            {
                int level;
                int length = key.Length;
                int index;

                TrieNode pCrawl = root;

                for (level = 0; level < length; level++)
                {
                    index = key[level] - 'a';
                    if (pCrawl.children[index] == null)
                        pCrawl.children[index] = new TrieNode();

                    pCrawl = pCrawl.children[index];
                }

                // mark last node as leaf
                pCrawl.isEndOfWord = true;
            }
            static bool search(String key)
            {
                int level;
                int length = key.Length;
                int index;
                TrieNode pCrawl = root;

                for (level = 0; level < length; level++)
                {
                    index = key[level] - 'a';

                    if (pCrawl.children[index] == null)
                        return false;

                    pCrawl = pCrawl.children[index];
                }

                return (pCrawl.isEndOfWord);
            }
            [Fact]
            public static void CreateTrie()
            {
                // Input keys (use only 'a'
                // through 'z' and lower case)
                String[] keys = {"the", "a", "there", "answer",
                        "any", "by", "bye", "their"};

                String[] output = { "Not present in trie", "Present in trie" };


                root = new TrieNode();

                // Construct trie
                int i;
                for (i = 0; i < keys.Length; i++)
                    insert(keys[i]);

                // Search for different keys
                if (search("the") == true)
                    Console.WriteLine("the --- " + output[1]);
                else Console.WriteLine("the --- " + output[0]);

                if (search("these") == true)
                    Console.WriteLine("these --- " + output[1]);
                else Console.WriteLine("these --- " + output[0]);

                if (search("their") == true)
                    Console.WriteLine("their --- " + output[1]);
                else Console.WriteLine("their --- " + output[0]);

                if (search("thaw") == true)
                    Console.WriteLine("thaw --- " + output[1]);
                else Console.WriteLine("thaw --- " + output[0]);

            }
        }
        #endregion
        #region Find shortest unique prefix for every word in a given list
        public class Unique_Prefix_Trie
        {

            static readonly int MAX = 256;

            // Maximum length of an input word
            static readonly int MAX_WORD_LEN = 500;

            // Trie Node.
            public class TrieNode
            {
                public TrieNode[] child = new TrieNode[MAX];
                public int freq; // To store frequency
                public TrieNode()
                {
                    freq = 1;
                    for (int i = 0; i < MAX; i++)
                        child[i] = null;
                }
            }
            static TrieNode root;

            // Method to insert a new string into Trie
            static void insert(String str)
            {
                // Length of the URL
                int len = str.Length;
                TrieNode pCrawl = root;

                // Traversing over the length of given str.
                for (int level = 0; level < len; level++)
                {
                    // Get index of child node from
                    // current character in str.
                    int index = str[level];

                    // Create a new child if not exist already
                    if (pCrawl.child[index] == null)
                        pCrawl.child[index] = new TrieNode();
                    else
                        (pCrawl.child[index].freq)++;

                    // Move to the child
                    pCrawl = pCrawl.child[index];
                }
            }
            static void findPrefixesUtil(TrieNode root, char[] prefix,
                                int ind)
            {
                // Corner case
                if (root == null)
                    return;

                // Base case
                if (root.freq == 1)
                {
                    prefix[ind] = '\0';
                    int i = 0;
                    while (prefix[i] != '\0')
                        Console.Write(prefix[i++]);
                    Console.Write(" ");
                    return;
                }

                for (int i = 0; i < MAX; i++)
                {
                    if (root.child[i] != null)
                    {
                        prefix[ind] = (char)i;
                        findPrefixesUtil(root.child[i], prefix, ind + 1);
                    }
                }
            }
            static void findPrefixes(String[] arr, int n)
            {
                // Construct a Trie of all words
                root = new TrieNode();
                root.freq = 0;
                for (int i = 0; i < n; i++)
                    insert(arr[i]);

                // Create an array to store all prefixes
                char[] prefix = new char[MAX_WORD_LEN];

                // Print all prefixes using Trie Traversal
                findPrefixesUtil(root, prefix, 0);
            }

            // Driver code
            public static void Main()
            {
                String[] arr = { "zebra", "dog", "duck", "dove" };
                int n = arr.Length;
                findPrefixes(arr, n);
            }
        }
        #endregion
        #region Word Break Problem | (Trie solution)
        internal const int ALPHABET_SIZE = 26;

        // trie node
        internal class TrieNode
        {
            internal TrieNode[] children;

            // isEndOfWord is true if the node
            // represents end of a word
            internal bool isEndOfWord;

            // Constructor of TrieNode
            internal TrieNode()
            {
                children = new TrieNode[ALPHABET_SIZE];
                for (int i = 0; i < ALPHABET_SIZE; i++)
                {
                    children[i] = null;
                }

                isEndOfWord = false;
            }
        }
        internal static void insert(TrieNode root, string key)
        {
            TrieNode pCrawl = root;

            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i] - 'a';
                if (pCrawl.children[index] == null)
                {
                    pCrawl.children[index] = new TrieNode();
                }

                pCrawl = pCrawl.children[index];
            }

            // Mark last node as leaf
            pCrawl.isEndOfWord = true;
        }
        internal static bool search(TrieNode root, string key)
        {
            TrieNode pCrawl = root;

            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i] - 'a';
                if (pCrawl.children[index] == null)
                {
                    return false;
                }

                pCrawl = pCrawl.children[index];
            }
            return (pCrawl != null && pCrawl.isEndOfWord);
        }
        internal static bool wordBreak(string str, TrieNode root)
        {
            int size = str.Length;

            // Base case
            if (size == 0)
            {
                return true;
            }

            // Try all prefixes of lengths from 1 to size
            for (int i = 1; i <= size; i++)
            {

                // The parameter for search is
                // str.substring(0, i)
                // str.substrinf(0, i) which is
                // prefix (of input string) of
                // length 'i'. We first check whether
                // current prefix is in dictionary.
                // Then we recursively check for remaining
                // string str.substr(i, size) which
                // is suffix of length size-i.
                if (search(root, str.Substring(0, i)) && wordBreak(str.Substring(i, size - i), root))
                {
                    return true;
                }
            }

            // If we have tried all prefixes and none
            // of them worked
            return false;
        }

        // Driver code
        public static void Main(string[] args)
        {
            string[] dictionary = new string[] { "mobile", "samsung", "sam", "sung", "ma", "mango", "icecream", "and", "go", "i", "like", "ice", "cream" };

            int n = dictionary.Length;
            TrieNode root = new TrieNode();

            // Construct trie
            for (int i = 0; i < n; i++)
            {
                insert(root, dictionary[i]);
            }

            Console.Write(wordBreak("ilikesamsung", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("iiiiiiii", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("ilikelikeimangoiii", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("samsungandmango", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("samsungandmangok", root) ? "Yes\n" : "No\n");
        }

        #endregion
        #region Given a sequence of words, print all anagrams together
        public virtual IList<IList<string>> Anagrams(string[] string_list)
        {

            Dictionary<string, IList<string>> mp = new Dictionary<string, IList<string>>();
            IList<IList<string>> ans = new List<IList<string>>();

            foreach (string i in string_list)
            {
                char[] ch = i.ToCharArray();
                Array.Sort(ch);
                // Convert the string to its lexicographically 
                // least representation, 
                // e.g. cat->act, act->act, tac->act 
                string s = new string(ch);

                // Check if that representation has 
                // occurred already
                if (mp.ContainsKey(s))
                {
                    // If occurred add the original string to the map
                    mp[s].Add(i);
                }

                // If not present
                else
                {
                    // Create a new list
                    IList<string> li = new List<string>();
                    // Add the original string
                    li.Add(i);
                    ans.Add(li);
                    // Insert into the map the string as key 
                    // and the new list as value
                    mp[s] = li;
                }
            }

            return ans;

        }

        #endregion
        #region Implement a Phone Directory
        class TrieNode
        {

            public Dictionary<char, TrieNode> child;

            public bool isLast;

            // Default Constructor
            public TrieNode()
            {
                child = new Dictionary<char, TrieNode>();
                for (char i = 'a'; i <= 'z'; i++)
                    child.Add(i, null);
                isLast = false;
            }
        }

        public class Trie
        {
            public TrieNode root;

            // Insert all the Contacts into the Trie
            public void insertIntoTrie(String[] contacts)
            {
                root = new TrieNode();
                int n = contacts.Length;
                for (int i = 0; i < n; i++)
                {
                    insert(contacts[i]);
                }
            }

            // Insert a Contact into the Trie
            public void insert(String s)
            {
                int len = s.Length;

                // 'itr' is used to iterate the Trie Nodes
                TrieNode itr = root;
                for (int i = 0; i < len; i++)
                {
                    // Check if the s[i] is already present in
                    // Trie
                    TrieNode nextNode = itr.child[s[i]];
                    if (nextNode == null)
                    {
                        // If not found then create a new TrieNode
                        nextNode = new TrieNode();

                        // Insert into the Dictionary
                        if (itr.child.ContainsKey(s[i]))
                            itr.child[s[i]] = nextNode;
                        else
                            itr.child.Add(s[i], nextNode);
                    }

                    // Move the iterator('itr') ,to point to next
                    // Trie Node
                    itr = nextNode;

                    // If its the last character of the string 's'
                    // then mark 'isLast' as true
                    if (i == len - 1)
                        itr.isLast = true;
                }
            }

            // This function simply displays all dictionary words
            // going through current node. String 'prefix'
            // represents string corresponding to the path from
            // root to curNode.
            public void displayContactsUtil(TrieNode curNode,
                                            String prefix)
            {

                // Check if the string 'prefix' ends at this Node
                // If yes then display the string found so far
                if (curNode.isLast)
                    Console.WriteLine(prefix);

                // Find all the adjacent Nodes to the current
                // Node and then call the function recursively
                // This is similar to performing DFS on a graph
                for (char i = 'a'; i <= 'z'; i++)
                {
                    TrieNode nextNode = curNode.child[i];
                    if (nextNode != null)
                    {
                        displayContactsUtil(nextNode, prefix + i);
                    }
                }
            }

            // Display suggestions after every character enter by
            // the user for a given string 'str'
            public void displayContacts(String str)
            {
                TrieNode prevNode = root;

                // 'flag' denotes whether the string entered
                // so far is present in the Contact List

                String prefix = "";
                int len = str.Length;

                // Display the contact List for string formed
                // after entering every character
                int i;
                for (i = 0; i < len; i++)
                {
                    // 'str' stores the string entered so far
                    prefix += str[i];

                    // Get the last character entered
                    char lastChar = prefix[i];

                    // Find the Node corresponding to the last
                    // character of 'str' which is pointed by
                    // prevNode of the Trie
                    TrieNode curNode = prevNode.child[lastChar];

                    // If nothing found, then break the loop as
                    // no more prefixes are going to be present.
                    if (curNode == null)
                    {
                        Console.WriteLine("\nNo Results Found for'"
                                                + prefix + "'");
                        i++;
                        break;
                    }

                    // If present in trie then display all
                    // the contacts with given prefix.
                    Console.WriteLine("Suggestions based on '"
                                        + prefix + "' are");
                    displayContactsUtil(curNode, prefix);

                    // Change prevNode for next prefix
                    prevNode = curNode;
                }

                for (; i < len; i++)
                {
                    prefix += str[i];
                    Console.WriteLine("\nNo Results Found for '"
                                                + prefix + "'");
                }
            }
        }

        [Fact]
        public void PhoneDirectoryTest()
        {
            Trie trie = new Trie();

            String[] contacts = { "gforgeeks", "geeksquiz" };

            trie.insertIntoTrie(contacts);

            String query = "gekk";

            // Note that the user will enter 'g' then 'e' so
            // first display all the strings with prefix as 'g'
            // and then all the strings with prefix as 'ge'
            trie.displayContacts(query);
        }
        #endregion
        #region Print unique rows in a given boolean matrix
        static int ROW = 4;
        static int COL = 5;

        // Function that prints all  
        // unique rows in a given matrix. 
        static void findUniqueRows(int[,] M)
        {

            // Traverse through the matrix 
            for (int i = 0; i < ROW; i++)
            {
                int flag = 0;

                // Check if there is similar column 
                // is already printed, i.e if i and 
                // jth column match. 
                for (int j = 0; j < i; j++)
                {
                    flag = 1;

                    for (int k = 0; k < COL; k++)
                        if (M[i, k] != M[j, k])
                            flag = 0;

                    if (flag == 1)
                        break;
                }

                // If no row is similar 
                if (flag == 0)
                {

                    // Print the row 
                    for (int j = 0; j < COL; j++)
                        Console.Write(M[i, j] + " ");

                    Console.WriteLine();
                }
            }
        }

        [Fact]
        public void findUniqueRowsTest()
        {
            int[,] M = { { 0, 1, 0, 0, 1 },
                 { 1, 0, 1, 1, 0 },
                 { 0, 1, 0, 0, 1 },
                 { 1, 0, 1, 0, 0 } };

            findUniqueRows(M);
        }
        #endregion
        #endregion
    }
}
