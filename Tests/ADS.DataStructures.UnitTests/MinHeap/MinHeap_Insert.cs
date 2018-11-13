using System;
using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.MinHeap
{
    public class MinHeap_Insert
    {
        [Fact]
        public void HappyPath_MinCorrect() {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50};
            MinHeap<int> minHeap = new MinHeap<int>((a, b) => a.CompareTo(b));

            //Act && assert
            for (int i = 0; i < elements.Length; i++) {
                minHeap.Insert(elements[i]);
                int minEl = minHeap.PeekMin();
                int minFromInserted = elements.Take(i + 1).Min();
                Assert.Equal(minFromInserted, minEl);
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            MinHeap<int> minHeap = new MinHeap<int>((a, b) => a.CompareTo(b));

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                minHeap.Insert(elements[i]);
                Assert.Equal(i + 1, minHeap.Count);
            }
        }
    }
}
