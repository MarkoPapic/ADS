using ADS.DataStructures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    /// <summary>
    /// Used for finding ONE OF the paths the specified vertex to the referent vertex in a given graph.
    /// </summary>
    /// <remarks>
    /// Initialization complexity: 2N
    /// </remarks>
    public class FindPathDfs
    {
        private readonly bool[] marked;
        private readonly int[] edgeTo;
        private readonly int referentVertex;

        public FindPathDfs(IGraph G, int r)
        {
            this.referentVertex = r;
            //We avoid using index 0, because we save it for special cases
            this.marked = new bool[G.V];
            this.edgeTo = new int[G.V];

            Dfs(G, r);
        }

        /// <summary>
        /// Returns ONE OF the paths from vertex to v to the referent vertex.
        /// </summary>
        /// <param name="v">Destination vertex.</param>
        /// <returns>Sequence of vertices that for a path from vertex <paramref name="v"/> to the referent vertex.</returns>
        /// <remarks>
        /// Compleixty: N
        /// </remarks>
        public IEnumerable<int> Path(int v)
        {
            List<int> result = new List<int>();

            if (v != this.referentVertex)
            {
                int currentVertex = edgeTo[v];

                while (currentVertex != 0)
                {
                    result.Add(currentVertex);
                    currentVertex = edgeTo[currentVertex];
                }
            }

            return result;
        }

        private void Dfs(IGraph g, int v)
        {
            this.marked[v] = true;
            IEnumerable<int> adjacent = g.Adj(v);
            foreach (int w in adjacent)
                if (!marked[w])
                {
                    Dfs(g, w);
                    edgeTo[w] = v;
                }
        }
    }
}
