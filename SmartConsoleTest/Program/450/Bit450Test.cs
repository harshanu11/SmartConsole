using System;
using Xunit;

namespace DSA450
{
    public class Bit450Test
    {
        #region Count set bits in an integer
        internal virtual int setBits(int N)
        {
            int count = 0;
            while (N > 0)
            {
                N &= (N - 1);
                count++;
            }
            return count;
        }

        #endregion
        #region Find the two non-repeating elements in an array of repeating elements
        static void UniqueNumbersBitwise(int[] arr, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum = (sum ^ arr[i]);
            }
            sum = (sum & -sum);
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] & sum) > 0)
                {

                    // If result > 0 then arr[i] xored
                    // with the sum1
                    sum1 = (sum1 ^ arr[i]);
                }
                else
                {

                    // If result == 0 then arr[i]
                    // xored with sum2
                    sum2 = (sum2 ^ arr[i]);
                }
            }

            // Print the the two unique numbers
            Console.WriteLine("The non-repeating "
                            + "elements are " + sum1 + " and "
                            + sum2);
        }

        [Fact]
        public void UniqueNumbersBitwiseTest()
        {
            int[] arr = { 2, 3, 7, 9, 11, 2, 3, 11 };
            int n = arr.Length;

            UniqueNumbersBitwise(arr, n);
        }
        #endregion
        #region Count number of bits to be flipped to convert A to B
        public int countSetBits1(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        public int countBitsFlip(int a, int b)
        {
            int ans = a ^ b;
            return countSetBits1(ans);
        }

        #endregion
        #region Count total set bits in all numbers from 1 to n
        public int countSetBits(int n)
        {
            n += 1;
            int count = 0;
            for (int x = 2; x / 2 < n; x = x * 2)
            {
                int quotient = n / x;
                count += quotient * x / 2;
                int remainder = n % x;
                if (remainder > x / 2)
                    count += remainder - x / 2;
            }
            return count;
        }
        #endregion
        #region Program to find whether a no is power of two
        public bool isPowerofTwo(long n)
        {
            if (n == 0)
            {
                return false;
            }
            int count = 0;
            while (n > 0)
            {
                //Increment of counter variable if we get 1 as the rightmost bit.
                count += (int)(n & 1);
                //Right Shift n to remove the rightmost bit.
                n >>= 1;
            }
            return count == 1;
        }
        #endregion
    }
}
