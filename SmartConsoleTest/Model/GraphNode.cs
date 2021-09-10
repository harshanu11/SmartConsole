using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace CollectionTest
{
    public class GraphNode
    {
        private int V;
        public LinkedList<int>[] adjecent;
        public GraphNode(int v)
        {
            V = v;
            adjecent = new LinkedList<int>[v];
            for (int i = 0; i < v; ++i)
                adjecent[i] = new LinkedList<int>();
        }
        public virtual void addEdge(int source, int destination)
        {
            adjecent[source].AddLast(destination);
            adjecent[destination].AddLast(source);
        }
		public virtual int bfs(int source, int destination)
		{

			bool[] vis = new bool[adjecent.Length];
			int[] parent = new int[adjecent.Length];
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

				foreach (int neighbor in adjecent[cur])
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
				Debug.Write(cur + " -> ");
				cur = parent[cur];
				distance++;
			}

			return distance;
		}
        public List<int> bfsOfGraph(int V, List<List<int>> adj)
        {
            //boolean list to mark all the vertices as not visited.
            bool[] visited = new bool[V];

            int s = 0;
            //initially we mark first vertex as visited(true).
            visited[s] = true;

            List<int> res = new List<int>();

            //creating a queue for BFS and pushing first vertex in queue.
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);

            while (q.Count != 0)
            {
                //adding front element in output list and popping it from queue.
                s = q.Peek();
                q.Dequeue();
                res.Add(s);

                //traversing over all the connected components of front element.

                foreach (var v in adj[s])
                {

                    //if they aren't visited, we mark them visited and add to queue.
                    if (!visited[v])
                    {
                        visited[v] = true;
                        q.Enqueue(v);
                    }
                }
            }
            //returning the output list.
            return res;
        }
        private void dfs(int ch, ref bool[] vis, ref List<int> ans, ref List<List<int>> adj)
        {
            vis[ch] = true;
            ans.Add(ch);
            for (int i = 0; i < adj[ch].Count; i++)
                if (!vis[adj[ch][i]])
                    dfs(adj[ch][i], ref vis, ref ans, ref adj);
        }
        public List<int> dfsList(int V, List<List<int>> adj)
        {
            //using a boolean list to mark all the vertices as not visited.
            bool[] vis = new bool[V];
            for (int i = 0; i < V; i++) vis[i] = false;
            List<int> ans = new List<int>();
            dfs(0, ref vis, ref ans, ref adj);
            return ans;
        }

		private bool dfsUtil(int source, int destination, bool[] vis)
		{
			if (source == destination)
			{
				return true;
			}

			foreach (int neighbor in adjecent[source])
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
			bool[] vis = new bool[adjecent.Length];
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

				foreach (int neighbor in adjecent[cur])
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

		public virtual bool dfsR(int source, int destination)
		{
			bool[] vis = new bool[adjecent.Length];
			vis[source] = true;

			return dfsUtil(source, destination, vis);
		}

	}
    public class GraphNodeList 
    {
        private int V;
        public List<List<int>> adjecent;
        public GraphNodeList(int v)
        {
			adjecent = new List<List<int>>();
			V = v;
            for (int ver = 0; ver < V; ver++)
            {
				adjecent.Add(new List<int>());
            }
        }
		public void AddEdge(int source, int destination) 
		{
			adjecent[source].Add(destination);
			adjecent[destination].Add(source);
		}

    }
}
