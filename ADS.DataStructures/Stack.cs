using System;

namespace ADS.DataStructures
{
    public class Stack<T>
    {
        private readonly DynamicArray<T> data;

        public int Count => this.data.Length;

        public Stack()
        {
            data = new DynamicArray<T>();
        }

        public void Push(T element)
        {
            this.data.Add(element);
        }

        public T Pop()
        {
            if (this.data.Length == 0)
                throw new InvalidOperationException("Unable to pop from an empty stack.");

            return this.data.RemoveLast();
        }

        public T Peek()
        {
            if (this.data.Length == 0)
                throw new InvalidOperationException("Stack empty.");

            return this.data[this.data.Length - 1];
        }
    }
}
