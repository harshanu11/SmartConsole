using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
