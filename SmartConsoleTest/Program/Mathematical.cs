using System;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class Mathematical
    {
        [Fact]
        public void PrintPattern()
        {

            int N = 3;
            string str = "";
            for (int i = N; i > 0; i--)
            {
                for (int j = N; j > 0; j--)
                {
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(j + " ");
                        str = str + j + " ";
                    }
                }

                Console.Write("$");
                str = str + "$";
            }
            Assert.Equal("3 3 3 2 2 2 1 1 1 $3 3 2 2 1 1 $3 2 1 $", str);
        }
    }
}
