using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class StackTest 
    {
        [Fact]
        public void StackProblem()
        {
            Stack<string> bracketStack = new Stack<string>();

            bracketStack.Push("{");
            string pop = bracketStack.Pop();
        }
    }

}
