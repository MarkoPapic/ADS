using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS.DataStructures
{
    public class Digraph
    {
        private readonly int V;
        private readonly DynamicArray<int>[] adj;

        public Digraph(int V)
        {
            this.V = V;
            this.adj = new DynamicArray<int>[V];
            for (int i = 0; i < V; i++)
                adj[i] = new DynamicArray<int>();
        }

        public void AddEdge(int v, int w)
        {
            ThrowIfOutOfRange(v);
            ThrowIfOutOfRange(w);

            this.adj[v].Add(w);
        }

        public IEnumerable<int> Adj(int v)
        {
            ThrowIfOutOfRange(v);

            //return this.adj[v];
            return this.adj[v].ToArray(); //Create a copy to prevent someone from modifying the adjacency list
        }

        private void ThrowIfOutOfRange(int index)
        {
            if (index < 0 || index >= this.V)
                throw new IndexOutOfRangeException();
        }
    }
}
