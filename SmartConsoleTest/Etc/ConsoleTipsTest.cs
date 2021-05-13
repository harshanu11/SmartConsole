using System;
using Xunit;

namespace Etc
{
    public class ConsoleTipsTest
    {
        [Fact]
        public void CommonStaticReadyToUseTest()
        {
            Console.WriteLine("This is onother ready to use static method");
            // for next line 
            Console.WriteLine("\n");
            Console.WriteLine("");
            //Console.ReadLine().Split(' ');

            Console.Write("Decimal".PadRight(10));//Padding
            int p1 = 0;
            Console.WriteLine(nameof(p1));
            Console.WriteLine("my answer".PadRight(10) + "data");
            Console.WriteLine(Convert.ToString(2, 2));


        }
    }
}
