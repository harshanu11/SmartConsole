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


        }
    }
}
