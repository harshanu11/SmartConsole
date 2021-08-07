using System;
using System.Text.RegularExpressions;
using Xunit;

namespace ReferenceTypeTest
{
    public class StringRegexTest
    {
        [Fact]
        public void StringAlwaysCompareContentOfString()
        {
            #region Create
            string MyFirstString = "str";
            string MySecondString = new string(new char[] { 's', 't', 'r' });// new char[] { 's','t','r'};

            object MyFirstStringObj = "str";// 
            object MySecondStringObj = "str";
            object MyThirdStringObj = new string("str".ToCharArray());
            string[] test = new string[2];
            test[0] = "Hello ";
            test[1] = "World!";
            string result = string.Concat(test);
            #endregion

            #region Compare
            if ("hello".Contains("H"))
            {

            }
            Assert.Equal("456", "456");
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
            string strUpp = "Hi this is upper case.test,".ToUpper();
            #endregion

            #region sortReverese
            string str = "fsfsfsfsfs";
            #endregion

            #region Find

            #endregion

            #region Copy

            #endregion

            #region ConvertReesize
            string convertToStr = string.Join(",", new int[] { 1, 2 });
            Convert.ToInt32("1001101", 2).ToString();
            "".ToCharArray();
            String ans = str.Substring(4, str.Length - 4) + str.Substring(0, 4);


            #endregion

        }
        [Fact]
        public void RegexTest() 
        {
            string myStr = "a";
            Regex reg = new Regex("[a-z]");
            Assert.True(reg.IsMatch(myStr));
            myStr = "A";
            Assert.False(reg.IsMatch(myStr));

            // number check
            myStr = "1";
            reg = new Regex("[0-9]");
            Assert.True(reg.IsMatch(myStr));
            myStr = "A";
            Assert.False(reg.IsMatch(myStr));

            // make sure single char
            reg = new Regex("^[a-z]$");
            myStr = "aa";
            Assert.False(reg.IsMatch(myStr));

            // make sure five char
            reg = new Regex("^[a-z]{5}$");
            myStr = "aa";
            Assert.False(reg.IsMatch(myStr));
            myStr = "aaddg";
            Assert.True(reg.IsMatch(myStr));

            // make sure upper case as well 
            reg = new Regex("^[a-zA-Z]{5}$");
            myStr = "aaA";
            Assert.False(reg.IsMatch(myStr));
            myStr = "aaddD";
            Assert.True(reg.IsMatch(myStr));

            // make sure one to five range char
            reg = new Regex("^[a-z]{1,5}$");
            myStr = "aa";
            Assert.True(reg.IsMatch(myStr));
            myStr = "aaddg";
            Assert.True(reg.IsMatch(myStr));

            // email [a-zA-Z0-9]{1,5}@[a-zA-Z]{.com|.co|.in}
            reg = new Regex("^[a-zA-Z0-9]{1,5}@[a-zA-Z]{.com|.co|.in}$");
            myStr = "harsh.singh@abbc.com";
            Assert.True(reg.IsMatch(myStr));


            ///////////////////////////////// replace unused thing ////
            string str = "hi,I @ am Harsh-";
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            str = rgx.Replace(str, "");
            Assert.Equal("hiIamHarsh", str); 

            str = "hi,I @ am Harsh-";
            rgx = new Regex("[^a-zA-Z0-9 -]");
            str = rgx.Replace(str, "");
            Assert.Equal("hiI  am Harsh-", str);

            // split by regex
            string pattern = "[a-z]+";
            string input = "Abc1234Def5678Ghi9012Jklm";
            string[] result = Regex.Split(input, pattern,
                                          RegexOptions.IgnoreCase,
                                          TimeSpan.FromMilliseconds(500));

        }
    }

}
