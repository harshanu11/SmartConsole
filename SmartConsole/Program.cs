using Program;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {



            //var an = CountConstruct("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" });
            var an = AllConstruct("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            AllConstructt("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            CanConstructt("abcdef", new String[] { "ab", "abc", "cd", "def", "abcd" });
            decodeString(3, "mnes__ya_____mi");
            solution(3, "mnes__ya_____mi");
            var ans = AllSum(8, new int[] { 2, 3, 5,8});
            var ertert = allSumList;
            var ans1 = BestSumSumt(7, new int[] { 5, 3, 4 });
        }

        static List<List<int>> allSumList = new List<List<int>>();
        

        static List<string> ans = new List<string>();
        static Dictionary<int, int> memo = new Dictionary<int, int>();
        static Dictionary<string, int> memo1 = new Dictionary<string, int>();
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

            // seed val 
            table[0] = "";
            for (int t = 0; t < table.Length; t++)
            {

                if (table[t] != null)
                {
                    for (int n = 0; n < numbers.Length; n++)
                    {
                        if (t + numbers[n] < table.Length)
                        {
                            table[t + numbers[n]] = table[t + numbers[n]] + numbers[n] + " ";
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
        public static List<int> BestSumSumtt(int sumN, int[] numbers)
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
        public static List<int> AllSum(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) { return new List<int>(); };
            List<int> shortest = null;
            List<List<int>> ansq = new List<List<int>>();
            for (int n = 0; n < numbers.Length; n++)
            {
                int remender = sumN - numbers[n];
                var remenderCombination = AllSum(remender, numbers);
                if (remenderCombination != null)
                {
                    remenderCombination.Add(numbers[n]);
                    var combination = remenderCombination;
                    ansq.Add(combination);
                    allSumList = ansq;
                    // ans.Add(numbers[n]);
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
        public static string AllConstruct(string str, string[] collection)
        {
            if (str == "")
            {
                return "";
            };
            for (int c = 0; c < collection.Length; c++)
            {
                if (str.IndexOf(collection[c]) == 0)
                {
                    var s = str.Substring(collection[c].Length);
                    ans.Add(collection[c]);//s + "," + 
                    ans.Add(AllConstruct(s, collection));
                }
            }
            return "";
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
        public static String solution(int numberOfRows, String encodedString)
        {
            int originalLength = encodedString.Length;
            char[] arr = new char[((originalLength / numberOfRows) + 1) * numberOfRows];

            for (int i = 0; i < originalLength; i++)
            {
                arr[i] = encodedString[i];
            }

            int length = encodedString.Length;
            int arrLength = length / numberOfRows;
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = '_';
            }

            StringBuilder decodedString = new StringBuilder();
            int numberOfCols = originalLength / numberOfRows + 1;
            int loop = numberOfCols - numberOfRows + 1;

            for (int j = 0; j < loop; j++)
            {
                for (int i = 0; i < numberOfRows; i++)
                {
                    decodedString.Append(arr[i * numberOfCols + j] == '_' ? ' ' : arr[i * numberOfCols + j]);
                }
            }

            return decodedString.ToString().Trim();
        }
        public static String decodeString(int numberOfRows, String encodedString)
        {
            if (encodedString == null)
            {
                return null;
            }
            int length = encodedString.Length;
            int arrLength = length / numberOfRows;
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = '_';
            }
            int k = 0;
            int newIndex = 0;
            for (int i = 0; i < arrLength; i++)
            {
                result[k++] = encodedString[i];
                while (newIndex <= length)
                {
                    newIndex = newIndex + arrLength + 1;
                    if (newIndex < length)
                    {
                        result[k++] = encodedString[newIndex];
                    }
                }
                newIndex = i + 1;

            }
            String decodedString = new String(result);
            decodedString = decodedString.Replace("_", " ");
            return decodedString.Trim();
        }
    }

}
