using System;

namespace ADS.DataStructures
{
    public class WeightedPriorityQueue<T, TWeight> where TWeight : IComparable
    {
        private readonly WeightedMinHeap<T, TWeight> data;

        public int Count => this.data.Count;

        public WeightedPriorityQueue()
        {
            data = new WeightedMinHeap<T, TWeight>();
        }

        public void Enqueue(T element, TWeight weight)
        {
            this.data.Insert(element, weight);
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

        public void UpdateWeight(T element, TWeight weight)
        {
            this.data.ChangeWeight(element, weight);
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }
    }
}
