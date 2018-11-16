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
    public static class PathExsitsDfs
    {
        /// <summary>
        /// Returns whether there is a path from vertex <paramref name="s"/> to vertex <paramref name="d"/>.
        /// </summary>
        /// <param name="s">Source vertex.</param>
        /// /// <param name="d">Destination vertex.</param>
        /// <returns>A boolean value indicating whether the path exists..</returns>
        /// <remarks>
        /// Compleixty: N
        /// </remarks>
        public static bool PathExists(this IGraph graph, int s, int d)
        {
            bool[] visited = new bool[graph.V + 1];
            DynamicArray<int> toVisit = new DynamicArray<int> { s };
            visited[s] = true;
            while (toVisit.Length > 0)
            {
                int current = toVisit.RemoveLast();
                IEnumerable<int> children = graph.Adj(current);
                foreach (int child in children)
                    if (!visited[child])
                    {
                        toVisit.Add(child);
                        visited[child] = true;
                    }
                if (current == d)
                    return true;
            }
            return false;
        }
    }
}
