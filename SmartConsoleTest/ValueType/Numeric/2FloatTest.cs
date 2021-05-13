using System;
using Xunit;

namespace Numeric
{
    public class FloatTest
    {
        [Fact]
        public void BasivFloatTest()
        {

            double d = 0.42e2;
            Console.WriteLine(d);  // output 42


            float f = 134.45E-2f;
            Console.WriteLine(f);  // output: 1.3445

            decimal m = 1.5E6m;
            Console.WriteLine(m);  // output: 1500000

            Console.WriteLine("size of {0} is {1} bytes", typeof(bool), sizeof(bool));
            Console.WriteLine("size of {0} is {1} bytes", typeof(byte), sizeof(byte));
            Console.WriteLine("size of {0} is {1} bytes", typeof(char), sizeof(char));
            Console.WriteLine("size of {0} is {1} bytes", typeof(UInt32), sizeof(UInt32));
            Console.WriteLine("size of {0} is {1} bytes", typeof(ulong), sizeof(ulong));
            Console.WriteLine("size of {0} is {1} bytes", typeof(decimal), sizeof(decimal));
        }
    }
}
