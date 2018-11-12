using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures
{
    public class PriorityQueue<T>
    {
        private readonly MinHeap<T> data;

        public int Count => this.data.Count;

        public PriorityQueue(Func<T, T, int> compareFunc)
        {
            data = new MinHeap<T>(compareFunc);
        }

        public void Enqueue(T element)
        {
            this.data.Insert(element);
        }

        public T Dequeue()
        {
            if (this.data.Count == 0)
                throw new InvalidOperationException("Queue empty.");

            return this.data.PopMin();
        }

        public T Peek()
        {
            if (this.data.Count == 0)
                throw new InvalidOperationException("Queue empty.");

            return this.data.PeekMin();
        }
    }
}
