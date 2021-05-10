
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
        private int V; // No. of vertices
        private LinkedList<int>[] adj; //Adjacency List

        // Constructor
        public MyGraph(int v)
        {
            V = v;
            adj = new LinkedList<int>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new LinkedList<int>();
        }

        // Function to add an edge into the graph
        public void addEdge(int v, int w)
        {
            adj[v].AddLast(w);
        }

        // prints BFS traversal from a given source s
        public bool isReachable(int s, int d)
        {
            // LinkedList<int> temp = new LinkedList<int>();

            // Mark all the vertices as not visited(By default set
            // as false)
            bool[] visited = new bool[V];

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.AddLast(s);

            // 'i' will be used to get all adjacent vertices of a vertex
            IEnumerator i;
            while (queue.Count != 0)
            {

                // Dequeue a vertex from queue and print it
                s = queue.First.Value;
                queue.RemoveFirst();
                int n;
                i = adj[s].GetEnumerator();

                // Get all adjacent vertices of the dequeued vertex s
                // If a adjacent has not been visited, then mark it
                // visited and enqueue it
                while (i.MoveNext())
                {
                    n = (int)i.Current;

                    // If this adjacent node is the destination node,
                    // then return true
                    if (n == d)
                        return true;

                    // Else, continue to do BFS
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
