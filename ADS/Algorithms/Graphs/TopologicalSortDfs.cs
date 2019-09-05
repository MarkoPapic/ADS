using ADS.DataStructures;
using System.Collections.Generic;

namespace ADS.Algorithms.Graphs
{
    public class TopologicalSortDfs
    {
        private bool[] visited;
        private LinkedList<int> reversePostOrder;

        public TopologicalSortDfs(Digraph graph)
        {
            reversePostOrder = new LinkedList<int>();
            //We avoid using index 0, because we save it for special cases
            visited = new bool[graph.V];
            //We need to iterate in case graph is not connected. This way we will traverse the whole graph.
            for (int v = 0; v < graph.V; v++)
                if (!visited[v])
                    Dfs(graph, v);
        }

        //These two constructors are the same, but I wanted to support both weighted and unweighted digraphs.
        //And it was easier for me to do it this way than to create two classes.
        public TopologicalSortDfs(EdgeWeightedDigraph graph)
        {
            reversePostOrder = new LinkedList<int>();
            //We avoid using index 0, because we save it for special cases
            visited = new bool[graph.V];
            //We need to iterate in case graph is not connected. This way we will traverse the whole graph.
            for (int v = 0; v < graph.V; v++)
                if (!visited[v])
                    Dfs(graph, v);
        }

        public IEnumerable<int> Order() => reversePostOrder;

        private void Dfs(Digraph graph, int v)
        {
            visited[v] = true;
            foreach (int w in graph.Adj(v))
                if (!visited[w])
                    Dfs(graph, w);
            reversePostOrder.AddFirst(v);
        }

        private void Dfs(EdgeWeightedDigraph graph, int v)
        {
            visited[v] = true;
            foreach (DirectedEdge e in graph.Adj(v))
            {
                int w = e.To;
                if (!visited[w])
                    Dfs(graph, w);
            }
            reversePostOrder.AddFirst(v);
        }
    }
}
