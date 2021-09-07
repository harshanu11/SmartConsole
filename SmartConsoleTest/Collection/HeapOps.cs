namespace CollectionTest
{
    public class HeapOps
    {

        public void sort(int[] arr)
        {
            int n = arr.Length;

            for (int h = 0; h < n / 2; h++)
            {
                heapify(arr, n, h);
            }

            // One by one extract an element from heap
            //for (int h = 1; h < n-1; h++)
            //{
            //    // Move current root to end
            //    int temp = arr[0];
            //    arr[0] = arr[h];
            //    arr[h] = temp;

            //    // call max heapify on the reduced heap
            //    heapify(arr, h, 0);
            //}
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0);
            }
        }
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
        public void insertNode(int[] arr, int n, int Key)
        {
            arr[n] = Key;
            int i = n;
            while (i > 1)
            {
                int parant = i / 2;
                if (arr[parant] < arr[i])
                {
                    int temp = arr[parant];
                    arr[parant] = arr[i];
                    arr[i] = temp;
                    i = parant;
                }
                else return;
            }
        }
        public int deleteRoot(int[] arr, int n)
        {
            int lastElement = arr[n - 1];
            arr[0] = lastElement;
            n = n - 1;
            heapify(arr, n, 0);
            return n;
        }
    }

}
