using System;
using System.Collections;
using System.Diagnostics;
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

            var query = fruits.Cast<string>().Select(fruit => fruit);

            ArrayList arrList = new ArrayList();

            Debug.WriteLine("Lets start array list");

            arrList.Add("Hi");
            arrList.Add("I am Harsh");

            for (int i = 0; i < arrList.Count; i++)
            {
                Debug.WriteLine(arrList[i]);
            }

        }
    }
}
