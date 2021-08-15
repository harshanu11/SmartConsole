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
        public static List<int> HowSumt(int n, int[] arr)
        {
            if (n < 0) return null;
            if (n == 0) return new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int rem = n - arr[i];
                var res = HowSumt(rem, arr);
                if (res != null)
                {
                    res.Add(arr[i]);
                    return res;
                }
            }
            return null;
        }
        public static string[] HowSumT(int sum, int[] numbers)
        {
            if (sum < 0) return null;
            if (sum == 0) return new string[0];


            string[] table = new string[sum + 1];
            // seed
            table[0] = "";

            for (int sm = 0; sm < sum; sm++)
            {
                if (table[sm] != null)
                {
                    for (int num = 0; num < numbers.Length; num++)
                    {
                        if (sm + numbers[num] <= sum)
                        {
                            table[sm + numbers[num]] += table[sm] + " " + numbers[num];
                            if (sm + numbers[num] == 7)
                            {
                                return table;
                            }
                            //table[sm + numbers[num]] += numbers[num] + " ";
                        }
                    }
                }
            }
            return table;
        }
        public static List<int> BestSumSumt(int n, int[] number)
        {
            if (n < 0) return null;
            if (n == 0) return new List<int>();
            List<int> shortest = new List<int>();

            for (int num = 0; num < number.Length; num++)
            {

            }
            return shortest;
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
