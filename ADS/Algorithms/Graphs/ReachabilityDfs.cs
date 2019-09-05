using ADS.DataStructures;
using ADS.DataStructures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    /// <summary>
    /// Given a digraph and a set of source vertices, support queries of the form "Is there a directed path from any vertex in the set to a given target vertex v?"
    /// </summary>
    /// <remarks>
    /// Initialization complexity: N * S. Instances of this class are stateful.
    /// </remarks>
    public class ReachabilityDfs
    {
        private bool[] visited;

        /// <summary>
        /// Initializes a class.
        /// </summary>
        /// <param name="G">Graph.</param>
        /// <param name="s">Referent vertex.</param>
        public ReachabilityDfs(IGraph G, int s)
        {
            visited = new bool[G.V];
            Dfs(G, s);
        }

        /// <summary>
        /// Initializes a class.
        /// </summary>
        /// <param name="G">Graph.</param>
        /// <param name="sources">Referent vertices.</param>
        public ReachabilityDfs(IGraph G, IEnumerable<int> sources)
        {
            visited = new bool[G.V];
            foreach (int s in sources)
                if (!visited[s]) Dfs(G, s);
        }

        /// <summary>
        /// Checks if vertex <paramref name="v"/> is reachable from any of the referent vertices.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>A boolean value indicating whether the vertex is reachable.</returns>
        /// /// <remarks>
        /// Compleixty: 1
        /// </remarks>
        public bool Reachable(int v) => visited[v];

        private void Dfs(IGraph G, int v)
        {
            visited[v] = true;
            foreach (int w in G.Adj(v))
                if (!visited[w])
                    Dfs(G, w);
        }
    }
}
