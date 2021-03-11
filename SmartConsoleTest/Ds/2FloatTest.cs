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
        }
    }
}
