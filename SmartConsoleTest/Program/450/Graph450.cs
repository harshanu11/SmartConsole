using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using CollectionTest;

namespace DSA450
{
    public class Graph450
    {
        #region Create a Graph, print it
        //via matrix
        // via ll
        void CreateGraphMatrix()
        {
            int ver = 6, e = 5;
            int[][] graph = new int[ver + 1][];
            for (int v = 0; v <= ver; v++)
            {
                var arr = new int[ver + 1];
                Array.Fill(arr, 0);
                graph[v] = arr;
            }
            graph[6][5] = 1;
            graph[1][2] = 1;
            graph[1][5] = 1;
            graph[2][3] = 1;
            graph[3][4] = 1;
            graph[3][6] = 1;

            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Debug.Write(graph[row][col]);
                }
                Debug.WriteLine("");
            }
        }
        [Fact]
        public void GraphInsertTest() 
        {
            CreateGraphMatrix();
        }
        #endregion
        #region Implement BFS algorithm 
        
        [Fact]
        public void BfsGraphTest()
        {
            GraphNode g = new GraphNode(4);

            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 3);

            Debug.Write("Following is Breadth First " +
                        "Traversal(starting from " +
                        "vertex 2)\n");
            g.bfs(0,3);
        }
        #endregion
        #region Implement DFS Algo 
        [Fact]
        public static void DfsGraphTest()
        {
            GraphNode g = new GraphNode(4);

            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 3);

            Debug.WriteLine(
                "Following is Depth First Traversal "
                + "(starting from vertex 2)");

            g.dfsR(0,3);
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
            GraphNode graph = new GraphNode(4);
            graph.addEdge(0, 1);
            graph.addEdge(0, 2);
            graph.addEdge(1, 2);
            graph.addEdge(2, 0);
            graph.addEdge(2, 3);
            graph.addEdge(3, 3);

            //if (graph.isCyclic())
            //    Debug.WriteLine("Graph contains cycle");
            //else
            //    Debug.WriteLine("Graph doesn't "
            //                            + "contain cycle");
        }
        #endregion
        #region Detect Cycle in UnDirected Graph using BFS/DFS Algo      

        // Driver Code
        public static void UnDirectedCyclicTeat(String[] args)
        {
            // Create a graph given in the above diagram
            GraphNode g1 = new GraphNode(5);
            g1.addEdge(1, 0);
            g1.addEdge(0, 2);
            g1.addEdge(2, 1);
            g1.addEdge(0, 3);
            g1.addEdge(3, 4);
            //if (g1.isCyclic())
            //    Debug.WriteLine("Graph contains cycle");
            //else
            //    Debug.WriteLine("Graph doesn't contains cycle");

                //GraphNode1 g = new GraphNode1(3);
                //g2.addEdge(0, 1);
                //g2.addEdge(1, 2);
                //if (g2.isCyclic())
                //Debug.WriteLine("Graph contains cycle");
                //else
                //    Debug.WriteLine("Graph doesn't contains cycle");
        }
        #endregion
    }
}
