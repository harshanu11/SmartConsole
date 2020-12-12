using Xunit;

namespace SmartConsoleTest
{
    public class RefOutInKeywordTest
    {
        [Fact]
        public void InRefOutTest()
        {

            //The in ref out keyword causes arguments to be passed by reference. 
            int readonlyArgument = 44;
            RefOutInKeyword.InArgExample(readonlyArgument);
            Assert.Equal(44,readonlyArgument);     // value is still 44

            int number = 1;
            // ref to pass reference of value type
            RefOutInKeyword.Method(ref number);
            Assert.Equal(45, number);     // Output: 45


            int initializeInMethod;
            RefOutInKeyword.OutArgExample(out initializeInMethod);
            Assert.Equal(44, readonlyArgument);     // value is set to  44
        }
    }

    public class RefOutInKeyword
    {
        public static void Method(ref int refArgument)
        {
            refArgument = refArgument + 44;
        }

        public static void OutArgExample(out int number)
        {
            number = 44;
        }

        public static void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            // number = 19;
        }
    }
}
