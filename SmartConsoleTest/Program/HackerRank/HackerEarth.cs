using System;
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
                shiftVal = (int)(shift % len);
            }
            shiftVal = Convert.ToInt32(len - shiftVal);
            if (shiftVal < 0)
            {
                shiftVal = Convert.ToInt32(len) + shiftVal;
            }

            string[] a = Console.ReadLine().Split(' ');
            string[] aNewStart = a.Skip(shiftVal).ToArray();
            string[] aNewEnd = a.Take(shiftVal).ToArray();
            foreach (var item in aNewStart)
            {
                Console.Write(item + " ");
            }
            for (int i = 0; i < aNewEnd.Length; i++)
            {
                if (aNewEnd.Length - 1 == i)
                {
                    Console.Write(aNewEnd[i]);
                }
                else
                    Console.Write(aNewEnd[i] + " ");
            }
            //Array.Copy(a, 0, aNew, 0, 3);
            Console.WriteLine("");
        }
    }
}
