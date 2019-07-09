using ADS.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    public abstract class ShortestPathBase
    {
        /// <summary>
        /// Each element of this array represents the last edge on the shortest known path from s to v.
        /// </summary>
        protected readonly DirectedEdge[] edgeTo;
        protected readonly double[] distTo;
        protected readonly int s;

        public ShortestPathBase(EdgeWeightedDigraph G, int s)
        {
            //We avoid using index 0, because we save it for special cases
            edgeTo = new DirectedEdge[G.V + 1];
            distTo = new double[G.V + 1];
            this.s = s;
        }

        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            LinkedList<DirectedEdge> result = new LinkedList<DirectedEdge>();
            for (DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From])
                result.AddFirst(e);
            return result;
        }

        /// <summary>
        /// Gets the length of the shortest known path from s to v.
        /// </summary>
        /// <param name="v">Destination vertex.</param>
        /// <returns>Length of the shortest known path from s to v.</returns>
        public double DistTo(int v) => distTo[v];

        protected abstract void Relax(DirectedEdge e);
    }
}
