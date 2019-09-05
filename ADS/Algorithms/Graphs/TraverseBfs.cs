using ADS.DataStructures;
using ADS.DataStructures.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Graphs
{
    /// <summary>
    /// General breadth-first search algorithm used to perform some action on graph vertices.
    /// </summary>
    public static class TraverseBfs
    {
        /// <summary>
        /// Performs action <paramref name="action"/> on each vertex of graph <paramref name="graph"/>, starting from vertex <paramref name="start"/>.
        /// </summary>
        /// <param name="graph">A graph that will be traversed.</param>
        /// <param name="start">A vertex from which the traversal will start.</param>
        /// <param name="action">Action that will be performed on each visited vertice.</param>
        public static void Traverse(this IGraph graph, int start, Action<int> action)
        {
            bool[] visited = new bool[graph.V];
            Queue<int> toVisit = new Queue<int>();
            toVisit.Enqueue(start);
            visited[start] = true;
            while (toVisit.Count > 0)
            {
                int current = toVisit.Dequeue();
                IEnumerable<int> children = graph.Adj(current);
                foreach (int child in children)
                    if (!visited[child])
                    {
                        toVisit.Enqueue(child);
                        visited[child] = true;
                    }
                action(current);
            }
        }
    }
}
