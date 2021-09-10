using System.Diagnostics;
using System;
using Xunit;

namespace Program
{
    public class Mathematical
    {
        [Fact]
        public void MathFunctionTest()
        {
            double d = Math.Abs(-9.56);//9.56
            d = Math.Round(-9.65);//-10
            d = Math.Floor(-9.65);//-10
            d = Math.Ceiling(-9.65);//-9
            d = Math.Truncate(-9.65);//chop off all floating value
            d = Math.Min(9, 6);//6
            d = Math.Max(9, 6);//9
            d = Math.Sign(-9.65);//-1,0,1
            d = Math.Pow(2, 3);//8
            d = Math.Sqrt(4);//2


        }
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
                        Debug.Write(j + " ");
                        str = str + j + " ";
                    }
                }

                Debug.Write("$");
                str = str + "$";
            }
            Assert.Equal("3 3 3 2 2 2 1 1 1 $3 3 2 2 1 1 $3 2 1 $", str);
        }
    }
}
