using System;

namespace ADS.DataStructures
{
    public class PriorityQueue<T> where T : IComparable
    {
        private readonly MinHeap<T> data;

        public int Count => this.data.Count;

        public PriorityQueue()
        {
            data = new MinHeap<T>();
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
