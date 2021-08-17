using System;
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

            countHopt(4, new int[] { 1, 2, 3 });//DistinctOccurrences("banana", new string[] {"ban" ,"b","ba"});

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
    }
}
