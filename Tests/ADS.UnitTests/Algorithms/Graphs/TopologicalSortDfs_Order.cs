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
            (int, int)[] edges = new (int, int)[] { (0, 1), (0, 2), (0, 5), (1, 4), (3, 6), (3, 2), (3, 5), (3, 4), (5, 2), (6, 0), (6, 4) };
            int[] expectedOrder = new int[] { 3, 6, 0, 5, 2, 1, 4 };
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
                new DirectedEdge(0, 1, 5),
                new DirectedEdge(0, 2, 2),
                new DirectedEdge(0, 5, -5),
                new DirectedEdge(1, 4, 30),
                new DirectedEdge(3, 6, 2.34),
                new DirectedEdge(3, 2, 17.5),
                new DirectedEdge(3, 5, 8),
                new DirectedEdge(3, 4, 0),
                new DirectedEdge(5, 2, -14),
                new DirectedEdge(6, 0, -158),
                new DirectedEdge(6, 4, 20)
            };
            int[] expectedOrder = new int[] { 3, 6, 0, 5, 2, 1, 4 };
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
