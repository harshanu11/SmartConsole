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
            var ans = subsequenceCount("banana", new string[] { "b", "ba", "a","an","ban","ana" });
        }

        public static bool subsequenceCount(string str, string[] subStr)
        {
            if (str == "") return true;
            //if (str.Length < subStr.Length) return false;
            for (int c = 0; c < subStr.Length; c++)
            {
                if (str.IndexOf(subStr[c]) == 0 )
                {
                    var remender = str.Substring(subStr[c].Length);
                    var remenderCombination = subsequenceCount(remender, subStr);
                    if (remenderCombination)
                    {
                        return true;
                    }
                }
            }

            return false;
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
