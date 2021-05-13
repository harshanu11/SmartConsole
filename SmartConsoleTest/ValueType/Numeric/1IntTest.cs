using System;
using System.Globalization;
using System.Numerics;
using Xunit;

namespace Numeric
{
    public class IntTest
    {

        [Fact]
        public void twobyte16BitInt16ShortChar60kVal()
        {
            Int16 bal = Int16.MaxValue;
            Assert.Equal(65536, Math.Pow(2, 16));

        }
        [Fact]
        public void fourByte32BitInt32int()
        {
            Assert.Equal(4294967296, Math.Pow(2, 32));

        }
        [Fact]
        public void AdvanceIntTest()
        {
            var decimalLiteral = 42;
            var hexLiteral = 0x2A;
            var binaryLiteral = 0b_0010_1010;

        }
        [Fact]
        public void NumberMaxTest()
        {
            var maxint16 = Int16.MaxValue;
            var maxint32Long = Int32.MaxValue;

        }
        public static BigInteger BinToDec(string value)
        {
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }

            return res;
        }
    }
}
