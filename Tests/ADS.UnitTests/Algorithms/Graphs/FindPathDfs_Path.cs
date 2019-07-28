using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.UnitTests.Algorithms.Graphs
{
    public class FindPathDfs_Path
    {
        [Fact]
        public void NoPath_EmptySequenceReturned()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 9), (6, 7) };
            Graph graph = new Graph(9);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            FindPathDfs dfsPath = new FindPathDfs(graph, 8);

            //Act
            int[] path = dfsPath.Path(7).ToArray();

            //Assert
            Assert.Empty(path);
        }

        [Fact]
        public void ReferentReferecePassed_EmptySequenceReturned()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 9), (6, 7) };
            Graph graph = new Graph(9);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            FindPathDfs dfsPath = new FindPathDfs(graph, 8);

            //Act
            int[] path = dfsPath.Path(8).ToArray();

            //Assert
            Assert.Empty(path);
        }

        [Fact]
        public void HappyPath_PathReturned()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9) };
            Graph graph = new Graph(9);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            FindPathDfs dfsPath = new FindPathDfs(graph, 8);
            int[] expectedPath = new int[] { 5, 1, 8 };

            //Act
            int[] path = dfsPath.Path(3).ToArray();

            //Assert
            Assert.Equal(expectedPath, path);
        }
    }
}
