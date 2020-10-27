using System;
using System.Globalization;
using Xunit;

namespace StaticConsoleTest
{
    public class IntTest
    {

        [Fact]
        public void twobyte16BitInt16ShortChar60kVal()
        {
            Int16 bal = Int16.MaxValue;
            Assert.Equal(65536, Math.Pow(2, 16));
            double d = 0.42e2;
            Console.WriteLine(d);  // output 42

            double dt = (double)dd.Millisecond*1e3+ (double)dd.Second * 1e5+ (double)dd.Minute * 1e7+ (double)dd.Hour * 1e9+ (double)dd.Day * 1e11
                + (double)dd.Month * 1e13 + (double)dd.Year * 1e15;
            float f = 134.45E-2f;
            Console.WriteLine(f);  // output: 1.3445

            decimal m = 1.5E6m;
            Console.WriteLine(m);  // output: 1500000
        }
        [Fact]
        public void fourByte32BitInt32int()
        {
            Assert.Equal(4294967296, Math.Pow(2, 32));

        }
    }
}
