using System;
using System.Globalization;
using Xunit;

namespace Etc
{
    public class DefinitionTest 
    {
        [Fact]
        public void Date()
        {
            const string Algorithm = "Algorithm set of instruction to solve a problem";
            const string Program = "Program is set of instruction for computer execution";
        }
    }
    public class DateTest
    {
        [Fact]
        public void Date()
        {

            string st = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            DateTime dd = DateTime.Now;
        }
        [Fact]
        public void AddDate()
        {

            string st = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            DateTime dd = DateTime.Now;
        }
        [Fact]
        public void DateToUtcToLocal()
        {

            string st = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            DateTime dd = DateTime.Now;
        }
    }
}
