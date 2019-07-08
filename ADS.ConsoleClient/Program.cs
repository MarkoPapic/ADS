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

            Graph graph = new Graph(10);
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9), (5,10) };
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);

            TraverseBfs.Traverse(graph, 8, a => Console.WriteLine(a));

            Console.ReadKey();
        }
    }
}
