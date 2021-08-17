using System;
using System.Collections.Generic;
using Xunit;

namespace SmartConsoleTest.Dp
{
    public class DpTest
    {
        [Fact]
        public void DPCant()
        {
            var an = DpOps.AllConstruct("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            DpOps.AllConstructt("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            DpOps.CanConstructt("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" });
            var ans = DpOps.AllSum(8, new int[] { 2, 3, 5, 8 });
            var ertert = DpOps.allSumList;
            var ans1 = DpOps.BestSumSumt(7, new int[] { 5, 3, 4 });

            countHop(4, new int[] { 1, 2, 3 });
            countHopt(4, new int[] { 1, 2, 3 });
            MinNumberOfCoins(new int[] { 3, 3, 6 }, 3, 6);
            MinNumberOfCoinst(new int[] { 3, 3, 6 }, 3, 6);
        }

        [Fact]
        public void DPGeek()
        {
            countHopt(4, new int[] { 1, 2, 3 });//DistinctOccurrences("banana", new string[] {"ban" ,"b","ba"});

        }
        public static int countHop(int num, int[] hops)
        {
            int ans = 0;
            if (num < 0) return 0;
            if (num == 0) return 1;
            ans = countHop(num - 1, hops) + countHop(num - 2, hops) + countHop(num - 3, hops);
            return ans;
        }

        public static int countHopt(int num, int[] hops)
        {
            int ans = 0;
            if (num < 0) return 0;
            if (num == 0) return 1;
            int[] table = new int[num + 1];

            // seed 
            table[0] = 1;
            for (int t = 0; t < table.Length; t++)
            {
                if (table[t] != 0)
                {
                    if (t + 1 < table.Length)
                    {
                        table[t + 1] += table[t];
                    }
                    if (t + 2 < table.Length)
                    {
                        table[t + 2] += table[t];
                    }
                    if (t + 3 < table.Length)
                    {
                        table[t + 3] += table[t];
                    }
                }

            }
            return table[num];
        }
        public static List<string> MinNumberOfCoinst(int[] coins, int numberOfCoins, int value)
        {
            if (value == 0) return new List<string>();
            if (value < 0) return null;

            List<string> table = new List<string>();
            // fill the table 
            for (int t = 0; t < value + 1; t++)
            {
                table.Add(null);
            }
            // seed value
            table[0] = "";

            for (int t = 0; t < table.Count; t++)
            {
                if (table[t] != null)
                {
                    for (int c = 0; c < coins.Length; c++)
                    {
                        if (coins[c] + t < table.Count)
                        {
                            table[t + coins[c]] += "[" + table[t] + coins[c] + "]";
                        }
                    }
                }
            }
            return table;
        }

        public static List<int> MinNumberOfCoins(int[] coins, int numberOfCoins, int value)
        {
            if (value < 0) return null;
            if (value == 0) return new List<int>();
            List<int> minSum = new List<int>();
            for (int c = 0; c < numberOfCoins; c++)
            {
                int remender = value - coins[c];
                var remCombination = MinNumberOfCoins(coins, numberOfCoins, remender);
                if (remCombination != null)
                {
                    remCombination.Add(coins[c]);
                    var combination = remCombination;
                    if (minSum.Count == 0 || combination.Count < minSum.Count)
                    {
                        minSum = combination;
                    }
                    // return minSum;
                }
            }
            Console.Write("Not Possible");
            return minSum;
        }
    }
}
