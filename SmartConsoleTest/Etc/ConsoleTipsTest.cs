using System.Diagnostics;
using System;
using Xunit;

namespace Etc
{
    public class ConsoleTipsTest
    {
        [Fact]
        public void CommonStaticReadyToUseTest()
        {
            Debug.WriteLine("This is onother ready to use static method");
            // for next line 
            Debug.WriteLine("\n");
            Debug.WriteLine("");
            //Console.ReadLine().Split(' ');

            Console.Write("Decimal".PadRight(10));//Padding
            int p1 = 0;
            Debug.WriteLine(nameof(p1));
            Debug.WriteLine("my answer".PadRight(10) + "data");
            Debug.WriteLine(Convert.ToString(2, 2));


        }
    }
}
