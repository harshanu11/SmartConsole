using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DSA450
{
    public class Graph450 {
        #region Create a Graph, print it

        #endregion
        #region Implement BFS algorithm 
        public class GraphNode1
        {
            // No. of vertices	
            private int _V;

            //Adjacency Lists
            LinkedList<int>[] _adj;

            public GraphNode1(int V)
            {
                _adj = new LinkedList<int>[V];
                for (int i = 0; i < _adj.Length; i++)
                {
                    _adj[i] = new LinkedList<int>();
                }
                _V = V;
            }
            public void AddEdge(int v, int w)
            {
                _adj[v].AddLast(w);

            }
            public void BFS(int s)
            {

                // Mark all the vertices as not
                // visited(By default set as false)
                bool[] visited = new bool[_V];
                for (int i = 0; i < _V; i++)
                    visited[i] = false;

                // Create a queue for BFS
                LinkedList<int> queue = new LinkedList<int>();

                // Mark the current node as
                // visited and enqueue it
                visited[s] = true;
                queue.AddLast(s);

                while (queue.Any())
                {

                    // Dequeue a vertex from queue
                    // and print it
                    s = queue.First();
                    Console.Write(s + " ");
                    queue.RemoveFirst();

                    // Get all adjacent vertices of the
                    // dequeued vertex s. If a adjacent
                    // has not been visited, then mark it
                    // visited and enqueue it
                    LinkedList<int> list = _adj[s];

                    foreach (var val in list)
                    {
                        if (!visited[val])
                        {
                            visited[val] = true;
                            queue.AddLast(val);
                        }
                    }
                }
            }
            void DFSUtil(int v, bool[] visited)
            {
                // Mark the current node as visited
                // and print it
                visited[v] = true;
                Console.Write(v + " ");

                // Recur for all the vertices
                // adjacent to this vertex
                //List<int> vList = adj[v];
                //foreach (var n in vList)
                //{
                //    if (!visited[n])
                //        DFSUtil(n, visited);
                //}
            }
            public void DFS(int v)
            {
                // Mark all the vertices as not visited
                //// (set as false by default in c#)
                //bool[] visited = new bool[V];

                //// Call the recursive helper function
                //// to print DFS traversal
                //DFSUtil(v, visited);
            }

        }
        [Fact]
        public void BfsGraphTest()
        {
            GraphNode1 g = new GraphNode1(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.Write("Following is Breadth First " +
                        "Traversal(starting from " +
                        "vertex 2)\n");
            g.BFS(2);
        }
        #endregion
        #region Implement DFS Algo 
        [Fact]
        public static void DfsGraphTest()
        {
            GraphNode1 g = new GraphNode1(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine(
                "Following is Depth First Traversal "
                + "(starting from vertex 2)");

            g.DFS(2);
            Console.ReadKey();
        }
        #endregion
        #region Detect Cycle in Directed Graph using BFS/DFS Algo 
        private readonly int V;
        private readonly List<List<int>> adj;

        private bool isCyclicUtil(int i, bool[] visited,
                                        bool[] recStack)
        {

            // Mark the current node as visited and
            // part of recursion stack
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (isCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

        public void addEdge(int sou, int dest)
        {
            adj[sou].Add(dest);
        }

        private bool isCyclic()
        {

            // Mark all the vertices as not visited and
            // not part of recursion stack
            bool[] visited = new bool[V];
            bool[] recStack = new bool[V];


            // Call the recursive helper function to
            // detect cycle in different DFS trees
            for (int i = 0; i < V; i++)
                if (isCyclicUtil(i, visited, recStack))
                    return true;

            return false;
        }

        [Fact]
        public void isCyclicTest()
        {
            GraphNode1 g = new GraphNode1(4);
            //graph.addEdge(0, 1);
            //graph.addEdge(0, 2);
            //graph.addEdge(1, 2);
            //graph.addEdge(2, 0);
            //graph.addEdge(2, 3);
            //graph.addEdge(3, 3);

            //if (graph.isCyclic())
            //    Console.WriteLine("Graph contains cycle");
            //else
            //    Console.WriteLine("Graph doesn't "
            //                            + "contain cycle");
        }
        #endregion
        #region Detect Cycle in UnDirected Graph using BFS/DFS Algo      

        // Driver Code
        public static void UnDirectedCyclicTeat(String[] args)
        {
            // Create a graph given in the above diagram
            GraphNode1 g = new GraphNode1(5);
            //g1.addEdge(1, 0);
            //g1.addEdge(0, 2);
            //g1.addEdge(2, 1);
            //g1.addEdge(0, 3);
            //g1.addEdge(3, 4);
            //if (g1.isCyclic())
            //    Console.WriteLine("Graph contains cycle");
            //else
            //    Console.WriteLine("Graph doesn't contains cycle");

            //GraphNode1 g = new GraphNode1(3);
            //g2.addEdge(0, 1);
            //g2.addEdge(1, 2);
            //if (g2.isCyclic())
            //Console.WriteLine("Graph contains cycle");
            //else
            //    Console.WriteLine("Graph doesn't contains cycle");
        }
        #endregion
    }
}
