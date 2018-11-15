using System;
using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.Graph
{
    public class Graph_Adj
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        [InlineData(-24)]
        [InlineData(6)]
        [InlineData(700)]
        [InlineData(20)]
        public void VertexIndexOutOfRange_ExceptionThrown(int value)
        {
            //Arrange
            DataStructures.Graph graph = new DataStructures.Graph(5);

            //Act
            Action act = () => { var adjacent = graph.Adj(value); };

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }


        [Fact]
        public void HappyPath_AdjacentVerticesReturned()
        {
            //Arrange
            (int, int)[] edges = new(int, int)[] { (1, 8), (1, 4), (4, 8), (1, 5), (2, 5), (3, 5), (3, 7), (3, 9) };
            DataStructures.Graph graph = new DataStructures.Graph(10);

            //Act
            foreach ((int, int) edge in edges)
                graph.AddEdge(edge.Item1, edge.Item2);

            //Assert
            int[] expectedEdges0 = new int[] { };
            int[] actualEdges0 = graph.Adj(0).ToArray();

            int[] expectedEdges1 = new int[] { 4, 5, 8 };
            int[] actualEdges1 = graph.Adj(1).OrderBy(x => x).ToArray();

            int[] expectedEdges2 = new int[] { 5 };
            int[] actualEdges2 = graph.Adj(2).OrderBy(x => x).ToArray();

            int[] expectedEdges3 = new int[] { 5, 7, 9 };
            int[] actualEdges3 = graph.Adj(3).OrderBy(x => x).ToArray();

            int[] expectedEdges4 = new int[] { 1, 8 };
            int[] actualEdges4 = graph.Adj(4).OrderBy(x => x).ToArray();

            int[] expectedEdges5 = new int[] { 1, 2, 3 };
            int[] actualEdges5 = graph.Adj(5).OrderBy(x => x).ToArray();

            int[] expectedEdges6 = new int[] { };
            int[] actualEdges6 = graph.Adj(6).ToArray();

            int[] expectedEdges7 = new int[] { 3 };
            int[] actualEdges7 = graph.Adj(7).OrderBy(x => x).ToArray();

            int[] expectedEdges8 = new int[] { 1, 4 };
            int[] actualEdges8 = graph.Adj(8).OrderBy(x => x).ToArray();

            int[] expectedEdges9 = new int[] { 3 };
            int[] actualEdges9 = graph.Adj(9).OrderBy(x => x).ToArray();

            Assert.Equal(expectedEdges0, actualEdges0);
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
