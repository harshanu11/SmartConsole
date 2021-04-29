using System;
using Xunit;

namespace ValueTypeTest
{
    public class CharTest
    {
        [Fact]
        public void charIsLetterTest()
        {
            if (char.IsLetter('c') && char.IsWhiteSpace('s') && char.IsLetterOrDigit('h'))
            {

            }
            if (char.IsNumber('5') &&  char.IsDigit("5.6d", 0) && char.IsSymbol('@'))
            {

            }
            char.ToUpper('d');

            int a = Convert.ToInt16(Convert.ToString('2'));//2
            a = (char)'2';//50
            a = (int)'2';//50
        }
    }
}
