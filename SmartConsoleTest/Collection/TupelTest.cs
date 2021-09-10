using System.Diagnostics;
using System;
using Xunit;

namespace CollectionTest
{
    public class TupelTest
    {
        [Fact]
        public void BasicTupleTest()
        {
            Debug.WriteLine(MyFirstTuple().Item1);
            (double, int) t1 = (4.5, 5);
            Debug.WriteLine(t1.Item1);

        }
        public static (int, int) MyFirstTuple()
        {
            return (4, 5);
        }

    }
}
