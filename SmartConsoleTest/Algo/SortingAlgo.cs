namespace CollectionTest
{
    public class SortingAlgo 
	{
        public static void BubbleSort(int[] a)
        {
            int numberOfSwaps = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        var temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        numberOfSwaps++;
                    }
                }
                if (numberOfSwaps == 0)
                {
                    break;
                }
            }
        }
        public static void Insertionsort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        public static void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j]) { arr[k] = L[i]; i++; }
                else { arr[k] = R[j]; j++; }
                k++;
            }
            while (i < n1) { arr[k] = L[i]; i++; k++; }
            while (j < n2) { arr[k] = R[j]; j++; k++; }
        }
        public static void mergesort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                mergesort(arr, l, m);
                mergesort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }

    }
}
