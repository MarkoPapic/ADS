using System;
using System.Collections.Generic;
using System.Text;
using ADS.DataStructures;

namespace ADS.Algorithms.Graphs
{
    public class ShortestPathTopologicalSort : ShortestPathBase
    {
        public ShortestPathTopologicalSort(EdgeWeightedDigraph G, int s) : base(G, s)
        {
            TopologicalSortDfs topological = new TopologicalSortDfs(G);
            foreach (int v in topological.Order())
                foreach (DirectedEdge e in G.Adj(v))
                    Relax(e);
        }

        protected override void Relax(DirectedEdge e)
        {
            int v = e.From;
            int w = e.To;
            if (distTo[w] > distTo[v] + e.Weight)
            {
                distTo[w] = distTo[v] + e.Weight;
                edgeTo[w] = e;
            }
        }
    }
}
