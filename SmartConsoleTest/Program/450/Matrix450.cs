using System.Diagnostics;
using System;
using Xunit;

namespace DSA450
{
    public class Matrix450
    {
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
        public int rowWithMax1s(int[][] mat)
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

        [Fact]
        public void rowWithMax1sTest()
        {
            int[][] mat = new int[][]
            {
        new int[] {0, 0, 0, 1},
        new int[] {0, 1, 1, 1},
        new int[] {1, 1, 1, 1},
        new int[] {0, 0, 0, 0}
            };
            Debug.WriteLine("Index of row with maximum 1s is " +
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
                Debug.WriteLine();
            }
        }

        [Fact]
        public void printMatTest()
        {
            int[,] mat = { { 5, 4, 7 },
                        { 1, 3, 8 },
                        { 2, 9, 6 } };
            int n = 3;

            Debug.WriteLine("Original Matrix:");
            printMat(mat, n);

            sortMat(mat, n);

            Debug.WriteLine("Matrix After Sorting:");
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

        [Fact]
        public void spiralPrintTest()
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

        [Fact]
        public void binaryMedianTest()
        {
            int r = 3, c = 3;
            int[,] m = {{1,3,5},
            {2,6,9},
            {3,6,9} };

            Debug.WriteLine("Median is " +
                                binaryMedian(m, r, c));
        }
        #endregion
    }

}
