using System;
using System.Collections.Generic;

namespace ADS.DataStructures
{
    /// <summary>
    /// Set approach of binary search tree.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class RedBlackBstSet<T> where T : IComparable<T>
    {
        private Node root;
        private const bool RED = true;
        private const bool BLACK = false;

        public int Count => GetCount(root);

        public T Get(T el) => Get(root, el);

        public void Insert(T el)
        {
            root = Insert(root, el);
            root.Color = BLACK;
        }

        public void Delete(T el)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the element with the minimum value.
        /// </summary>
        /// <returns>Element with the minimum value.</returns>
        public T Min()
        {
            return Min(root).Value;
        }

        /// <summary>
        /// Finds the element with the maximum value.
        /// </summary>
        /// <returns>Element with the maximum value.</returns>
        public T Max()
        {
            return Max(root).Value;
        }

        public bool Exists(T el)
        {
            return Exists(root, el);
        }

        public IEnumerable<T> Values()
        {
            return Values(Min(), Max());
        }

        public IEnumerable<T> Values(T lo, T hi)
        {
            Queue<T> queue = new Queue<T>();
            Values(root, queue, lo, hi);
            return queue;
        }

        private T Get(Node x, T el)
        {
            if (x == null)
                throw new InvalidOperationException("Element doesn't exist.");
            int cmp = el.CompareTo(x.Value);
            if (cmp < 0)
                return Get(x.Left, el);
            else if (cmp > 0)
                return Get(x.Right, el);
            else
                return x.Value;
        }

        private Node Insert(Node x, T el)
        {
            if (x == null)
                return new Node(el, 1, RED);

            int cmp = el.CompareTo(x.Value);
            if (cmp < 0)
                x.Left = Insert(x.Left, el);
            else if (cmp > 0)
                x.Right = Insert(x.Right, el);
            else
                x.Value = el;

            if (IsRed(x.Right) && !IsRed(x.Left))
                x = RotateLeft(x);
            if (IsRed(x.Left) && IsRed(x.Left.Left))
                x = RotateRight(x);
            if (IsRed(x.Left) && IsRed(x.Right))
                FlipColors(x);

            x.N = GetCount(x.Left) + GetCount(x.Right) + 1;

            return x;
        }

        private Node Min(Node x)
        {
            if (x.Left == null)
                return x;
            return Min(x.Left);
        }

        private Node Max(Node x)
        {
            if (x.Right == null)
                return x;
            return Max(x.Right);
        }

        private bool Exists(Node x, T el)
        {
            if (x == null)
                return false;
            int cmp = el.CompareTo(x.Value);
            if (cmp < 0)
                return Exists(x.Left, el);
            else if (cmp > 0)
                return Exists(x.Right, el);
            else
                return true;
        }

        private void Values(Node x, Queue<T> queue, T lo, T hi)
        {
            if (x == null)
                return;
            int cmplo = lo.CompareTo(x.Value);
            int cmphi = hi.CompareTo(x.Value);
            if (cmplo < 0)
                Values(x.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0)
                queue.Enqueue(x.Value);
            if (cmphi > 0)
                Values(x.Right, queue, lo, hi);
        }

        private bool IsRed(Node x)
        {
            if (x == null) return false;
            return x.Color == RED;
        }

        Node RotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = 1 + GetCount(h.Left) + GetCount(h.Right);
            return x;
        }

        Node RotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = 1 + GetCount(h.Left) + GetCount(h.Right);
            return x;
        }

        private void FlipColors(Node x)
        {
            x.Color = RED;
            x.Left.Color = BLACK;
            x.Right.Color = BLACK;
        }

        private int GetCount(Node x)
        {
            return x == null ? 0 : x.N;
        }

        private class Node
        {
            internal Node(T val, int n, bool color)
            {
                Value = val;
                N = n;
                Color = color;
            }

            internal T Value { get; set; }
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            internal int N { get; set; } //Number of nodes in the subtree rooted here
            internal bool Color { get; set; }

            public override string ToString()
            {
                return $"{Value} L: {(Left == null ? string.Empty : Left.Value.ToString())} R: {(Right == null ? string.Empty : Right.Value.ToString())}";
            }
        }
    }
}
