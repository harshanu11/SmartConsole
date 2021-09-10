using System;
using System.Diagnostics;
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
            Debug.WriteLine(f);  // output: 1.3445

            double d = 0.42e2;// E / e
            Debug.WriteLine(d);  // output 42

            decimal m = 1.5E6m;
            Debug.WriteLine(m);  // output: 1500000

            Single s = 22 / 7f;                     //3.142857     10^-6
            double dob = 22 / 7d;                   //3.1428571428571428 10^-16
            decimal dec = 22 / 7m;                  //3.1428571428571428571428571429M 10^-28

            Debug.WriteLine("size of {0} is {1} bytes", typeof(bool), sizeof(bool));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(byte), sizeof(byte));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(char), sizeof(char));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(UInt32), sizeof(UInt32));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(ulong), sizeof(ulong));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(decimal), sizeof(decimal));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(double), sizeof(double));
            Debug.WriteLine("size of {0} is {1} bytes", typeof(float), sizeof(float));
        }
    }
}
