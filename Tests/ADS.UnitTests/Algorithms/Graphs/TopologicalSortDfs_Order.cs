using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Algorithms.Graphs
{
    public class TopologicalSortDfs_Order
    {
        [Fact]
        public void HappyPathUnweighted_OrderedCorrectly()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 2), (1, 6), (1, 3), (2, 5), (4, 7), (4, 3), (4, 6), (4, 5), (6, 3), (7, 1), (7, 5) };
            int[] expectedOrder = new int[] { 4, 7, 1, 6, 3, 2, 5 };
            Digraph digraph = new Digraph(7);
            foreach (var edge in edges)
                digraph.AddEdge(edge.Item1, edge.Item2);

            //Act
            TopologicalSortDfs ts = new TopologicalSortDfs(digraph);
            int[] topologicalOrder = ts.Order().ToArray(); ;

            //Assert
            Assert.True(expectedOrder.SequenceEqual(topologicalOrder));
        }

        [Fact]
        public void HappyPathWeighted_OrderedCorrectly()
        {
            //Arrange
            DirectedEdge[] edges = new DirectedEdge[] {
                new DirectedEdge(1, 2, 5),
                new DirectedEdge(1, 6, 2),
                new DirectedEdge(1, 3, -5),
                new DirectedEdge(2, 5, 30),
                new DirectedEdge(4, 7, 2.34),
                new DirectedEdge(4, 3, 17.5),
                new DirectedEdge(4, 6, 8),
                new DirectedEdge(4, 5, 0),
                new DirectedEdge(6, 3, -14),
                new DirectedEdge(7, 1, -158),
                new DirectedEdge(7, 5, 20)
            };
            int[] expectedOrder = new int[] { 4, 7, 1, 6, 3, 2, 5 };
            EdgeWeightedDigraph digraph = new EdgeWeightedDigraph(7);
            foreach (DirectedEdge edge in edges)
                digraph.AddEdge(edge);

            //Act
            TopologicalSortDfs ts = new TopologicalSortDfs(digraph);
            int[] topologicalOrder = ts.Order().ToArray(); ;

            //Assert
            Assert.True(expectedOrder.SequenceEqual(topologicalOrder));
        }
    }
}
