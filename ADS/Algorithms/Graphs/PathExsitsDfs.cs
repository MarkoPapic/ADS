using ADS.DataStructures;
using ADS.DataStructures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    /// <summary>
    /// Used for checking the two vertices of a graph are connected with a path.
    /// </summary>
    /// <remarks>
    /// Initialization complexity: 0
    /// </remarks>
    public class PathExsitsDfs
    {
        private bool[] visited;

        /// <summary>
        /// Returns whether there is a path from vertex <paramref name="s"/> to vertex <paramref name="d"/>.
        /// </summary>
        /// <param name="s">Source vertex.</param>
        /// /// <param name="d">Destination vertex.</param>
        /// <returns>A boolean value indicating whether the path exists..</returns>
        /// <remarks>
        /// Compleixty: N
        /// </remarks>
        public bool PathExists(IGraph graph, int s, int d)
        {
            visited = new bool[graph.V + 1];
            return Dfs(graph, s, d);
        }

        private bool Dfs(IGraph graph, int v, int destination)
        {
            if (v == destination)
                return true;
            visited[v] = true;
            foreach (int w in graph.Adj(v))
                if (!visited[w])
                {
                    bool pathExists = Dfs(graph, w, destination);
                    if (pathExists)
                        return true;
                }
            return false;
        }
    }
}
