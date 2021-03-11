using System;
using Xunit;

namespace ValueTypeTest
{
    public class CharTest
    {
        [Fact]
        public void char2Byte()
        {
            // 60k value
            Assert.Equal(256, Math.Pow(2, 8));

        }
    }
}
