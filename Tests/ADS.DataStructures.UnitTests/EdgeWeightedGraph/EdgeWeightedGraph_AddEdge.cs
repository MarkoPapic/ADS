using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.EdgeWeightedGraph
{
    public class EdgeWeightedGraph_AddEdge
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
            DataStructures.EdgeWeightedGraph ewGraph = new DataStructures.EdgeWeightedGraph(5);
            Edge edge = new Edge(value, 4, 5);

            //Act
            Action act = () => ewGraph.AddEdge(edge);

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
            DataStructures.EdgeWeightedGraph ewGraph = new DataStructures.EdgeWeightedGraph(5);
            Edge edge = new Edge(4, value, 5);

            //Act
            Action act = () => ewGraph.AddEdge(edge);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void HappyPath_VerticesConnectedWithCorrectWeight()
        {
            //Arrange
            Edge[] edges = new Edge[] { new Edge(1, 8, 12.5), new Edge(1, 4, 4), new Edge(4, 8, 1), new Edge(1, 5, 120.8), new Edge(2, 5, 89.9), new Edge(3, 5, 3), new Edge(3, 7, 19), new Edge(3, 9, 24.9) };
            DataStructures.EdgeWeightedGraph ewGraph = new DataStructures.EdgeWeightedGraph(10);

            //Act
            foreach (Edge edge in edges)
                ewGraph.AddEdge(edge);

            //Assert
            Edge[] expectedEdges0 = new Edge[] { };
            Edge[] actualEdges0 = ewGraph.Adj(0).ToArray();

            Edge[] expectedEdges1 = new Edge[] { edges[0], edges[1], edges[3] };
            Edge[] actualEdges1 = ewGraph.Adj(1).ToArray();

            Edge[] expectedEdges2 = new Edge[] { edges[4] };
            Edge[] actualEdges2 = ewGraph.Adj(2).ToArray();

            Edge[] expectedEdges3 = new Edge[] { edges[5], edges[6], edges[7] };
            Edge[] actualEdges3 = ewGraph.Adj(3).ToArray();

            Edge[] expectedEdges4 = new Edge[] { edges[1], edges[2] };
            Edge[] actualEdges4 = ewGraph.Adj(4).ToArray();

            Edge[] expectedEdges5 = new Edge[] { edges[3], edges[4], edges[5] };
            Edge[] actualEdges5 = ewGraph.Adj(5).ToArray();

            Edge[] expectedEdges6 = new Edge[] { };
            Edge[] actualEdges6 = ewGraph.Adj(6).ToArray();

            Edge[] expectedEdges7 = new Edge[] { edges[6] };
            Edge[] actualEdges7 = ewGraph.Adj(7).ToArray();

            Edge[] expectedEdges8 = new Edge[] { edges[0], edges[2] };
            Edge[] actualEdges8 = ewGraph.Adj(8).ToArray();

            Edge[] expectedEdges9 = new Edge[] { edges[7] };
            Edge[] actualEdges9 = ewGraph.Adj(9).ToArray();

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
