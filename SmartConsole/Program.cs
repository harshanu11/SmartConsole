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
            //decodeString(3, "mnes__ya_____mi");
            //solution(3, "mnes__ya_____mi");
            //var ans = isminimumNumberOfCoins(new int[] { 2, 5, 3, 6 },4, 1);
            var ans = MinNumberOfCoinst(new int[] { 3, 3, 6 }, 3, 6);
        }


        static List<string> MinNumberOfCoinst(int[] coins, int numberOfCoins, int value) 
        {
            if (value == 0) return new List<string>();
            if (value < 0) return null;

            List<string> table = new List<string>();
            // fill the table 
            for (int t = 0; t < value+1; t++)
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
                        if (coins[c] + t  < table.Count)
                        {
                            table[t + coins[c]] += "[" + table[t] + coins[c] + "]";
                        }
                    }
                }
            }
            return table;
        }

        static List<int> MinNumberOfCoins(int[] coins, int numberOfCoins, int value)
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

        //static long CountminimumNumberOfCoins(int[] coins, int numberOfCoins, int value)
        //{

        //}
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
