using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures
{
    public class EdgeWeightedDigraph
    {
        private readonly int _v;
        private readonly List<DirectedEdge>[] adj;

        public int V => this._v;

        public EdgeWeightedDigraph(int V)
        {
            this._v = V;
            //We avoid using index 0, because we save it for special cases
            this.adj = new List<DirectedEdge>[V];
            for (int i = 0; i < V; i++)
                adj[i] = new List<DirectedEdge>();
        }

        public void AddEdge(DirectedEdge e)
        {
            int v = e.From;
            int w = e.To;

            ThrowIfOutOfRange(v);
            ThrowIfOutOfRange(w);

            this.adj[v].Add(e);
            this.adj[w].Add(e);
        }

        public IEnumerable<DirectedEdge> Adj(int v)
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

    public class DirectedEdge : IComparable<DirectedEdge>
    {
        private readonly int _v;
        private readonly int _w;
        private readonly double _weight;

        public DirectedEdge(int v, int w, double weight)
        {
            this._v = v;
            this._w = w;
            this._weight = weight;
        }

        public int From => this._v;
        public int To => this._w;
        public double Weight => this._weight;

        public int CompareTo(DirectedEdge other)
        {
            if (this._weight < other._weight)
                return -1;
            else if (this._weight > other._weight)
                return 1;
            else
                return 0;
        }

        public override string ToString()
        {
            return $"{this._v} -> {this._w} ({this._weight})";
        }
    }
}
