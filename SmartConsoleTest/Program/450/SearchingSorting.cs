using System.Diagnostics;
using System;
using Xunit;

namespace DSA450
{
    class PairSearchSort
    {
        public int min;
        public int max;
    }
    public class SearchingSorting {
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
                Debug.WriteLine("First "
                                + "Occurrence = " + first);
                Debug.Write("Last "
                            + "Occurrence = " + last);
            }
            else
                Debug.Write("Not Found");
        }

        // Driver code
        [Fact]
        public void FindfirstandlastpositionsTest()
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
        public void FixedPointTest()
        {
            int[] arr = { -10, -1, 0, 3, 10, 11, 30, 50, 100 };
            int n = arr.Length;
            Debug.Write("Fixed Point is " + linearSearch(arr, n));
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

        [Fact]
        public void floorSqrtTest()
        {
            int x = 11;
            Debug.WriteLine(floorSqrt(x));
        }
        #endregion
        #region Maximum and minimum of an array using minimum number of comparisons
        static PairSearchSort getMinMax(int[] arr, int n)
        {
            PairSearchSort minmax = new PairSearchSort();
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

        [Fact]
        public void getMinMaxTest1()
        {
            int[] arr = { 1000, 11, 445, 1, 330, 3000 };
            int arr_size = 6;
            PairSearchSort minmax = getMinMax(arr, arr_size);
            Debug.Write(minmax.min);
            Debug.Write(minmax.max);
        }
        #endregion
        #region Merge 2 sorted arrays without using Extra space.
        public static int nextGap(int gap)
        {
            if (gap <= 1) return 0;
            return (gap / 2) + (gap % 2);
        }
        static void merge(int[] arr1, int[] arr2, int n, int m)
        {
            int i, j, gap = n + m, tmp;
            for (gap = nextGap(gap); gap > 0; gap = nextGap(gap))
            {
                for (i = 0; i + gap < n; i++)
                {
                    if (arr1[i] > arr1[i + gap])
                    {
                        tmp = arr1[i];
                        arr1[i] = arr1[i + gap];
                        arr1[i + gap] = tmp;
                    }
                }

                for (j = gap > n ? gap - n : 0; i < n && j < m; i++, j++)
                {
                    if (arr1[i] > arr2[j])
                    {
                        tmp = arr1[i];
                        arr1[i] = arr2[j];
                        arr2[j] = tmp;
                    }
                }

                if (j < m)
                {
                    for (j = 0; j + gap < m; j++)
                    {
                        if (arr2[j] > arr2[j + gap])
                        {
                            tmp = arr2[j];
                            arr2[j] = arr2[j + gap];
                            arr2[j + gap] = tmp;
                        }
                    }
                }
            }
        }
        [Fact]
        public  void Main()
        {
            merge(new int[] { 1, 3, 5, 7 }, new int[] { 0, 2, 6, 8, 9 }, 4, 5);
        }
        #endregion
    }
}
