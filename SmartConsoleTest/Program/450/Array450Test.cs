using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DSA450
{
    public class Array450Test
    {
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
            Debug.Write("Reversed array is \n");
        }
        #endregion
        #region Find the maximum and minimum element in an array
        class PairArray
        {
            public int min;
            public int max;
        }
        static PairArray getMinMaxArray(int[] arr, int n)
        {
            PairArray minmax = new PairArray();
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
            PairArray minmax = getMinMaxArray(arr, arr_size);
            Debug.Write(minmax.min);
            Debug.Write(minmax.max);
        }
        #endregion
        #region Find the "Kth" max and min element of an array 
        internal void swap(int[] arr, int l, int r)
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
        public void rearrangeNegativeTest()
        {
            int[] arr = { -1, 2, -3, 4, 5, 6, -7, 8, 9 };
            int n = arr.Length;

            rearrange(arr, n);
        }
        #endregion
    }
}
