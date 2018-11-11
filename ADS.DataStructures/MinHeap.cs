using System;

namespace ADS.DataStructures
{
    public class MinHeap<T> where T : IComparable
    {
        private DynamicArray<T> data;

        public int Count => this.data.Length;

        public MinHeap()
        {
            data = new DynamicArray<T>();
        }

        public void Insert(T element)
        {
            this.data.Add(element);
            BubbleLastUp();
        }

        public T PopMin() {
            if (this.data.Length == 0)
                throw new InvalidOperationException("Unable to remove from an empty heap");

            T result = this.data[0];

            Swap(0, this.data.Length - 1);
            this.data.RemoveLast();
            BubbleFirstDown();

            return result;
        }

        public T PeekMin() {
            if (this.data.Length == 0)
                throw new InvalidOperationException("Unable to remove from an empty heap");

            return this.data[0];
        }

        private void BubbleLastUp() {
            int currentElIndex = this.data.Length - 1; //Start from the last

            if (currentElIndex == 0)
                return;

            int parentIndex = GetParentIndex(currentElIndex);

            while (currentElIndex > 0 && GreaterThan(this.data[parentIndex], this.data[currentElIndex])) {
                Swap(currentElIndex, parentIndex);
                currentElIndex = parentIndex;
                parentIndex = GetParentIndex(parentIndex);
            }
        }

        private void BubbleFirstDown() {
            int currentIndex = 0;
            while (currentIndex <= this.data.Length - 1) {
                int smallestIndex = currentIndex;
                int leftChildIndex = GetLeftChildIndex(currentIndex);
                int rightChildIndex = leftChildIndex + 1;

                if (leftChildIndex <= this.data.Length - 1 && GreaterThan(this.data[currentIndex], this.data[leftChildIndex]))
                    smallestIndex = leftChildIndex;
                if (rightChildIndex <= this.data.Length - 1 && GreaterThan(this.data[smallestIndex], this.data[rightChildIndex]))
                    smallestIndex = rightChildIndex;

                if (smallestIndex == currentIndex)
                    return;

                Swap(currentIndex, smallestIndex);
                currentIndex = smallestIndex;
            }
        }

        private void Swap(int indexA, int indexB)
        {
            if (indexA != indexB)
            {
                T temp = this.data[indexA];
                this.data[indexA] = this.data[indexB];
                this.data[indexB] = temp;
            }
        }

        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        private bool GreaterThan(T a, T b) {
            return a.CompareTo(b) > 0;
        }
    }
}
