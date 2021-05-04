using System;
using Xunit;

namespace ReferenceTypeTest
{
    public class StringTest
    {
        [Fact]
        public void StringAlwaysCompareContentOfString()
        {
            #region Create
            string MyFirstString = "str";
            string MySecondString = new string("str".ToCharArray());// new char[] { 's','t','r'};

            object MyFirstStringObj = "str";// 
            object MySecondStringObj = "str";
            object MyThirdStringObj = new string("str".ToCharArray());
            string[] test = new string[2];
            test[0] = "Hello ";
            test[1] = "World!";

            string result = string.Concat(test);
            #endregion

            #region Compare
            Assert.True(MyFirstString.Equals(MySecondString));
            Assert.True(MyFirstString == MySecondString);// though it is == but comparing value inside srtring
            // but reference is not a same so returning false only 
            Assert.False(ReferenceEquals(MyFirstString, MySecondString));
            // here .equals or == both check content inside srting 

            System.Console.WriteLine(string.IsNullOrEmpty("dgdgf"));
            Assert.True(ReferenceEquals(MyFirstStringObj, MySecondStringObj));
            Assert.False(ReferenceEquals(MyFirstStringObj, MyThirdStringObj));// not smae reference bcz used new
            Assert.True(MyFirstStringObj.Equals(MySecondStringObj));
            Assert.True(MyFirstStringObj.Equals(MyThirdStringObj));
            Assert.True(MyFirstStringObj == MySecondStringObj);
            Assert.False(MyFirstStringObj == MyThirdStringObj);
            #endregion

            #region Set

            #endregion

            #region sortReverese

            #endregion

            #region Find

            #endregion

            #region Copy

            #endregion

            #region ConvertReesize
            Convert.ToInt32("1001101", 2).ToString();
            "".ToCharArray();
            #endregion

        }

    }

}
