using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class ArrayListTest 
	{
		[Fact]
        public void ArrayListMethod() 
		{
            ArrayList fruits = new ArrayList();
            fruits.Add("mango");
            fruits.Add("apple");
            fruits.Add("lemon");

            var  query = fruits.Cast<string>().Select(fruit => fruit);

        }
    }
}
