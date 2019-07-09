using ADS.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    /// <summary>
    /// Finds the shortest paths from a referent vertex to all other vertices in a weighted digraph. It only works for graphs with nonnegative weights.
    /// If the graph is unweighted, BFS is more efficient solution.
    /// </summary>
    public class ShortestPathDijkstra : ShortestPathBase
    {
        private readonly WeightedPriorityQueue<int, double> pq;

        public ShortestPathDijkstra(EdgeWeightedDigraph G, int s) : base(G, s)
        {
            pq = new WeightedPriorityQueue<int, double>();
            for (int v = 1; v <= G.V; v++)
                this.distTo[v] = double.PositiveInfinity;
            this.distTo[s] = 0.0;

            pq.Enqueue(s, 0.0);
            while(pq.Count > 0)
            {
                int v = pq.Dequeue();
                foreach (DirectedEdge e in G.Adj(v))
                    Relax(e);
            }
        }

        protected override void Relax(DirectedEdge e)
        {
            int v = e.From;
            int w = e.To;
            if (distTo[w] > distTo[v] + e.Weight)
            {
                distTo[w] = distTo[v] + e.Weight;
                edgeTo[w] = e;
                if (pq.Contains(w))
                    pq.UpdateWeight(w, distTo[w]);
                else
                    pq.Enqueue(w, distTo[w]);
            }
        }
    }
}
