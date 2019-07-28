using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.UnitTests.Algorithms.Graphs
{
    public class ShortestPathDijkstra_PathTo
    {
        [Fact]
        public void HappyPath_ShortestDistancesReturned()
        {
            //Arrange
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
            Dictionary<int, DirectedEdge[]> expectedPaths = new Dictionary<int, DirectedEdge[]>
            {
                { 1, new DirectedEdge[] { } },
                { 2, new DirectedEdge[] { edges[0] } },
                { 3, new DirectedEdge[] { edges[2], edges[10], edges[12] } },
                { 4, new DirectedEdge[] { edges[2], edges[10], edges[12], edges[6] } },
                { 5, new DirectedEdge[] { edges[2] } },
                { 6, new DirectedEdge[] { edges[2], edges[10] } },
                { 7, new DirectedEdge[] { edges[2], edges[10], edges[12], edges[7] } },
                { 8, new DirectedEdge[] { edges[1] } },
            };
            foreach (var edge in edges)
                graph.AddEdge(edge);

            //Act
            ShortestPathDijkstra spd = new ShortestPathDijkstra(graph, 1);

            //Assert
            for (int i = 1; i <= 8; i++)
            {
                DirectedEdge[] pathTo = spd.PathTo(i).ToArray();
                DirectedEdge[] expectedPath = expectedPaths[i];
                Assert.True(expectedPath.SequenceEqual(pathTo));
            }
        }
    }
}
