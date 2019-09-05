using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using Xunit;

namespace ADS.UnitTests.Algorithms.Graphs
{
    public class ReachableDfs_Reachable
    {
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        public void SingleSource_PathDoesntExist_FalseReturned(int value)
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 9), (6, 7), (5, 10) };
            Digraph graph = new Digraph(11);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            ReachabilityDfs reachability = new ReachabilityDfs(graph, 8);

            //Act
            bool reachable = reachability.Reachable(value);

            //Assert
            Assert.False(reachable);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        public void MultipleSources_PathDoesntExist_FalseReturned(int value)
        {
            //Arrange
            int[] sources = { 8, 5, 10 };
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 9), (6, 7), (5, 10) };
            Digraph graph = new Digraph(11);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            ReachabilityDfs reachability = new ReachabilityDfs(graph, sources);

            //Act
            bool reachable = reachability.Reachable(value);

            //Assert
            Assert.False(reachable);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(9)]
        public void SingleSource_PathExists_TrueReturned(int value)
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (8, 1), (1, 4), (4, 8), (1, 5), (2, 5), (5, 3), (3, 9), (9, 8), (5, 10) };
            Digraph graph = new Digraph(11);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            ReachabilityDfs reachability = new ReachabilityDfs(graph, 8);

            //Act
            bool reachable = reachability.Reachable(value);

            //Assert
            Assert.True(reachable);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(9)]
        public void MultipleSources_PathExists_TrueReturned(int value)
        {
            //Arrange
            int[] sources = { 8, 5, 10 };
            (int, int)[] edges = new (int, int)[] { (8, 1), (1, 4), (4, 8), (3, 6), (2, 5), (5, 3), (3, 9), (9, 8), (5, 10) };
            Digraph graph = new Digraph(11);
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);
            ReachabilityDfs reachability = new ReachabilityDfs(graph, sources);

            //Act
            bool reachable = reachability.Reachable(value);

            //Assert
            Assert.True(reachable);
        }
    }
}
