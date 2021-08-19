﻿namespace CollectionTest
{
    public class HeapOps
    {

        public void sort(int[] arr)
        {
            int n = arr.Length;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(arr, n, i);

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {
                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // call max heapify on the reduced heap
                heapify(arr, i, 0);
            }
        }

        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        void heapify(int[] arr, int n, int i)
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

        // Function to insert a new node to the Heap
        public void insertNode(int[] arr, int n, int Key)
        {
            // Increase the size of Heap by 1
            n = n + 1;

            // Insert the element at end of Heap
            arr[n - 1] = Key;

            // Heapify the new node following a
            // Bottom-up approach
            heapify(arr, n, n - 1);
        }
        public int deleteRoot(int[] arr, int n)
        {
            // Get the last element
            int lastElement = arr[n - 1];

            // Replace root with first element
            arr[0] = lastElement;

            // Decrease size of heap by 1
            n = n - 1;

            // heapify the root node
            heapify(arr, n, 0);

            // return new size of Heap
            return n;
        }
    }

}