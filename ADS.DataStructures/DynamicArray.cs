using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ADS.DataStructures
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        private const int INITIAL_ARRAY_SIZE = 16;
        private const int INCREASE_DEGREE = 2;
        private const int DECREASE_FRACTION_TRESHOLD = 4;

        private T[] data;
        private int _length;

        public int Length => this._length;

        public DynamicArray()
        {
            this.data = new T[INITIAL_ARRAY_SIZE];
            this._length = 0;
        }

        public T this[int key] {
            get {
                if (key < 0 || key >= this._length)
                    throw new IndexOutOfRangeException();
                return this.data[key];
            }
            set {
                if (key < 0 || key >= this._length)
                    throw new IndexOutOfRangeException();
                this.data[key] = value;
            }
        }

        public void Add(T element) {
            this.data[this._length++] = element;
            if (this.ShouldIncreaseCapacity())
                this.IncreaseCapacity();
        }

        public T RemoveLast() {
            if (this._length == 0)
                throw new InvalidOperationException("Unable to remove from an empty array.");

            T el = this.data[--this._length];
            if (this.ShouldDecreaseCapacity())
                this.DecreaseCapacity();
            return el;
        }

        private bool ShouldIncreaseCapacity() => this.data.Length == this._length;
        private bool ShouldDecreaseCapacity() => this._length < (this.data.Length / DECREASE_FRACTION_TRESHOLD);

        private void IncreaseCapacity() {
            T[] newDataArray = new T[this.data.Length * INCREASE_DEGREE];
            for (int i = 0; i < this.data.Length; i++)
                newDataArray[i] = this.data[i];
            this.data = newDataArray;
        }

        private void DecreaseCapacity() {
            T[] newDataArray = new T[this.data.Length / DECREASE_FRACTION_TRESHOLD];
            for (int i = 0; i < newDataArray.Length; i++)
                newDataArray[i] = this.data[i];
            this.data = newDataArray;
        }

        public IEnumerator<T> GetEnumerator() {
            return new DynamicArrayEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        public class DynamicArrayEnumerator : IEnumerator<T>
        {
            private readonly DynamicArray<T> parent;
            private int currentIndex;
            private T currentElement;

            public T Current => this.currentElement;

            object IEnumerator.Current => Current;

            public DynamicArrayEnumerator(DynamicArray<T> parent) {
                this.parent = parent;
                this.currentIndex = -1;
                this.currentElement = default(T);
            }

            public bool MoveNext()
            {
                if (++this.currentIndex >= this.parent.Length)
                    return false;
                else
                {
                    this.currentElement = this.parent[this.currentIndex];
                    return true;
                }
            }

            public void Reset() => this.currentIndex = -1;

            public void Dispose() {}
        }

        //TODO: Implement equality methods and operators
    }
}
