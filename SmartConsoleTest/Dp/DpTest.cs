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
            var ddd = DpOps.ansv1;
            var an = DpOps.AllConstructv1("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            DpOps.AllConstructt("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            DpOps.CanConstructt("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" });
            var allsum = DpOps.allSumList;
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
            var ans = MaxAmount(new int[] { 5, 3, 7, 10 }, 0);

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
        static List<int> HowMumNumberOfCoins(int[] coins, int numberOfCoins, int value)
        {
            if (value < 0) return null;
            if (value == 0) return new List<int>();
            for (int c = 0; c < numberOfCoins; c++)
            {
                int remender = value - coins[c];
                var isAllowed = HowMumNumberOfCoins(coins, numberOfCoins, remender);
                if (isAllowed != null)
                {
                    isAllowed.Add(coins[c]);
                    return isAllowed;
                }
            }
            Console.Write("Not Possible");
            return null;
        }
        static bool isminimumNumberOfCoins(int[] coins, int numberOfCoins, int value)
        {
            if (value < 0) return false;
            if (value == 0) return true;
            for (int c = 0; c < numberOfCoins; c++)
            {
                int remender = value - coins[c];
                var isAllowed = isminimumNumberOfCoins(coins, numberOfCoins, remender);
                if (isAllowed)
                {
                    return true;
                }
            }
            Console.Write("Not Possible");
            return false;
        }

        public static List<string> AllMinimumJumpsT(int[] arr, int num)
        {
            List<List<string>> table = new List<List<string>>();
            // fill the table 
            for (int t = 0; t < arr.Length + 1; t++)
            {
                table.Add(new List<string>());
            }
            // seed val
            table[0].Add("");
            for (int t = 0; t < table.Count; t++)
            {
                if (table[t].Count > 0)
                {
                    string input = "";
                    for (int n = 0; n < arr.Length; n++)
                    {
                        if (t + arr[n] < table.Count)
                        {
                            if (table[t].Count > 0)
                            {
                                for (int tt = 0; tt < table[t].Count; tt++)
                                {
                                    table[t + arr[n]].Add(table[t][tt] + "," + arr[n]);
                                }
                            }
                            else
                            {
                                table[t + arr[n]].Add(input + arr[n]);
                            }
                        }

                    }
                }
            }
            return table[11];
        }

        static List<List<int>> allSumList = new List<List<int>>();
        public static List<int> AllMinimumJumps(int[] arr, int num)
        {
            List<List<int>> _allSumList = new List<List<int>>();
            if (arr[arr.Length - 1] == num) return new List<int>();
            if (arr[arr.Length - 1] < num) return null;
            var bestJump = new List<int>();
            for (int n = 0; n < arr.Length; n++)
            {
                var remender = num + arr[n];
                var remenderCombination = AllMinimumJumps(arr, remender);
                if (remenderCombination != null)
                {
                    remenderCombination.Add(arr[n]);
                    var combination = remenderCombination;
                    _allSumList.Add(combination);
                    allSumList = _allSumList;
                    if (bestJump.Count == 0 || combination.Count < bestJump.Count)
                    {
                        bestJump = combination;
                    }
                }
            }
            return bestJump;
        }

        public static List<int> HowMinimumJumps(int[] arr, int num)
        {
            if (arr[arr.Length - 1] == num) return new List<int>();
            if (arr[arr.Length - 1] < num) return null;

            for (int n = 0; n < arr.Length; n++)
            {
                var remender = num + arr[n];
                var result = HowMinimumJumps(arr, num + arr[n]);
                if (result != null)
                {
                    result.Add(arr[n]);
                    return result;
                }
            }
            return null;
        }

        public static bool IsminimumJumps(int[] arr, int num)
        {
            if (arr[arr.Length - 1] == num) return true;
            if (arr[arr.Length - 1] < num) return false;

            for (int n = 0; n < arr.Length; n++)
            {
                var result = IsminimumJumps(arr, num + arr[n]);
                if (result)
                {
                    return true;
                }
            }
            return false;
        }
        static List<long> sums = new List<long>();
        public static long MaxAmount(int[] coins, int max)
        {

            if (coins.Length == 0) return max;
            for (int c = 0; c < coins.Length / 2; c++)
            {
                var remender = coins[0] + coins[coins.Length - 1];
                sums.Add(remender);
                var temp = new int[coins.Length / 2];
                if (temp.Length >= 2)
                {
                    for (int tt = 0; tt < temp.Length; tt++)
                    {
                        temp[tt] = coins[tt + 1];
                    }
                    var remeCombination = MaxAmount(temp, remender);
                }
                if (max < remender)
                {
                    max = remender;
                }
            }
            return max;
        }
    }
}
