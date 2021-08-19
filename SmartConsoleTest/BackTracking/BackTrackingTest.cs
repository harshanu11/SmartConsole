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
            BtTemplateSudoku s = new BtTemplateSudoku();
            char[,] board = new char[9, 9] {
                                            {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                                            {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                                            {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                                            {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                                            {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                                            {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                                            {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                                            {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                                            {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
                                            };

            var asn = b.SolveNQueens(4);
            var sudoku = s.SolveSudoku(board);
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
    public class BtTemplateSudoku
    {

        private char[,] _board;
        public char[,]  SolveSudoku(char[,] board)
        {
            _board = board;
            SolveSudoku(0, 0);
            return _board;
        }

        private bool SolveSudoku(int ri, int ci)
        {
            if (ri > 8)
                return true;

            bool success = false;
            var nextIndex = GetNextIndex(ri, ci);

            if (_board[ri,ci] != '.')
                success = SolveSudoku(nextIndex[0], nextIndex[1]);
            else
            {
                var possibleMoves = GetPossibleMoves(ri, ci);
                foreach (var pm in possibleMoves)
                {
                    _board[ri,ci] = pm;
                    if (!SolveSudoku(nextIndex[0], nextIndex[1]))
                    {
                        _board[ri,ci] = '.';
                    }
                    else
                    {
                        success = true;
                        break;
                    }
                }
            }

            return success;
        }

        private int[] GetNextIndex(int ri, int ci)
        {
            if (ci == 8)
                return new int[] { ri + 1, 0 };
            else
                return new int[] { ri, ci + 1 };

        }

        private IList<char> GetPossibleMoves(int ri, int ci)
        {
            var moves = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                if (_board[ri,i] != '.')
                {
                    var index = Convert.ToInt16(_board[ri,i]) - 48;
                    moves[index] = 0;
                }
            }

            for (int j = 0; j < 9; j++)
            {
                if (_board[j,ci] != '.')
                {
                    var index = Convert.ToInt16(_board[j,ci]) - 48;
                    moves[index] = 0;
                }
            }

            var rowRange = GetRanges(ri);
            var colRange = GetRanges(ci);

            for (int u = rowRange[0]; u <= rowRange[1]; u++)
            {
                for (int v = colRange[0]; v <= colRange[1]; v++)
                {
                    if (_board[u,v] != '.')
                    {
                        var index = Convert.ToInt16(_board[u,v]) - 48;
                        moves[index] = 0;
                    }
                }
            }

            var retVal = new List<char>();
            for (int m = 1; m <= 9; m++)
            {
                if (moves[m] != 0)
                {
                    retVal.Add(Convert.ToChar(m + 48));
                }
            }
            return retVal;
        }

        private int[] GetRanges(int input)
        {
            if (input >= 0 && input <= 2)
                return new int[] { 0, 2 };

            if (input >= 3 && input <= 5)
                return new int[] { 3, 5 };

            if (input >= 6 && input <= 8)
                return new int[] { 6, 8 };

            return new int[] { 0, 0 };
        }
    }

}
