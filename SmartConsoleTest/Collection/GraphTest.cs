
// C# program to check if there is
// exist a path between two vertices
// of a graph.
using System;
using System.Collections;
using System.Collections.Generic;
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
            MyGraph g = new MyGraph(4);
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
    public class MyGraph
    {
        private int V; 
        private LinkedList<int>[] adj; 
        public MyGraph(int v)
        {
            V = v;
            adj = new LinkedList<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new LinkedList<int>();
        }
        public void addEdge(int v, int w)
        {
            adj[v].AddLast(w);
        }

        // prints BFS traversal from a given source s
        public bool isReachable(int s, int d)
        {
            bool[] visited = new bool[V];

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            visited[s] = true;
            queue.AddLast(s);

            IEnumerator i;
            while (queue.Count != 0)
            {

                s = queue.First.Value;
                queue.RemoveFirst();
                int n;
                i = adj[s].GetEnumerator();

                while (i.MoveNext())
                {
                    n = (int)i.Current;

                    if (n == d)
                        return true;

                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.AddLast(n);
                    }
                }
            }

            // If BFS is complete without visited d
            return false;
        }

    }
}
