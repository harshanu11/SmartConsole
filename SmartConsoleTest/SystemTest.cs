using System;
using System.Globalization;
using Xunit;

namespace SmartConsoleTest
{
    public class SystemTest
    {
        [Fact]
        public void Date()
        {

            string st = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            DateTime dd = DateTime.Now;
        }
        [Fact]
        public void RefTest() { }
        [Fact]
        public void OutTest() { }
        [Fact]
        public void InTest() { }
    }
}
