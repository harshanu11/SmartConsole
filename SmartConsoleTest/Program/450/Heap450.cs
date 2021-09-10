using System;
using Xunit;

namespace DSA450
{
    public class Heap450 {
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
    }
}
