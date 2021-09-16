
// C# program to check if there is
// exist a path between two vertices
// of a graph.
using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionTest
{
    public class GraphOps
    {
        private int V;
        private LinkedList<int>[] adj;
        public GraphOps(int v)
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

        void dfs(int u, ref List<List<int>> adj, ref List<bool> vis)
        {
            //marking current vertex as visited.
            vis[u] = true;

            //iterating over the adjacent vertices.
            foreach (var v in adj[u])
            {
                //if any vertex is not visited, we call dfs function recursively.
                if (!vis[v])
                    dfs(v, ref adj, ref vis);
            }
        }

        //Function to find a Mother Vertex in the Graph.
        public int findMotherVertex(int V, ref List<List<int>> adj)
        {
            //boolean list to mark the visited nodes and initially all are
            //initialized as not visited.
            List<bool> vis = new List<bool>();
            for (int i = 0; i < V; i++) vis.Add(false);

            //variable to store last finished vertex (or mother vertex).
            int v = -1;

            //iterating over all the vertices
            for (int i = 0; i < V; i++)
            {
                //if current vertex is not visited, we call the dfs 
                //function and then update the variable v.
                if (!vis[i])
                {
                    dfs(i, ref adj, ref vis);
                    v = i;
                }
            }

            //we reset all the vertices as not visited.

            for (int i = 0; i < V; i++) vis[i] = false;

            //calling the dfs function to do DFS beginning from v to check
            //if all vertices are reachable from it or not.
            dfs(v, ref adj, ref vis);

            //iterating on boolean list and returning -1 if
            //any vertex is not visited.
            foreach (var i in vis)
                if (!i)
                    return -1;

            //returning mother vertex.
            return v;
        }
    }
}
