using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.UnitTests.Algorithms.Graphs
{
    public class PathExistsDfs_PathExists
    {
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        public void PathDoesntExist_FalseReturned(int value)
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 9), (6, 7), (5, 10) };
            Graph graph = new Graph(10);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            PathExsitsDfs pathExsitsDfs = new PathExsitsDfs();

            //Act
            bool pathExists = pathExsitsDfs.PathExists(graph, 8, value);

            //Assert
            Assert.False(pathExists);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(9)]
        public void PathExists_TrueReturned(int value)
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 9), (6, 7), (5, 10) };
            Graph graph = new Graph(10);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            PathExsitsDfs pathExsitsDfs = new PathExsitsDfs();

            //Act
            bool pathExists = pathExsitsDfs.PathExists(graph, 8, value);

            //Assert
            Assert.True(pathExists);
        }
    }
}
