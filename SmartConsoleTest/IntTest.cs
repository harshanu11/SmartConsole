using System;
using Xunit;

namespace StaticConsoleTest
{
    public class IntTest
    {
        [Fact]
        public void char8Bit()
        {
            Assert.Equal(256, Math.Pow(2, 8));

        }
        [Fact]
        public void twobyte16BitInt16ShortChar()
        {
            Assert.Equal(65536, Math.Pow(2, 16));

        }
        [Fact]
        public void fourByte32BitInt32int()
        {
            Assert.Equal(4294967296, Math.Pow(2, 32));

        }
    }
}
