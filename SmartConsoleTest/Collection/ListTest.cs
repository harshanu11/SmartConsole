using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class ListTest 
    {
        [Fact]
        public void ListMethodTest()
        {
            List<string> fruits = new List<string>();
            fruits.Add("mango");
            fruits.Add("apple");
            fruits.Add("lemon");
        }
    }
}
