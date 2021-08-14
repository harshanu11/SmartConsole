using Xunit;

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
    }

}
