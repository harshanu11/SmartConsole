using System;
using System.Collections.Generic;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {
            var numAns = SwapNo(new int[] { 1, 2 });
        }
        public static void OoneC()
        {
            HashSet<int> hs = new HashSet<int>();
            hs.Add(5);
            // it is having one complexity
        }
        public static int[] SwapNo(int[] nums)
        {
            nums[0] = nums[0] ^ nums[1];
            nums[1] = nums[0] ^ nums[1];
            nums[0] = nums[0] ^ nums[1];
            return nums;
        }
        public static int SumToNum(int numToSum)
        {
            // base 
            if (numToSum <= 1) return 1;
            return numToSum + SumToNum(numToSum - 1);
        }
    }

}
