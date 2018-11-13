using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.PriorityQueue
{
    public class PriorityQueue_Dequeue
    {
        [Fact]
        public void EmptyQueue_ExceptionThrown()
        {
            //Arrange
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>((a, b) => a.CompareTo(b));

            //Act
            Action act = () => priorityQueue.Dequeue();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_MinReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>((a, b) => a.CompareTo(b));

            foreach (int el in elements)
                priorityQueue.Enqueue(el);

            //Act && assert
            int[] elementsLeft = new int[elements.Length];
            elements.CopyTo(elementsLeft, 0);
            for (int i = 0; i < elements.Length; i++)
            {
                int actualMinEl = elementsLeft.Min();
                int minEl = priorityQueue.Dequeue();
                Assert.Equal(actualMinEl, minEl);
                elementsLeft = elementsLeft.Where(x => x != actualMinEl).ToArray();
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>((a, b) => a.CompareTo(b));

            foreach (int el in elements)
                priorityQueue.Enqueue(el);

            //Act
            int minEl = priorityQueue.Dequeue();

            //Assert
            Assert.Equal(9, priorityQueue.Count);
        }
    }
}
