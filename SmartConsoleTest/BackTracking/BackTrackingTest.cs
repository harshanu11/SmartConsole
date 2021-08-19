using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartConsoleTest.BackTracking
{
    public class BackTrackingTest
    {
        [Fact]
        public void DPCant()
        {
            BtTemplate1 b = new BtTemplate1();
            var asn = b.SolveNQueens(4);
        }
    }
    public class BTemplate
    {
        public static bool IsValidState(List<IList<string>> state)
        {

            return true;
        }
        public static List<IList<string>> GetCandidate(List<IList<string>> state)
        {
            return new List<IList<string>>();
        }
        public void Search(List<IList<string>> state, List<IList<string>> soleution)
        {
            if (IsValidState(state))
            {
                soleution.AddRange(state);
            }
            var candidate = GetCandidate(state);
            foreach (var item in candidate)
            {
                state.Add(item);
            }
        }
        //public List<IList<string>> Solve(int n) 
        //{
        //    List<IList<string>> solution = new List<IList<string>> );
        //    List<string> state = new List<string>();
        //    Search(state,solution);
        //    return solution;
        //}
        //public IList<IList<string>> SolveNQueens(int n)
        //{

        //}
    }
    public class BtTemplate1
    {
        private int N;
        public IList<IList<string>> SolveNQueens(int n)
        {
            N = n;
            var res = new List<IList<string>>();
            char[][] board = new char[N][];
            for (int i = 0; i < N; i++)
            {
                board[i] = new char[N];
                Array.Fill(board[i], '.');
            }

            Search(res, board, 0);
            return res;
        }

        private void Search(IList<IList<string>> res, char[][] board, int rowIndex)
        {
            if (rowIndex == N)
            {
                IList<string> list = new List<string>();
                for (int i = 0; i < N; i++)
                {
                    string s = new string(board[i]);
                    list.Add(s);
                }
                res.Add((list));
                return;
            }

            for (int colIndex = 0; colIndex < N; colIndex++)
            {
                if (IsValidState(board, rowIndex, colIndex))
                {
                    board[rowIndex][colIndex] = 'Q';
                    Search(res, board, rowIndex + 1);
                    board[rowIndex][colIndex] = '.';
                }
            }
        }

        private bool IsValidState(char[][] board, int rowIndex, int colIndex)
        {
            for (int i = 0; i < rowIndex; i++)
                if (board[i][colIndex] == 'Q') return false;

            //for (int i = rowIndex - 1, j = colIndex - 1; i >= 0 && j >= 0; i--, j--)


            for (int row = 0; row < rowIndex - 1; row++)
            {
                for (int column = 0; column < colIndex - 1; column++)
                {
                    if (board[row][column] == 'Q') return false;
                }
            }

            for (int row = 0; row <= rowIndex - 1; row++)
            {
                for (int column = colIndex + 1; column < N; column++)
                {
                    if (board[column][row] == 'Q') return false;
                }
            }

           

            return true;
        }
    }
}
