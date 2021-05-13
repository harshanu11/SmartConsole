using Xunit;

namespace ValueTypeTest
{

    public class Bool
    {
        [Fact]
        public void CheckDefaltValue()
        {
            bool MyFirstBooleanFlag = new bool();
            Assert.False(MyFirstBooleanFlag);

            // 2^1
            MyFirstBooleanFlag = true;
            Assert.True(MyFirstBooleanFlag);

            bool? MyFirstBooleanFlagNullable = null;
            Assert.Null(MyFirstBooleanFlagNullable);
        }
    }
}
