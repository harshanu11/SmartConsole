using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class SearchingTest
    {
        [Fact]
        public void StackProblem()
        {
            Stack<string> bracketStack = new Stack<string>();
            if (bracketStack.Count == 0)
            {

            }
            bracketStack.Push("{");
            string pop = bracketStack.Pop();
        }
    }

}
