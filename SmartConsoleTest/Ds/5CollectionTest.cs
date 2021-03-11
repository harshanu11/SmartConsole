using System;
using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class CollectionTest
    {
        [Fact]
        public void StackProblem()
        {
            Stack<string> bracketStack = new Stack<string>();

            bracketStack.Push("{");
            string pop = bracketStack.Pop();
        }
        [Fact]
        public void HashSet()
        {
            HashSet<int> my_first_hashSet = new HashSet<int>();

            if (my_first_hashSet.Contains(9))
            {
                my_first_hashSet.Remove(9);
            }
            else
            {
                my_first_hashSet.Add(9);
            }

        }

    }

}
