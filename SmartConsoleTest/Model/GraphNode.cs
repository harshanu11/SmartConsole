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
				Console.Write(cur + " -> ");
				cur = parent[cur];
				distance++;
			}

			return distance;
		}
	
	}
}
