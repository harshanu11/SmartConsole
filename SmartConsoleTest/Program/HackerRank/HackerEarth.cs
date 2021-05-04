using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Program
{
    public class HackerEarth
    {
        //https://www.hackerearth.com/practice/codemonk/
        [Fact]
        public static void MainTest()
        {

            int T = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                RotateArray();
            }
        }
        public static void RotateArray()
        {
            string[] lenAndShift = Console.ReadLine().Split(' ');
            double len = Convert.ToDouble(lenAndShift[0]);
            double shift = Convert.ToDouble(lenAndShift[1]);
            //Console.WriteLine(len);
            //Console.WriteLine(shift);

            int shiftVal = 0;
            if (len < shift)
            {
                shift = (int)(shift % len);
            }
            shiftVal = Convert.ToInt32(len - shift);
            if (shiftVal < 0)
            {
                shiftVal = Convert.ToInt32(len) + shiftVal;
            }

            string[] a = Console.ReadLine().Split(' ');
            string[] aNewStart = a.Skip(shiftVal).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] aNewEnd = a.Take(shiftVal).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            //Array.Copy(a, 0, aNew, 0, 3);
            if (aNewStart.Length > 0)
                Console.Write(String.Join(" ", aNewStart) + " ");
            if (aNewEnd.Length > 0)
                Console.Write(String.Join(" ", aNewEnd));
            Console.WriteLine("");
        }
        //https://www.hackerearth.com/practice/codemonk/
        public static int CalculateInversion()
        {
            int count = 0;
            int Length = Convert.ToInt16(Console.ReadLine());
            //Console.WriteLine(Length);
            string[][] jaggedArr = new string[Length][];
            List<string[]> arr = new List<string[]>();
            for (int i = 0; i < Length; i++)
            {
                jaggedArr[i] = Console.ReadLine().Split(' ');
            }

            for (int i = 0; i < Length; i++)
            {
                for (int l = 0; l < Length; l++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        for (int k = 0; k <= l; k++)
                        {

                            if (Convert.ToInt16(jaggedArr[i][l]) < Convert.ToInt16(jaggedArr[j][k]))
                            {
                                count++;

                            }
                        }
                    }
                }
            }
            Console.WriteLine("");
            return count;
        }

        public static BigInteger CalculateBinaryRotation()
        {
            try
            {
                BigInteger response = 0;
                var input1 = Console.ReadLine().Split(' ');
                BigInteger N = Convert.ToInt64(input1[0]);
                BigInteger K = Convert.ToInt64(input1[1]);
                string strBin = Console.ReadLine();

                return BinToIntMax(strBin, K);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at CalculateBinaryRotation " + ex.Message);
                throw ex;
            }
        }
        public static BigInteger NextMax(string tempStr)
        {
            try
            {

                string bin = new String(tempStr);
                BigInteger max = 0;
                BigInteger k = 0;
                string temp = "";
                for (BigInteger i = 0; i < bin.Length; i++)
                {
                    char[] end = bin.Take(1).ToArray();
                    char[] start = bin.Skip(1).ToArray();
                    char[] concat = start.Concat(end).ToArray();
                    bin = new string(concat);
                    if (bin == tempStr)
                    {
                        k = i + 1;
                        //Console.WriteLine(tempStr);
                        break;
                    }
                }
                //Console.WriteLine(k+" "+bin );
                return k;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at NextMax " + ex.Message);
                throw ex;
            }

        }
        public static BigInteger BinToIntMax(string bin, BigInteger K)
        {
            BigInteger max = 0;
            BigInteger k = 0;
            string temp = "";
            for (BigInteger i = 0; i < bin.Length; i++)
            {
                char[] end = bin.Take(1).ToArray();
                char[] start = bin.Skip(1).ToArray();
                char[] concat = start.Concat(end).ToArray();
                bin = new string(concat);
                BigInteger _max = BinToDec(bin);
                if (_max > max)
                {
                    max = _max;
                    k = i + 1;
                    temp = bin;
                }
            }
            BigInteger nextRound = 0;
            nextRound = (K - 1) * NextMax(temp);
            return k + nextRound;
        }
        public static BigInteger BinToDec(string value)
        {
            // BigInteger can be found in the System.Numerics dll
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in value)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }

            return res;
        }

    }
}
