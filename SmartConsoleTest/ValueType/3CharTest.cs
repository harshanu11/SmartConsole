using System;
using Xunit;

namespace ValueTypeTest
{
    public class CharTest
    {
        [Fact]
        public void charIsLetterTest()
        {


            #region Create

            string s = "hello";

            foreach (var item in s)
            {
                if (item == 'h')
                {
                    //true
                }
            }


            #endregion


            #region Compare
            if (char.IsLetter('c') && char.IsWhiteSpace('s') && char.IsLetterOrDigit('h')&& char.IsUpper('A'))
            {

            }
            if (char.IsNumber('5') && char.IsDigit("5.6d", 0) && char.IsSymbol('@'))
            {

            }

            Console.WriteLine("size of {0} is {1} bytes", typeof(bool), sizeof(bool));
            Console.WriteLine("size of {0} is {1} bytes", typeof(byte), sizeof(byte));
            Console.WriteLine("size of {0} is {1} bytes", typeof(char), sizeof(char));
            Console.WriteLine("size of {0} is {1} bytes", typeof(UInt32), sizeof(UInt32));
            Console.WriteLine("size of {0} is {1} bytes", typeof(ulong), sizeof(ulong));
            Console.WriteLine("size of {0} is {1} bytes", typeof(decimal), sizeof(decimal));
            #endregion

            #region sortReverese

            #endregion

            #region Find

            #endregion

            #region Copy

            #endregion

            #region ConvertReesize
            char.ToUpper('d');
            int a = Convert.ToInt16(Convert.ToString('2'));//2
            a = (char)'2';//50
            a = (int)'2';//50
            "str".ToCharArray();
            #endregion
        }
    }
}
