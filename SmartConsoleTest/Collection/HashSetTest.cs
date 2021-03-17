using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class HashSetTest 
    {
        [Fact]
        public void HashSet()
        {
            HashSet<int> my_first_hashSet = new HashSet<int>();

            if (my_first_hashSet.Contains(9))
            {
                my_first_hashSet.Remove(9);
            }
            else
            {
                my_first_hashSet.Add(9);
            }
            int n = 9;
            int[] arr = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };
            HashSet<int> hs = new HashSet<int>();
            int numOfPair = 0;

            for (int i = 0; i < 9; i++)
            {
                if (!hs.Contains(arr[i])) { hs.Add(arr[i]); }
                else
                {
                    numOfPair++;
                    hs.Remove(arr[i]);
                }

            }

        }

    }

}
