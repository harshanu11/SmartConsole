using System;
using System.Collections;
using Xunit;

namespace Numeric
{
    public class ByteTest
    {
        [Fact]
        public void BasicByteTest()
        {
            byte balMax = byte.MaxValue;
            byte balMin = byte.MinValue;
            Assert.Equal(255, balMax);
            Assert.Equal(0, balMin);


            bool[] bools = new bool[] { false, true, true, false, false, false, true, true, false, false, true, true, false, false, false, false, true, false, false, false, true, false, true, true, true, false, true, true, false, false, true, false, true, true, false, true, false, false, true, true, false, true, false, false, false, true, false, true, false, false, false, true, true, false, true, true, false, true, false, false, true, true, false, false };
            BitArray a = new BitArray(bools);
            byte[] bytes = new byte[a.Length / 8];
            a.CopyTo(bytes, 0);

            Console.WriteLine("size of {0} is {1} bytes", typeof(bool), sizeof(bool));
            Console.WriteLine("size of {0} is {1} bytes", typeof(byte), sizeof(byte));
            Console.WriteLine("size of {0} is {1} bytes", typeof(char), sizeof(char));
            Console.WriteLine("size of {0} is {1} bytes", typeof(UInt32), sizeof(UInt32));
            Console.WriteLine("size of {0} is {1} bytes", typeof(ulong), sizeof(ulong));
            Console.WriteLine("size of {0} is {1} bytes", typeof(decimal), sizeof(decimal));
        }

    }
}
