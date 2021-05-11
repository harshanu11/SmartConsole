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
            else if (my_first_hashSet.Add(15))
            {

            }
            else
            {
                my_first_hashSet.Add(9);
            }
        }

    }

}
