using Program;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {
            decodeString(3, "mnes__ya_____mi");
            solution(3, "mnes__ya_____mi");
            var ans = HowSumT(7, new int[] { 5, 3, 4, 6, 1 });
            var ans1 = BestSumSumt(7, new int[] { 5, 3, 4 });
        }
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
        public static List<int> HowSumt(int sumN, int[] numbers)
        {
            if (sumN < 0) return null;
            if (sumN == 0) return new List<int>();

            for (int n = 0; n < numbers.Length; n++)
            {
                int rem = sumN - numbers[n];
                var res = HowSumt(rem, numbers);
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
