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
        }
    }
}
