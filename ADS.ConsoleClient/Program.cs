using System;
using ADS.Algorithms.Graphs;
using ADS.DataStructures;

namespace ADS.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeedTestsRunner speedTestsRunner = new SpeedTestsRunner();
            //speedTestsRunner.RunAll();

            /*Graph graph = new Graph(10);
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9), (5,10) };
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);

            TraverseBfs.Traverse(graph, 8, a => Console.WriteLine(a));*/

            /*EdgeWeightedDigraph graph = new EdgeWeightedDigraph(8);
            DirectedEdge[] edges = new DirectedEdge[]
            {
                new DirectedEdge(1, 2, 5),
                new DirectedEdge(1, 8, 8),
                new DirectedEdge(1, 5, 9),
                new DirectedEdge(2, 4, 15),
                new DirectedEdge(2, 3, 12),
                new DirectedEdge(2, 8, 4),
                new DirectedEdge(3, 4, 3),
                new DirectedEdge(3, 7, 11),
                new DirectedEdge(4, 7, 9),
                new DirectedEdge(5, 8, 5),
                new DirectedEdge(5, 6, 4),
                new DirectedEdge(5, 7, 20),
                new DirectedEdge(6, 3, 1),
                new DirectedEdge(6, 7, 13),
                new DirectedEdge(8, 3, 7),
                new DirectedEdge(8, 6, 6)
            };
            foreach (var edge in edges)
                graph.AddEdge(edge);

            ShortestPathDijkstra spd = new ShortestPathDijkstra(graph, 1);

            for (int i = 2; i <= 8; i++)
            {
                var distanceTo = spd.DistTo(i);
                var pathTo = spd.PathTo(i);
                Console.WriteLine($"Distance to {i}: {distanceTo}");
                Console.WriteLine($"Path to {i}:");
                foreach (var edge in pathTo)
                    Console.WriteLine($"\t{edge}");
                Console.WriteLine("\n");
            }*/


            Console.ReadKey();
        }
    }
}
