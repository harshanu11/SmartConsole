using System.Diagnostics;
using System;
using Xunit;

namespace CollectionTest
{
    public class QuickSortTest
    {
        public int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                while (numbers[left] < pivot)

                    left++;

                while (numbers[right] > pivot)
                    right--;
                if (left < right)
                {
                    int temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public void SortQuick(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                    SortQuick(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    SortQuick(arr, pivot + 1, right);
            }
        }

        [Fact]
        public void QuickTest()
        {
            Console.Write("\nProgram for sorting a numeric array using Quick Sorting");
            Console.Write("\n\nEnter number of elements: ");
            int max = Convert.ToInt32(5);
            int[] numbers = new int[] { 4, 1, 3, 9, 7 };


            Debug.WriteLine("QuickSort By Recursive Method");
            SortQuick(numbers, 0, max - 1);
            for (int i = 0; i < max; i++)
                Debug.WriteLine(numbers[i]);
        }
    }
}
