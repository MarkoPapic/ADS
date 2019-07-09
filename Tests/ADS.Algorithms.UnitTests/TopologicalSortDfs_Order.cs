using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System.Linq;
using Xunit;

namespace ADS.Algorithms.UnitTests
{
    public class TopologicalSortDfs_Order
    {
        [Fact]
        public void HappyPath_OrderedCorrectly()
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
    }
}
