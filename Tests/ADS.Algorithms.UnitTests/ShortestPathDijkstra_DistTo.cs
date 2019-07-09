using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System.Collections.Generic;
using Xunit;

namespace ADS.Algorithms.UnitTests
{
    public class ShortestPathDijkstra_DistTo
    {
        [Fact]
        public void HappyPath_ShortestDistancesReturned()
        {
            //Arrange
            Dictionary<int, double> expectedDistances = new Dictionary<int, double>
            {
                { 1, 0.0 },
                { 2, 5.0 },
                { 3, 14.0 },
                { 4, 17.0 },
                { 5, 9.0 },
                { 6, 13.0 },
                { 7, 25.0 },
                { 8, 8.0 },
            };
            EdgeWeightedDigraph graph = new EdgeWeightedDigraph(8);
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

            //Act
            ShortestPathDijkstra spd = new ShortestPathDijkstra(graph, 1);

            //Assert
            for (int i = 1; i <= 8; i++)
            {
                var distanceTo = spd.DistTo(i);
                Assert.Equal(distanceTo, expectedDistances[i]);
            }
        }
    }
}
