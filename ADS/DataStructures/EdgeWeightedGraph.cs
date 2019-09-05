using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures
{
    public class EdgeWeightedGraph
    {
        private readonly int _v;
        private readonly List<Edge>[] adj;

        public int V => this._v;

        public EdgeWeightedGraph(int V)
        {
            this._v = V;
            //We avoid using index 0, because we save it for special cases
            this.adj = new List<Edge>[V];
            for (int i = 0; i < V; i++)
                adj[i] = new List<Edge>();
        }

        public void AddEdge(Edge e)
        {
            int v = e.Either();
            int w = e.Other(v);

            ThrowIfOutOfRange(v);
            ThrowIfOutOfRange(w);

            this.adj[v].Add(e);
            this.adj[w].Add(e);
        }

        public IEnumerable<Edge> Adj(int v)
        {
            ThrowIfOutOfRange(v);

            return this.adj[v];
        }

        private void ThrowIfOutOfRange(int index)
        {
            if (index < 0 || index >= this.V)
                throw new IndexOutOfRangeException();
        }
    }

    public class Edge : IComparable<Edge>
    {
        private readonly int v;
        private readonly int w;
        private readonly double weight;

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public int Either()
        {
            return v;
        }

        public int Other(int vertex)
        {
            if (vertex == v)
                return w;
            return v;
        }

        public int CompareTo(Edge other)
        {
            if (this.weight < other.weight)
                return -1;
            else if (this.weight > other.weight)
                return 1;
            else
                return 0;
        }
    }
}
