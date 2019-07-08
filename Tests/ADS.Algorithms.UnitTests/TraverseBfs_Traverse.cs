using ADS.DataStructures;
using System.Collections.Generic;
using Xunit;
using static ADS.Algorithms.Graphs.TraverseBfs;

namespace ADS.Algorithms.UnitTests
{
    public class TraverseBfs_Traverse
    {
        [Fact]
        public void HappyPath_ConnectedVerticesTraversed()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9) };
            Graph graph = new Graph(9);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            List<int> expectedTraversedElements = new List<int> { 8, 1, 4, 5, 2, 3, 7, 9 };
            List<int> traversedElements = new List<int>();

            //Act
            graph.Traverse(8, v => traversedElements.Add(v));

            //Assert
            Assert.Equal(expectedTraversedElements, traversedElements);
        }
    }
}
