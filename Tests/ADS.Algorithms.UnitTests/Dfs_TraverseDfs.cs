using ADS.DataStructures;
using ADS.Algorithms.Graphs;
using System.Collections.Generic;
using Xunit;

namespace ADS.Algorithms.UnitTests
{
    public class Dfs_TraverseDfs
    {
        [Fact]
        public void HappyPath_ConnectedVerticesTraversed()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9) };
            Graph graph = new Graph(9);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            List<int> expectedTraversedElements = new List<int> { 8, 4, 1, 5, 3, 9, 7, 2 };
            List<int> traversedElements = new List<int>();

            //Act
            graph.TraverseDfs(8, v => traversedElements.Add(v));

            //Assert
            Assert.Equal(expectedTraversedElements, traversedElements);
        }
    }
}
