using System;
using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class SortingTest {
        [Fact]
        public void MergeSorTest()
        {
			MergeSortOps ms = new MergeSortOps();
			int[] arr = { 12, 11, 13, 5, 6, 7 };
			Console.WriteLine("Given Array");
			ms.printArray(arr);
			ms.sort(arr, 0, arr.Length - 1);
			Console.WriteLine("\nSorted array");
			ms.printArray(arr);
		}
    }
}
