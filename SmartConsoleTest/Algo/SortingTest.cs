using System;
using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class SortingTest {
        [Fact]
        public void MergeSorTest()
        {
		
			int[] arr = { 12, 11, 13, 5, 6, 7 };
			Console.WriteLine("Given Array");
            SortingAlgo.mergesort(arr, 0, arr.Length - 1);
			Console.WriteLine("\nSorted array");
		}
        [Fact]
        public void BubbleSortTest()
        {
            int[] arr = { 12, 11, 13, 5, 6 };
            SortingAlgo.BubbleSort(arr);
        }
        [Fact]
        public void InsertionSortTest()
        {
            int[] arr = { 12, 11, 13, 5, 6 };
            SortingAlgo.Insertionsort(arr);
        }
    }
}
