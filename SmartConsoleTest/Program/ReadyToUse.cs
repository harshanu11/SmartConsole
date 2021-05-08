using System;
using System.Numerics;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class ReadyToUse
    {
        [Fact]
        public void VeryLargeBinToDec()
        {
            string value = "100000101";
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }
            BinToDec("10101");
        }

        public static BigInteger BinToDec(string value)
        {
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;
            BigInteger max = 0;
            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                if (c == '1')
                {
                    res = BigInteger.Parse(res.ToString() + "1");
                    if (res > max)
                        max = res;
                }
                else
                {
                    res = BigInteger.Parse(res.ToString() + "0");
                    if (res > max)
                        max = res;
                }
            }

            return max;
        }
        public static void AllReadyToUse() 
        {
            Console.WriteLine(Convert.ToString(100, toBase: 2));//1100100
            Console.WriteLine(Convert.ToString(100, toBase: 8));//144
            Console.WriteLine(Convert.ToString(100, toBase: 10));//100
            Console.WriteLine(Convert.ToString(100, toBase: 16));//64
        }

    }
}
