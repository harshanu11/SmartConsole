using System;
using Xunit;

namespace Numeric
{
    public class MathTest
    {
        [Fact]
        public void TwoThePower()
        {

            Assert.Equal(16, Math.Pow(2,4));
            Assert.Equal(16*16, Math.Pow(2,8));// 256
            double charNum = Math.Pow(2, 16);//655536
            charNum = Math.Pow(2, 64);
            Assert.Equal(2, System.Math.Sqrt(4));
        }
        [Fact]
        public void MathFunction() 
        {
            Assert.Equal(-7, Math.Min(-5, -7));
            Assert.Equal(-5, Math.Max(-5, -7));
        }
    } 
}
