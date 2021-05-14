using System;
using Xunit;

namespace Numeric
{
    public class IntTest
    {

        [Fact]
        public void twobyte16BitInt16ShortChar60kVal()
        {
            short s = Int16.MaxValue;
            Int16 bal = Int16.MaxValue;
            Assert.Equal(65536, Math.Pow(2, 16));

            int int32 = Int32.MaxValue;
            Int32 bal32 = Int32.MaxValue;
            Assert.Equal(4294967296, Math.Pow(2, 32));//fourByte32BitInt32int

            long lng = Int64.MaxValue;
            Int64 lng64 = Int64.MaxValue;
            int _id ;
            bool result = Int32.TryParse(356.ToString(), out _id);

        }
    }
}
