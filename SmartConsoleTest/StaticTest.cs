using Xunit;

namespace StaticConsoleTest
{
    public class StaticTest
    {
        [Fact]
        public void CommonStaticReadyToUseTest()
        {
            Assert.Equal(2, System.Math.Sqrt(4));
            System.Console.WriteLine("This is onother ready to use static method");
        }
    }
}