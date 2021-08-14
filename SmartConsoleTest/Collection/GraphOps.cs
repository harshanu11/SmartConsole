
// C# program to check if there is
// exist a path between two vertices
// of a graph.
using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionTest
{
	public class Graph
	{

		private LinkedList<int>[] adj;

		public Graph(int v)
		{
			adj = new LinkedList<int>[v];
			for (int i = 0; i < v; i++)
			{
				adj[i] = new LinkedList<int>();
			}
		}

		public virtual void addEdge(int source, int destination)
		{
			adj[source].AddLast(destination);
			adj[destination].AddLast(source);
		}

		public virtual int bfs(int source, int destination)
		{

			bool[] vis = new bool[adj.Length];
			int[] parent = new int[adj.Length];
			Queue<int> q = new Queue<int>();

			q.Enqueue(source);
			parent[source] = -1;
			vis[source] = true;
			int cur = 0;
			while (q.Count > 0)
			{
				cur = q.Dequeue();
				if (cur == destination)
				{
					break;
				}

				foreach (int neighbor in adj[cur])
				{
					if (!vis[neighbor])
					{
						vis[neighbor] = true;
						q.Enqueue(neighbor);
						parent[neighbor] = cur;
					}
				}
			}

			cur = destination;
			int distance = 0;


			while (parent[cur] != -1)
			{
				Console.Write(cur + " -> ");
				cur = parent[cur];
				distance++;
			}

			return distance;
		}

		private bool dfsUtil(int source, int destination, bool[] vis)
		{
			if (source == destination)
			{
				return true;
			}

			foreach (int neighbor in adj[source])
			{
				if (!vis[neighbor])
				{
					vis[neighbor] = true;
					bool isConnected = dfsUtil(neighbor, destination, vis);
					if (isConnected)
					{
						return true;
					}
				}
			}

			return false;
		}

		public virtual bool dfsStack(int source, int destination)
		{
			bool[] vis = new bool[adj.Length];
			vis[source] = true;
			Stack<int> stack = new Stack<int>();

			stack.Push(source);

			while (stack.Count > 0)
			{
				int cur = stack.Pop();

				if (cur == destination)
				{
					return true;
				}

				foreach (int neighbor in adj[cur])
				{
					if (!vis[neighbor])
					{
						vis[neighbor] = true;
						stack.Push(neighbor);
					}
				}
			}

			return false;
		}

		public virtual bool dfs(int source, int destination)
		{
			bool[] vis = new bool[adj.Length];
			vis[source] = true;

			return dfsUtil(source, destination, vis);
		}
	}
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
