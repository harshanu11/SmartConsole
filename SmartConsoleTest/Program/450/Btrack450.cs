using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DSA450
{
    public class Btrack450 {
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

        [Fact]
        public void RatInamzeTest()
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
                        Debug.WriteLine(ans);
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
            Debug.WriteLine("First Test:");

            // call to the method
            wordBreak(n1, dict, str1);
            Debug.WriteLine("\nSecond Test:");

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
                Debug.WriteLine();
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
                Debug.WriteLine("No Solution exists");
        }
        #endregion
    }
}
