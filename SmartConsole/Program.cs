using System;
using System.Collections.Generic;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {
            var ans = HowSumT(3, new int[] { 3, 3, 3 });
        }
        public static string HowSumT(int num, int[] numbers)
        {
            
            if (num < 0) return null;
            string[] table = new string[num + 1];
            table[0] = "";
            for (int t = 0; t < table.Length; t++)
            {
                if (table[t]!= null)
                {
                    for (int n = 0; n < numbers.Length; n++)
                    {
                        if (t + numbers[n] <table.Length)
                        {
                            table[t + numbers[n]] = table[t + numbers[n]] + numbers[n];
                        }
                    }
                }
            }
            return table[num];
        }
        public static List<int> HowSum(int num, int[] arr) 
        {
            if (num == 0) return new List<int>() ;
            if (num < 0) return null;
            for (int i = 0; i < arr.Length; i++)
            {
                int remender = num - arr[i];
                var remCom = HowSum(remender,arr);
                if (remCom != null)
                {
                    remCom.Add(arr[i]);
                    return remCom;
                }
            }
            return null;
        }
        public static int CountSumT(int num, int[] arr)
        {
            if (num == 0) return 1;
            if (num < 0) return 0;
            int[] dp = new int[num + 1];

            return 0;
        }
        public static int CountSum(int num, int[] arr)
        {
            if (num == 0) return 1;
            if (num < 0) return 0;
            int ans1 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (CountSum(num - arr[i], arr) == 1)
                { ans1++; }

            }
            return ans1;
        }
        public static bool CanSumT(int num, int[] arr)
        {
            if (num == 0) return true;
            if (num < 0) return false;

            bool[] dp = new bool[num + 1];
            dp[0] = true;
            for (int i = 0; i < num; i++)
            {
                if (dp[i] == true)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (i + arr[j] < num)
                        {
                            dp[i + arr[i]] = true;
                        }
                    }
                }
            }
            return dp[num];
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
            int[,] dp = new int[m + 1, n + 1];
            dp[1, 1] = 1;
            for (int row = 0; row <= m; row++)
            {
                for (int column = 0; column <= n; column++)
                {
                    if (row < m)
                    {
                        dp[row + 1, column] += dp[row, column];
                    }
                    if (column < n)
                    {
                        dp[row, column + 1] += dp[row, column];
                    }
                }
            }
            return dp[m, n];
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
            int[] arr = new int[num + 2];
            Array.Fill(arr, 0);
            arr[1] = 1;
            for (int i = 0; i < num; i++)
            {
                if (arr[i] >= 1)
                {
                    arr[i + 1] += arr[i];
                    arr[i + 2] += arr[i];
                }
            }
            return arr[num];
        }
        public static int FabNum(int num)
        {
            if (num <= 2) return 1;
            return FabNum(num - 1) + FabNum(num - 2);
        }
        public static int sumNumT(int num)
        {
            if (num <= 1) return 1;
            int[] arr = new int[num + 1];
            Array.Fill(arr, 1);
            for (int i = 0; i < num; i++)
            {
                arr[i + 1] += arr[i];
            }
            arr[num] = 0;
            for (int i = 0; i < num; i++)
            {
                arr[num] += arr[1];
            }
            return arr[num];
        }
        public static int sumNum(int num)
        {
            if (num <= 1) return 1;
            return num + sumNum(num - 1);
        }
    }

}
