using System;
using System.Collections.Generic;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {
            var aa = allCs;
            var ans = AllConstructt("abcdef", new string[] { "ab", "abc", "def", "abcd", "ef" });
            //var ans = CountSumT(3, new int[] { 3,3,2 });
        }
        static List<List<int>> allC = new List<List<int>>();
        static List<List<string>> allCs = new List<List<string>>();
        public static List<string> AllConstructt(string str, string[] collection)
        {
            List<List<string>> table = new List<List<string>>();
            for (int c = 0; c < str.Length + 1; c++)
            {
                table.Add(new List<string>());
            }
            // seed val
            table[0].Add("");
            for (int t = 0; t < table.Count; t++)
            {
                if (table[t].Count > 0)
                {
                    for (int c = 0; c < collection.Length; c++)
                    {
                        if (t + collection[c].Length < table.Count && str.Substring(t, collection[c].Length) == collection[c])
                        {
                            string inp = "";
                            if (table[t].Count > 0)
                            {
                                for (int nest = 0; nest < table[t].Count; nest++)
                                {
                                    inp = table[t][nest] + ",";
                                    table[t + collection[c].Length].Add(inp + collection[c]);
                                    inp = "";
                                }
                            }
                            else
                            {
                                table[t + collection[c].Length].Add(inp + collection[c]);

                            }
                        }
                    }
                }
            }
            return table[str.Length];
        }
        public static List<string> AllConstruct(string str, string[] collection)
        {
            List<List<string>> _ans = new List<List<string>>();
            if (str == "") return new List<string>();
            for (int c = 0; c < collection.Length; c++)
            {
                if (str.IndexOf(collection[c])== 0)
                {
                    var remender = str.Substring(collection[c].Length);
                    var remenderCombination = AllConstruct(remender,collection);
                    if (remenderCombination != null)
                    {
                        remenderCombination.Add(collection[c]);
                        var combination = remenderCombination;
                        _ans.Add(combination);
                        allCs = _ans;
                    }
                }
            }
            if (allCs.Count >0)
            {
                return allCs[0];
            }
            return null;
        }
        public static int CountConstructT(string str, string[] collection)
        {
            int count = 0;
            if (str == "") return 1;
            int[] table = new int[str.Length + 1];
            // seed
            table[0] = 1;

            for (int t = 0; t < table.Length; t++)
            {
                if (table[t] != 0)
                {
                    for (int c = 0; c < collection.Length; c++)
                    {
                        if (t + collection[c].Length < table.Length)
                        {
                            if (str.Substring(t, collection[c].Length) == collection[c])
                            {
                                table[t + collection[c].Length] += table[t];
                            }
                        }
                    }
                }
            }


            return table[str.Length];
        }
        public static int CountConstruct(string str, string[] collection)
        {
            int count = 0;
            if (str == "") return 1;
            for (int c = 0; c < collection.Length; c++)
            {
                if (str.IndexOf(collection[c]) == 0)
                {
                    var s = str.Substring(collection[c].Length);
                    var res = CountConstruct(s, collection);
                    if (res == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public static bool CanConstructT(string str, string[] collection)
        {
            if (str == "") return true;
            bool[] table = new bool[str.Length + 1];
            // seed val
            table[0] = true;
            for (int t = 0; t < table.Length; t++)
            {
                if (table[t] == true)
                {
                    for (int c = 0; c < collection.Length; c++)
                    {
                        if (t + collection[c].Length < table.Length)
                        {
                            if (collection[c] == str.Substring(t, collection[c].Length))
                            {
                                table[t + collection[c].Length] = true;
                            }
                        }
                    }
                }
            }
            return table[str.Length];

        }
        public static bool CanConstruct(string str, string[] collection)
        {
            if (str == "") return true;
            for (int c = 0; c < collection.Length; c++)
            {
                if (str.IndexOf(collection[c]) == 0)
                {
                    var s = str.Substring(collection[c].Length);
                    var res = CanConstruct(s, collection);
                    if (res == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static List<int> AllSum(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) { return new List<int>(); };
            List<int> shortest = null;
            List<List<int>> localallSumList = new List<List<int>>();
            for (int n = 0; n < numbers.Length; n++)
            {
                int remender = sumN - numbers[n];
                var remenderCombination = AllSum(remender, numbers);
                if (remenderCombination != null)
                {
                    remenderCombination.Add(numbers[n]);
                    var combination = remenderCombination;
                    localallSumList.Add(combination);
                    allC = localallSumList;
                    if (shortest == null || combination.Count < shortest.Count)
                    {
                        shortest = combination;
                    }
                }
            }
            return shortest;
        }
        //public static List<int> AllSumT(int sumN, int[] numbers) { }
        public static List<int> BestSumT(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) return new List<int>();
            List<List<int>> table = new List<List<int>>();
            for (int t = 0; t < sumN + 1; t++)
            {
                table.Add(null);
            }
            table[0] = new List<int>();
            for (int t = 0; t < table.Count; t++)
            {
                if (table[t] != null)
                {
                    for (int n = 0; n < numbers.Length; n++)
                    {
                        if (t + numbers[n] < table.Count)
                        {
                            var l = new List<int>();
                            l.Add(numbers[n]);
                            if (table[t].Count > 0)
                            {
                                l.AddRange(table[t]);
                            }
                            if (table[t + numbers[n]] == null || table[t + numbers[n]].Count > l.Count)
                            {
                                table[t + numbers[n]] = l;
                            }
                        }
                    }
                }
            }
            return table[sumN];
        }
        public static List<int> BestSum(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) return new List<int>();
            List<int> shortest = null;
            for (int s = 0; s < sumN; s++)
            {
                for (int n = 0; n < numbers.Length; n++)
                {
                    var rem = sumN - numbers[n];
                    var remComb = BestSum(rem, numbers);
                    if (remComb != null)
                    {
                        remComb.Add(numbers[n]);
                        var comb = remComb;
                        if (shortest == null || comb.Count < shortest.Count)
                        {
                            shortest = comb;
                        }
                    }
                }
            }
            return shortest;
        }
        public static string HowSumT(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            string[] table = new string[sumN + 1];
            table[0] = "";
            for (int t = 0; t < table.Length; t++)
            {
                if (table[t] != null)
                {
                    for (int n = 0; n < numbers.Length; n++)
                    {
                        if (t + numbers[n] < table.Length)
                        {
                            table[t + numbers[n]] = table[t + numbers[n]] + numbers[n];
                        }
                        if (t + numbers[n] == sumN)
                        {
                            break;
                        }

                    }
                }
            }
            return table[sumN];
        }
        public static List<int> HowSum(int num, int[] arr)
        {
            if (num == 0) return new List<int>();
            if (num < 0) return null;
            for (int a = 0; a < arr.Length; a++)
            {
                int remender = num - arr[a];
                var remCom = HowSum(remender, arr);
                if (remCom != null)
                {
                    remCom.Add(arr[a]);
                    return remCom;
                }
            }
            return null;
        }
        public static int CountSumT(int num, int[] arr)
        {
            if (num == 0) return 1;
            if (num < 0) return 0;
            int[] tbl = new int[num + 1];
            tbl[0] = 1;
            for (int t = 0; t < tbl.Length; t++)
            {
                if (tbl[0] != 0)
                {
                    for (int a = 0; a < arr.Length; a++)
                    {
                        if (t+arr[a]< tbl.Length)
                        {
                            if (num == t+arr[a])
                            {
                                tbl[t + arr[a]] += 1;
                            }
                        }
                    }
                }
            }
            return tbl[num];
        }
        public static int CountSum(int num, int[] arr)
        {
            if (num == 0) return 1;
            if (num < 0) return 0;
            int ans1 = 0;
            for (int a = 0; a < arr.Length; a++)
            {
                if (CountSum(num - arr[a], arr) == 1)
                { ans1++; }

            }
            return ans1;
        }
        public static bool CanSumT(int num, int[] numbers)
        {
            if (num == 0) return true;
            if (num < 0) return false;

            bool[] table = new bool[num + 1];
            table[0] = true;
            for (int n = 0; n < num; n++)
            {
                if (table[n] == true)
                {
                    for (int a = 0; a < numbers.Length; a++)
                    {
                        if (n + numbers[a] < num)
                        {
                            table[n + numbers[n]] = true;
                        }
                    }
                }
            }
            return table[num];
        }
        public static bool CanSum(int num, int[] arr)
        {
            if (num == 0) return true;
            if (num < 0) return false;

            for (int n = 0; n < arr.Length; n++)
            {
                var rem = CanSum(num - arr[n], arr);
                if (rem == true)
                {
                    return true;
                }
            }
            return false;
        }
        public static int GridT(int m, int n)
        {
            if (m == 1 && n == 1) return 1;
            if (m <= 0 || n <= 0) return 0;
            int[,] table = new int[m + 1, n + 1];
            table[1, 1] = 1;
            for (int row = 0; row <= m; row++)
            {
                for (int column = 0; column <= n; column++)
                {
                    if (row < m)
                    {
                        table[row + 1, column] += table[row, column];
                    }
                    if (column < n)
                    {
                        table[row, column + 1] += table[row, column];
                    }
                }
            }
            return table[m, n];
        }
        public static int Grid(int row, int col)
        {
            if (row == 1 && col == 1) return 1;
            if (row <= 0 || col <= 0) return 0;
            return Grid(row - 1, col) + Grid(row, col - 1);
        }
        public static bool IsPaliT(string str)
        {
            if (str.Length <= 1) return true;
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsPali(string str)
        {
            if (str.Length <= 1) return true;
            if (str[0] == str[str.Length - 1])
            {
                return IsPali(str.Substring(1, str.Length - 2));
            }
            return false;
        }
        public static int DecBinNumT(int num)
        {
            int[] dp = new int[32];
            int i = 0;
            while (num > 0)
            {
                dp[i] = num % 2;
                num = num >> 1;
                Console.Write(dp[i]);
                i++;
            }
            return 0;
        }
        public static int DecBinNum(int num)
        {
            if (num == 0) return 0;
            return (num % 2 + 10 * DecBinNum(num / 2));
        }
        public static int FabNumT(int num)
        {
            if (num <= 1) return 1;
            int[] tbl = new int[num + 2];
            Array.Fill(tbl, 0);
            tbl[1] = 1;
            for (int t = 0; t < num; t++)
            {
                if (tbl[t] >= 1)
                {
                    tbl[t + 1] += tbl[t];
                    tbl[t + 2] += tbl[t];
                }
            }
            return tbl[num];
        }
        public static int FabNum(int num)
        {
            if (num <= 2) return 1;
            return FabNum(num - 1) + FabNum(num - 2);
        }
        public static int sumNumT(int num)
        {
            if (num <= 1) return 1;
            int[] table = new int[num + 1];
            Array.Fill(table, 1);
            for (int t = 0; t < num; t++)
            {
                table[t + 1] += table[t];
            }
            table[num] = 0;
            for (int t = 0; t < num; t++)
            {
                table[num] += table[1];
            }
            return table[num];
        }
        public static int sumNum(int num)
        {
            if (num <= 1) return 1;
            return num + sumNum(num - 1);
        }
    }

}
