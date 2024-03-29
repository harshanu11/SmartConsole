﻿using System.Collections.Generic;

namespace SmartConsoleTest.Dp
{
    public class DpOps
    {

        public static bool CanSum(int n, int[] arr)
        {
            if (n < 0) return false;
            if (n == 0) return true;

            for (int i = 0; i < arr.Length; i++)
            {
                var res = CanSum(n - arr[i], arr);
                if (res == true)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CanSumt(int n, int[] arr)
        {
            bool[] arrTab = new bool[n + 1];
            if (n < 0) return false;
            if (n == 0) return true;

            // seed value 
            arrTab[0] = true;
            for (int i = 0; i < arrTab.Length; i++)
            {
                if (arrTab[i] == true)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (i + arr[j] < n + 1)
                        {
                            arrTab[i + arr[j]] = true;
                        }
                    }
                }

            }
            return arrTab[n];
        }
        public static List<int> HowSum(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) return new List<int>();

            for (int n = 0; n < numbers.Length; n++)
            {
                int rem = sumN - numbers[n];
                var res = HowSum(rem, numbers);
                if (res != null)
                {
                    res.Add(numbers[n]);
                    return res;
                }
            }
            return null;
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
        public static List<int> BestSum(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) { return new List<int>(); };
            List<int> shortest = null;
            for (int n = 0; n < numbers.Length; n++)
            {
                int remender = sumN - numbers[n];
                var remenderCombination = BestSum(remender, numbers);
                if (remenderCombination != null)
                {
                    remenderCombination.Add(numbers[n]);
                    var combination = remenderCombination;
                    // ans.Add(numbers[n]);
                    if (shortest == null || combination.Count < shortest.Count)
                    {
                        shortest = combination;
                    }
                }
            }
            return shortest;
        }
        public static List<int> BestSumSumt(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;

            List<List<int>> table = new List<List<int>>(sumN + 1);
            for (int i = 0; i < sumN + 1; i++)
            {
                table.Add(null);
            }
            // seed val 
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

        public static List<List<int>> allSumList = new List<List<int>>();
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
                    allSumList = localallSumList;
                    if (shortest == null || combination.Count < shortest.Count)
                    {
                        shortest = combination;
                    }
                }
            }
            return shortest;
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
        public static bool CanConstructt(string str, string[] collection)
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
                        if (t + collection[c].Length < table.Length && str.Substring(t, collection[c].Length) == collection[c])
                        {
                            table[t + collection[c].Length] = true;
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
                    count += res;
                }

            }
            return count;
        }
        public static int CountConstructt(string str, string[] collection)
        {
            if (str == "") return 1;
            int[] table = new int[str.Length + 1];
            // seed val 
            table[0] = 1;

            for (int t = 0; t < table.Length; t++)
            {
                if (table[t] > 0)
                {
                    for (int c = 0; c < collection.Length; c++)
                    {
                        if (t + collection[c].Length < table.Length && str.Substring(t, collection[c].Length) == collection[c])
                        {
                            table[t + collection[c].Length] = table[t + collection[c].Length] + table[t];
                        }
                    }
                }
            }

            return table[str.Length];
        }
        
        public static List<List<string>> ansv1 = new List<List<string>>();

        public static List<string> AllConstructv1(string str, string[] collection)
        {
         List<List<string>> _ans = new List<List<string>>();
            if (str == "")
            {
                return new List<string>();
            };
            for (int c = 0; c < collection.Length; c++)
            {
                if (str.IndexOf(collection[c]) == 0)
                {
                    var remender = str.Substring(collection[c].Length);
                    var remenderCombination = AllConstructv1(remender, collection);

                    remenderCombination.Add(collection[c]);//s + "," + 
                    var combination = remenderCombination;
                    _ans.Add(combination);
                    ansv1 = _ans;
                }
            }
            if (ansv1.Count > 0)
            {
                return ansv1[0];
            }
            return null;
        }
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
    }
}
