﻿using Xunit;

namespace CollectionTest
{
    public class HeapTest 
    {
        [Fact]
        public void HeapSortTest()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            int n = arr.Length;

            HeapOps ob = new HeapOps();
            ob.sort(arr);

        }
        [Fact]
        public void HeapAddTest()
        {
            HeapOps ob = new HeapOps();
            int[] arr = { 50, 40, 45, 30, 20, 10, 0 };
            int n = arr.Length;
            ob.insertNode(arr, n-1, 60);

        }
        [Fact]
        public void HeapDeleteTest()
        {
            HeapOps ob = new HeapOps();

            int[] arr = { 10, 5, 3, 2, 4 };
            int n = arr.Length;
            n = ob.deleteRoot(arr, n);

        }
    }

}
