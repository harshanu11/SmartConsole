using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class DictionaryTest
    {
        [Fact]
        public void BasicDictionaryTest()
        {
            Dictionary<int, int> d = new Dictionary<int, int>() ;
            d.Add(4, 3);
            d.TryAdd(4, 3);
            d.ContainsValue(5);
            d.ContainsKey(4);
            var data =d.Keys;
        }
    }
}
