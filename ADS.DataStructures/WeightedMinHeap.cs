using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures
{
    /// <summary>
    /// Like a regular min heap, but instead of comparing elements themselves, it compares their weights
    /// </summary>
    public class WeightedMinHeap<T, TWeight> where TWeight : IComparable
    {
        private readonly DynamicArray<WeightedElement> data;

        public int Count => this.data.Length;

        public WeightedMinHeap()
        {
            data = new DynamicArray<WeightedElement>();
        }

        public void Insert(T element, TWeight weight)
        {
            this.data.Add(new WeightedElement(element, weight));
            BubbleLastUp();
        }

        public T PopMin()
        {
            if (this.data.Length == 0)
                throw new InvalidOperationException("Unable to remove from an empty heap.");

            T result = this.data[0].Element;

            Swap(0, this.data.Length - 1);
            this.data.RemoveLast();
            BubbleFirstDown();

            return result;
        }

        public T PeekMin()
        {
            if (this.data.Length == 0)
                throw new InvalidOperationException("Heap empty.");

            return this.data[0].Element;
        }

        public void ChangeWeight(T element, TWeight weight)
        {
            WeightedElement foundElement = null;
            int foundIndex = -1;

            for (int i = 0; i < this.data.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(this.data[i].Element, element))
                {
                    foundElement = this.data[i];
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex == -1)
                throw new InvalidOperationException("Element not found.");

            foundElement.Weight = weight;
            BubbleUp(foundIndex);
            BubbleDown(foundIndex);
        }

        public bool Contains(T element)
        {
            int foundIndex = -1;

            for (int i = 0; i < this.data.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(this.data[i].Element, element))
                {
                    foundIndex = i;
                    break;
                }
            }

            return foundIndex != -1;
        }

        private void BubbleLastUp()
        {
            int currentElIndex = this.data.Length - 1;

            if (currentElIndex == 0)
                return;


            BubbleUp(currentElIndex);
        }

        private void BubbleFirstDown()
        {
            BubbleDown(0);
        }

        private void BubbleUp(int currentElIndex)
        {
            int parentIndex = GetParentIndex(currentElIndex);

            while (currentElIndex > 0 && GreaterThan(this.data[parentIndex], this.data[currentElIndex]))
            {
                Swap(currentElIndex, parentIndex);
                currentElIndex = parentIndex;
                parentIndex = GetParentIndex(parentIndex);
            }
        }

        private void BubbleDown(int currentIndex)
        {
            while (currentIndex <= this.data.Length - 1)
            {
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
                WeightedElement temp = this.data[indexA];
                this.data[indexA] = this.data[indexB];
                this.data[indexB] = temp;
            }
        }

        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        private bool GreaterThan(WeightedElement a, WeightedElement b)
        {
            return a.Weight.CompareTo(b.Weight) > 0;
        }

        private class WeightedElement
        {
            internal WeightedElement(T e, TWeight w)
            {
                Element = e;
                Weight = w;
            }

            internal T Element { get; }
            internal TWeight Weight { get; set; }
        }
    }
}
