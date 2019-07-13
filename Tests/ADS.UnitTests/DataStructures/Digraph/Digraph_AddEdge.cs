using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.Digraph
{
    public class Digraph_AddEdge
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        [InlineData(-24)]
        [InlineData(6)]
        [InlineData(700)]
        [InlineData(20)]
        public void FirstVertexIndexOutOfRange_ExceptionThrown(int value)
        {
            //Arrange
            DataStructures.Digraph digraph = new DataStructures.Digraph(5);

            //Act
            Action act = () => digraph.AddEdge(value, 4);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        [InlineData(-24)]
        [InlineData(6)]
        [InlineData(700)]
        [InlineData(20)]
        public void SecondVertexIndexOutOfRange_ExceptionThrown(int value)
        {
            //Arrange
            DataStructures.Digraph digraph = new DataStructures.Digraph(5);

            //Act
            Action act = () => digraph.AddEdge(value, 4);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void HappyPath_VerticesConnected()
        {
            //Arrange
            (int, int)[] edges = new (int, int)[] { (1, 8), (1, 4), (4, 8), (8, 4), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9) };
            DataStructures.Digraph digraph = new DataStructures.Digraph(11);

            //Act
            foreach ((int, int) edge in edges)
                digraph.AddEdge(edge.Item1, edge.Item2);

            //Assert
            int[] expectedEdges1 = new int[] { 4, 5, 8 };
            int[] actualEdges1 = digraph.Adj(1).OrderBy(x => x).ToArray();

            int[] expectedEdges2 = new int[] { 5 };
            int[] actualEdges2 = digraph.Adj(2).OrderBy(x => x).ToArray();

            int[] expectedEdges3 = new int[] { 5, 7, 9 };
            int[] actualEdges3 = digraph.Adj(3).OrderBy(x => x).ToArray();

            int[] expectedEdges4 = new int[] { 8 };
            int[] actualEdges4 = digraph.Adj(4).OrderBy(x => x).ToArray();

            int[] expectedEdges5 = new int[] { };
            int[] actualEdges5 = digraph.Adj(5).ToArray();

            int[] expectedEdges6 = new int[] { };
            int[] actualEdges6 = digraph.Adj(6).ToArray();

            int[] expectedEdges7 = new int[] { };
            int[] actualEdges7 = digraph.Adj(7).ToArray();

            int[] expectedEdges8 = new int[] { 4 };
            int[] actualEdges8 = digraph.Adj(8).OrderBy(x => x).ToArray();

            int[] expectedEdges9 = new int[] { };
            int[] actualEdges9 = digraph.Adj(9).ToArray();

            Assert.Equal(expectedEdges1, actualEdges1);
            Assert.Equal(expectedEdges2, actualEdges2);
            Assert.Equal(expectedEdges3, actualEdges3);
            Assert.Equal(expectedEdges4, actualEdges4);
            Assert.Equal(expectedEdges5, actualEdges5);
            Assert.Equal(expectedEdges6, actualEdges6);
            Assert.Equal(expectedEdges7, actualEdges7);
            Assert.Equal(expectedEdges8, actualEdges8);
            Assert.Equal(expectedEdges9, actualEdges9);
        }
    }
}
