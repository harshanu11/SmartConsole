using System;
using System.Numerics;
using System.Text;
using Xunit;

namespace Program
{
    public class BitManipulation
    {
        [Fact]
        public void BitManipulationTest()
        {
            int N = 1201, M = 8, i = 3, j = 6;
            Console.Write("N = " + N + "(");
            BitMani.bin(N);
            Console.WriteLine(")");

            // print original bitset
            Console.Write("M = " + M + "(");
            BitMani.bin(M);
            Console.WriteLine(")");

            // Call function to 
            // insert M to N
            N = BitMani.insertion(N, M, i, j);
            Console.WriteLine("After inserting M " +
                              "into N from 3 to 6");

            // Print the inserted bitset
            Console.Write("N = " + N + "(");
            BitMani.bin(N);
            Console.WriteLine(")");
        }
        [Fact]
        public void BinaryToStringTest()
        {
            double num1 = 0.625; // Input value in Decimal 
            String output = BinaryToString.printBinary(num1);
            Console.WriteLine("(0 " + output + ") in base 2");

            double num2 = 0.72;
            output = BinaryToString.printBinary(num2);
            Console.WriteLine("(" + output + ") ");
        }
        [Fact]
        public void FlipBitToWinTest()
        {
            // input 1
            Console.WriteLine(FlipBitToWin.flipBit(13));

            // input 2
            Console.WriteLine(FlipBitToWin.flipBit(1775));

            // input 3
            Console.WriteLine(FlipBitToWin.flipBit(15));
        }
        [Fact]
        public void NextNumberWithSame1Test()
        {
            int n = 5; // input 1
            Console.WriteLine(NextNumberWithSame1.getNext(n));

            n = 8; // input 2
            Console.Write(NextNumberWithSame1.getNext(n));
        }
        [Fact]
        public void FlipIntAtoBTest()
        {
            int a = 10;
            int b = 20;
            Console.WriteLine(FlipIntAtoB.FlippedCount(a, b));
        }
        [Fact]
        public void PairwiseSwapTest()
        {
            int x = 23; // 00010111

            // Output is 43 (00101011)
            Console.Write(PairwiseSwap.swapBits(x));
        }
    }

    public class PairwiseSwap
    {

        // Function to swap even
        // and odd bits
        public static long swapBits(int x)
        {
            // Get all even bits of x
            long even_bits = x & 0xAAAAAAAA;

            // Get all odd bits of x
            long odd_bits = x & 0x55555555;

            // Right shift even bits
            even_bits >>= 1;

            // Left shift even bits
            odd_bits <<= 1;

            // Combine even and odd bits
            return (even_bits | odd_bits);
        }

        // Driver program to test above function

    }
    public class FlipIntAtoB
    {

        // Function that count set bits
        public static int countSetBits(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }

        // Function that return
        // count of flipped number
        public static int FlippedCount(int a, int b)
        {
            // Return count of set
            // bits in a XOR b
            return countSetBits(a ^ b);
        }
    }
    public class NextNumberWithSame1
    {

        // Main Function to find next
        // smallest number bigger than n
        public static int getNext(int n)
        {

            /* Compute c0 and c1 */
            int c = n;
            int c0 = 0;
            int c1 = 0;

            while (((c & 1) == 0) && (c != 0))
            {
                c0++;
                c >>= 1;
            }
            while ((c & 1) == 1)
            {
                c1++;
                c >>= 1;
            }

            // If there is no bigger number
            // with the same no. of 1's
            if (c0 + c1 == 31 || c0 + c1 == 0)
                return -1;

            // position of rightmost
            // non-trailing zero
            int p = c0 + c1;

            // Flip rightmost non-trailing
            // zero
            n |= (1 << p);

            // Clear all bits to the right
            // of p
            n &= ~((1 << p) - 1);

            // Insert (c1-1) ones on the
            // right.
            n |= (1 << (c1 - 1)) - 1;

            return n;
        }
    }
    public class BitMani
    {
        public static void bin(long n)
        {
            if (n > 1)
                bin(n / 2);
            Console.Write(n % 2);
        }

        // Insert m into n
        public static int insertion(int n, int m,
                             int i, int j)
        {
            int clear_mask = -1 << (j + 1);
            int capture_mask = (1 << i) - 1;

            // Capturing bits from i-1 to 0
            int captured_bits = n & capture_mask;

            // Clearing bits from j to 0
            n &= clear_mask;

            // Shiftng m to align with n
            m = m << i;

            // Insert m into n
            n |= m;

            // Insert captured bits
            n |= captured_bits;

            return n;
        }
    }
    public class BinaryToString
    {
        // Main function to convert Binary real number 
        // to String 
        public static String printBinary(double num)
        {
            if (num >= 1 || num <= 0)
                return "ERROR";

            StringBuilder binary = new StringBuilder();
            binary.Append(".");

            while (num > 0)
            {
                if (binary.Length >= 32)
                    return "ERROR";
                double r = num * 2;
                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }
            return binary.ToString();
        }
        [Fact]
        public void BinToDec()
        {
            string value = "01001010";
            BigInteger res = 0;
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }
        }
        [Fact]
        public void AdvanceBinaryTest()
        {
            var decimalLiteral = 42;
            var hexLiteral = 0x2A;
            var binaryLiteral = 0b_0010_1010;

        }
    }
    public class FlipBitToWin
    {
        public static int flipBit(int a)
        {
            if (~a == 0)
            {
                return 8 * sizeof(int);
            }

            int currLen = 0, prevLen = 0, maxLen = 0;
            while (a != 0)
            {
                if ((a & 1) == 1)
                {
                    currLen++;
                }

                else if ((a & 1) == 0)
                {
                    prevLen = (a & 2) == 0 ? 0 : currLen;
                    currLen = 0;
                }

                maxLen = Math.Max(prevLen + currLen, maxLen);
                a >>= 1;
            }

            return maxLen + 1;
        }
    }
}
