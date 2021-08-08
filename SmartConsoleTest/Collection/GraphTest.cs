
// C# program to check if there is
// exist a path between two vertices
// of a graph.
using System;
using Xunit;

namespace CollectionTest
{
    public class GraphTest
    {
        /// <summary>
        /// Find if there is a path between two vertices in a directed graph
        /// </summary>
        [Fact]
        public void FindPathBwnTwoNodeGraphTest()
        {
            GraphOps g = new GraphOps(4);
            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 3);
            int u = 1;
            int v = 3;
            if (g.isReachable(u, v))
                Console.WriteLine("There is a path from " + u + " to " + v);
            else
                Console.WriteLine("There is no path from " + u + " to " + v);
            u = 3;
            v = 1;
            if (g.isReachable(u, v))
                Console.WriteLine("There is a path from " + u + " to " + v);
            else
                Console.WriteLine("There is no path from " + u + " to " + v);
        }
    }
}
