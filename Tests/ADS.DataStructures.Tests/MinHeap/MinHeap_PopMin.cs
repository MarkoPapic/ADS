using System;
using System.Linq;
using Xunit;

namespace ADS.DataStructures.Tests.MinHeap
{
    public class MinHeap_PopMin
    {
        [Fact]
        public void EmptyHeap_ExceptionThrown() {
            //Arrange
            MinHeap<int> minHeap = new MinHeap<int>((a, b) => a.CompareTo(b));

            //Act
            Action act = () => minHeap.PeekMin();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_MinReturned() {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            MinHeap<int> minHeap = new MinHeap<int>((a, b) => a.CompareTo(b));

            foreach(int el in elements)
                minHeap.Insert(el);

            //Act && assert
            int[] elementsLeft = new int[elements.Length];
            elements.CopyTo(elementsLeft, 0);
            for (int i = 0; i < elements.Length; i++) {
                int actualMinEl = elementsLeft.Min();
                int minEl = minHeap.PopMin();
                Assert.Equal(actualMinEl, minEl);
                elementsLeft = elementsLeft.Where(x => x != actualMinEl).ToArray();
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            MinHeap<int> minHeap = new MinHeap<int>((a, b) => a.CompareTo(b));

            foreach (int el in elements)
                minHeap.Insert(el);

            //Act
            int minEl = minHeap.PopMin();

            //Assert
            Assert.Equal(9, minHeap.Count);
        }
    }
}
