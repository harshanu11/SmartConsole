using Xunit;

namespace BooleanTest
{

    public class Bool
    {
        [Fact]
        public void CheckDefaltValue()
        {
            bool MyFirstBooleanFlag = new bool();

            Assert.False(MyFirstBooleanFlag);
        }
        [Fact]
        public void BitValue()
        {

            // 2^1
            bool MyFirstBooleanFlag = new bool();

            Assert.False(MyFirstBooleanFlag);
            MyFirstBooleanFlag = true;
            Assert.True(MyFirstBooleanFlag);
        }
        [Fact]
        public void CheckNullableValue()
        {
            bool? MyFirstBooleanFlag = null;
            Assert.Null(MyFirstBooleanFlag);
        }
        [Fact]
        public void TwoBitInformation()
        {
            bool MyFirstBooleanFlag = new bool();

            Assert.False(MyFirstBooleanFlag);
            MyFirstBooleanFlag = true;
            Assert.True(MyFirstBooleanFlag);
        }
    }
}
