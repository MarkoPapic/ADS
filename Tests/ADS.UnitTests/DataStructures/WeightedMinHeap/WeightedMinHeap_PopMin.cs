using System;
using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.WeightedMinHeap
{
    public class WeightedMinHeap_PopMin
    {
        [Fact]
        public void EmptyHeap_ExceptionThrown()
        {
            //Arrange
            WeightedMinHeap<int, double> minHeap = new WeightedMinHeap<int, double>();

            //Act
            Action act = () => minHeap.PeekMin();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_MinReturned()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();

            foreach ((int, double) el in elements)
                weightedMinHeap.Insert(el.Item1, el.Item2);


            (int, double)[] elementsLeft = new (int, double)[elements.Length];
            elements.CopyTo(elementsLeft, 0);
            for (int i = 0; i < elements.Length; i++)
            {
                int actualMinEl = elementsLeft.OrderBy(x => x.Item2).First().Item1;
                int minEl = weightedMinHeap.PopMin();
                Assert.Equal(actualMinEl, minEl);
                elementsLeft = elementsLeft.Where(x => x.Item1 != actualMinEl).ToArray();
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();

            foreach ((int, double) el in elements)
                weightedMinHeap.Insert(el.Item1, el.Item2);

            //Act
            var minEl = weightedMinHeap.PopMin();

            //Assert
            Assert.Equal(6, weightedMinHeap.Count);
        }
    }
}
