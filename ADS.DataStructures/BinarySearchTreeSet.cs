using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures
{
    /// <summary>
    /// Set approach of binary search tree.
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class BinarySearchTreeSet<T> where T : IComparable<T>
    {
        private Node root;

        public int Count => GetCount(root);

        public T Get(T el) => Get(root, el);

        public void Insert(T el)
        {
            root = Insert(root, el);
        }

        public void Delete(T el)
        {
            root = Delete(root, el);
        }

        public bool Exists(T el)
        {
            return Exists(root, el);
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

        /// <summary>
        /// Finds the largest element less than or equal to <paramref name="el"/>.
        /// </summary>
        /// <param name="el">Referent value.</param>
        /// <returns>Largest element less than or equal to <paramref name="el"/>.</returns>
        public T Floor(T el)
        {
            Node x = Floor(root, el);
            if (x == null)
                throw new InvalidOperationException("Given value is smaller than any value in the collection.");
            return x.Value;
        }

        /// <summary>
        /// Finds the smallest element larger than or equal to <paramref name="el"/>.
        /// </summary>
        /// <param name="el">Referent value.</param>
        /// <returns>Smallest element larger than or equal to <paramref name="el"/>.</returns>
        public T Ceiling(T el)
        {
            Node x = Ceiling(root, el);
            if (x == null)
                throw new InvalidOperationException("Given value is larger than any value in the collection.");
            return x.Value;
        }

        /// <summary>
        /// Finds the value of rank <paramref name="k"/> (the value such that precisely k other values in the collection are smaller).
        /// </summary>
        /// <param name="k">Rank.</param>
        /// <returns>Value of the given rank.</returns>
        public T Select(int k)
        {
            Node x = Select(root, k);
            if (x == null)
                throw new InvalidOperationException("No value with the given rank exists in the collection.");
            return x.Value;
        }

        /// <summary>
        /// Gets the rank of the <paramref name="el"/> (number of elements that are smaller).
        /// </summary>
        /// <param name="el">Element.</param>
        /// <returns>Rank of the element.</returns>
        public int Rank(T el)
        {
            return Rank(el, root);
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
        }

        public void DeleteMax()
        {
            root = DeleteMax(root);
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

        private Node Floor(Node x, T el)
        {
            if (x == null)
                return null;
            int cmp = el.CompareTo(x.Value);
            if (cmp == 0)
                return x;
            if (cmp < 0)
                return Floor(x.Left, el);
            Node t = Floor(x.Right, el);
            return t ?? x;
        }

        private Node Ceiling(Node x, T el)
        {
            if (x == null)
                return null;
            int cmp = el.CompareTo(x.Value);
            if (cmp == 0)
                return x;
            if (cmp > 0)
                return Ceiling(x.Right, el);
            Node t = Ceiling(x.Left, el);
            return t ?? x;
        }

        private Node Select(Node x, int k)
        {
            if (x == null)
                return null;
            int t = GetCount(x.Left);
            if (t > k)
                return Select(x.Left, k);
            else if (t < k)
                return Select(x.Right, k - t - 1);
            else
                return x;
        }

        private int Rank(T el, Node x)
        {
            if (x == null)
                throw new InvalidOperationException("Element not found.");
            int cmp = el.CompareTo(x.Value);
            if (cmp < 0)
                return Rank(el, x.Left);
            else if (cmp > 0)
                return 1 + GetCount(x.Left) + Rank(el, x.Right);
            else
                return GetCount(x.Left);
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
                return new Node(el, 1);
            int cmp = el.CompareTo(x.Value);
            if (cmp < 0)
                x.Left = Insert(x.Left, el);
            else if (cmp > 0)
                x.Right = Insert(x.Right, el);
            else x.Value = el;
            x.N = GetCount(x.Left) + GetCount(x.Right) + 1;
            return x;
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null)
                return x.Right;
            x.Left = DeleteMin(x.Left);
            x.N = GetCount(x.Left) + GetCount(x.Right) + 1;
            return x;
        }

        private Node DeleteMax(Node x)
        {
            if (x.Right == null)
                return x.Left;
            x.Right = DeleteMax(x.Right);
            x.N = GetCount(x.Left) + GetCount(x.Right) + 1;
            return x;
        }

        private Node Delete(Node x, T el)
        {
            if (x == null)
                return null;
            int cmp = el.CompareTo(x.Value);
            if (cmp < 0)
                x.Left = Delete(x.Left, el);
            else if (cmp > 0)
                x.Right = Delete(x.Right, el);
            else
            {
                if (x.Right == null)
                    return x.Left;
                if (x.Left == null)
                    return x.Right;
                Node t = x;
                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }
            x.N = GetCount(x.Left) + GetCount(x.Right) + 1;
            return x;
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

        private int GetCount(Node x)
        {
            return x == null ? 0 : x.N;
        }

        [System.Diagnostics.DebuggerDisplay("{ToString()}")]
        private class Node
        {
            internal Node(T val, int n)
            {
                Value = val;
                N = n;
            }

            internal T Value { get; set; }
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            internal int N { get; set; } //Number of nodes in the subtree rooted here

            public override string ToString()
            {
                return $"{Value} L: {(Left == null ? string.Empty : Left.Value.ToString())} R: {(Right == null ? string.Empty : Right.Value.ToString())}";
            }
        }
    }
}
