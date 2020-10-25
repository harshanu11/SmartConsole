using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartConsoleTest
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
        }
    } 
}
