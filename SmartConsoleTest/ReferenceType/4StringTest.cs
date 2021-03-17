using Xunit;

namespace ReferenceTypeTest
{
    public class StringTest
    {
        [Fact]
        public void StringAlwaysCompareContentOfString()
        {
                string MyFirstString = "str";
                string MySecondString = new string("str".ToCharArray());// new char[] { 's','t','r'};

            object MyFirstStringObj = "str";// 
            object MySecondStringObj = "str";
            object MyThirdStringObj = new string("str".ToCharArray()); 

            // here .equals or == both check content inside srting 
            Assert.True(MyFirstString.Equals(MySecondString));
            Assert.True(MyFirstString == MySecondString);// though it is == but comparing value inside srtring
            // but reference is not a same so returning false only 
            Assert.False(ReferenceEquals(MyFirstString, MySecondString));



            Assert.True(ReferenceEquals(MyFirstStringObj, MySecondStringObj));
            Assert.False(ReferenceEquals(MyFirstStringObj, MyThirdStringObj));// not smae reference bcz used new
            Assert.True(MyFirstStringObj.Equals(MySecondStringObj));
            Assert.True(MyFirstStringObj.Equals(MyThirdStringObj));
            Assert.True(MyFirstStringObj == MySecondStringObj);
            Assert.False(MyFirstStringObj == MyThirdStringObj);

        }

    }

}
