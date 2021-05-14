using System;
using Xunit;

namespace Numeric
{
    public class FloatTest
    {
        [Fact]
        public void BasivFloatTest()
        {
            // single4 double8 decimal 16

            float f = 134.45E-2f;
            Console.WriteLine(f);  // output: 1.3445

            double d = 0.42e2;// E / e
            Console.WriteLine(d);  // output 42

            decimal m = 1.5E6m;
            Console.WriteLine(m);  // output: 1500000

            Single s = 22 / 7f;                     //3.142857     10^-6
            double dob = 22 / 7d;                   //3.1428571428571428 10^-16
            decimal dec = 22 / 7m;                  //3.1428571428571428571428571429M 10^-28

            Console.WriteLine("size of {0} is {1} bytes", typeof(bool), sizeof(bool));
            Console.WriteLine("size of {0} is {1} bytes", typeof(byte), sizeof(byte));
            Console.WriteLine("size of {0} is {1} bytes", typeof(char), sizeof(char));
            Console.WriteLine("size of {0} is {1} bytes", typeof(UInt32), sizeof(UInt32));
            Console.WriteLine("size of {0} is {1} bytes", typeof(ulong), sizeof(ulong));
            Console.WriteLine("size of {0} is {1} bytes", typeof(decimal), sizeof(decimal));
            Console.WriteLine("size of {0} is {1} bytes", typeof(double), sizeof(double));
            Console.WriteLine("size of {0} is {1} bytes", typeof(float), sizeof(float));
        }
    }
}
