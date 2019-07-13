using ADS.DataStructures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS.DataStructures
{
    public class Digraph : IGraph
    {
        private readonly int _v;
        private readonly DynamicArray<int>[] adj;

        public int V => this._v;

        public Digraph(int V)
        {
            this._v = V;
            //We avoid using index 0, because we save it for special cases
            this.adj = new DynamicArray<int>[V + 1];
            for (int i = 1; i <= V; i++)
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

            return this.adj[v];
        }

        private void ThrowIfOutOfRange(int index)
        {
            if (index < 0 || index > this.V)
                throw new IndexOutOfRangeException();
        }
    }
}
