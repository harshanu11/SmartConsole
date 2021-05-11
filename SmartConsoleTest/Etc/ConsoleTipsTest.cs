using System;
using Xunit;

namespace ConsoleTips
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

        }
    }
}
