
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
        [Fact]
        public void GraphCRUDTest()
        {
            GraphNode graph = new GraphNode(6);
            for (int i = 0; i < 6; i++)
            {
                graph.adjecent[i].AddLast(i);
                if (i > 0)
                {
                    graph.adjecent[i - 1].AddLast(i);
                }

            }
        }
        [Fact]
        public void BFSTest()
        {

            Console.WriteLine("Enter number of vertices and edges");

            int v = 5;
            int e = 6;

            GraphNode graph = new GraphNode(v);
            Console.WriteLine("Enter " + e + " edges");
            int source = 0;
            int destination = 0;
            graph.addEdge(0, 1);
            graph.addEdge(1, 2);
            graph.addEdge(2, 3);
            graph.addEdge(3, 4);
            graph.addEdge(0, 4);
            graph.addEdge(2, 4);

            Console.WriteLine("Enter source and destination");

            source = 0;
            destination = 3;
            var ans = graph.bfs(source, destination);
            Console.WriteLine("possible " + graph.bfs(source, destination));
        }
        [Fact]
        public void DFSTest()
        {
            int v = 5;
            int e = 6;

            GraphNode graph = new GraphNode(v);
            Console.WriteLine("Enter " + e + " edges");
            int source = 0;
            int destination = 0;
            graph.addEdge(0, 1);
            graph.addEdge(1, 2);
            graph.addEdge(2, 3);
            graph.addEdge(3, 4);
            graph.addEdge(0, 4);
            graph.addEdge(2, 4);

            Console.WriteLine("Enter source and destination");
            source = 0;
            destination = 3;
            GraphNodeList gl = new GraphNodeList(5);
            gl.AddEdge(0, 1);
            gl.AddEdge(1, 2);
            gl.AddEdge(2, 3);
            gl.AddEdge(3, 4);
            gl.AddEdge(0, 4);
            gl.AddEdge(2, 4);
        }
        [Fact]
        public void MotherVertixTest()
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
            GraphNodeList gl = new GraphNodeList(5);
            gl.AddEdge(0, 3);
        }
    }

}
