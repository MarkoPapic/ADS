using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.DataStructures.Tests.PriorityQueue
{
    public class PriorityQueue_Enqueue
    {
        [Fact]
        public void HappyPath_MinCorrect()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>((a, b) => a.CompareTo(b));

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                priorityQueue.Enqueue(elements[i]);
                int minEl = priorityQueue.Peek();
                int minFromInserted = elements.Take(i + 1).Min();
                Assert.Equal(minFromInserted, minEl);
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>((a, b) => a.CompareTo(b));

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                priorityQueue.Enqueue(elements[i]);
                Assert.Equal(i + 1, priorityQueue.Count);
            }
        }
    }
}
