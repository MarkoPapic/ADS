using ADS.DataStructures;
using ADS.DataStructures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    /// <summary>
    /// General depth-first search algorithm used to perform some action on graph vertices.
    /// </summary>
    public class TraverseDfs
    {
        private bool[] visited;

        /// <summary>
        /// Performs action <paramref name="action"/> on each vertex of graph <paramref name="graph"/>, starting from vertex <paramref name="start"/>.
        /// </summary>
        /// <param name="graph">A graph that will be traversed.</param>
        /// <param name="start">A vertex from which the traversal will start.</param>
        /// <param name="action">Action that will be performed on each visited vertice.</param>
        public void Traverse(IGraph graph, int start, Action<int> action)
        {
            //We avoid using index 0, because we save it for special cases
            visited = new bool[graph.V + 1];
            Dfs(graph, start, action);
        }

        private void Dfs(IGraph graph, int v, Action<int> action)
        {
            action(v);
            visited[v] = true;
            foreach (int w in graph.Adj(v))
                if (!visited[w])
                {
                    Dfs(graph, w, action);
                }
        }
    }
}
