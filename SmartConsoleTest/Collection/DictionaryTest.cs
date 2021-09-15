using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class DictionaryTest
    {
        [Fact]
        public void BasicDictionaryTest()
        {
            Dictionary<char, int> dc = new Dictionary<char, int>() { { 'x', 5 } };
            Dictionary<int, int> d = new Dictionary<int, int>() ;
            d.Add(4, 3);
            d.TryAdd(4, 3);
            d.ContainsValue(5);
            d.ContainsKey(4);
            var data =d.Keys;
            foreach (KeyValuePair<int,int> item in d)
            {

            }
        }
    }
}
