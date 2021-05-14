using System;
using System.Numerics;
using Xunit;

namespace Program
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
        [Fact]
        public void Palandrom()
        {

            Assert.Equal(1, CheckPalandromStr("abas7saba"));
            Assert.Equal(0, CheckPalandromStr("abas7seaba"));
            Assert.True(CheckPalandromInt(12321));
        }

        private int CheckPalandromStr(string palan)
        {

            int myChecker = 0;
            for (int i = 0; i < palan.Length / 2; i++)
            {
                if (palan[i] == palan[palan.Length - 1 - i])
                {
                    myChecker += 1;
                }
            }

            if (myChecker == palan.Length / 2)
                return 1;
            else
                return 0;

        }
        private bool CheckPalandromInt(int palan)
        {
            int original = palan;
            int reverse = 0;
            while (palan != 0)
            {
                reverse = 10 * reverse + palan % 10;
                palan /= 10;
            }
            return reverse == original;

        }
        [Fact]
        public void Factorial()
        {
            int res = 1;
            for (int i = 0; i < 10; i++)
            {
                res *= i;
            }
            // res;


        }
        [Fact]
        public void Armstrong()
        {
            // 1 * 1 * 1 + 5 * 5 * 5 + 3 * 3 * 3 = 153

        }

    }
}
