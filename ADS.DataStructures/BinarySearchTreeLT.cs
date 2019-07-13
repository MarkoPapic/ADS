using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures
{
    /// <summary>
    /// Lookup table approach of binary search tree.
    /// </summary>
    /// <typeparam name="TKey">Key type.</typeparam>
    /// <typeparam name="TValue">Value type.</typeparam>
    public class BinarySearchTreeLT<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node root;

        public int Count => GetCount(root);

        public TValue Get(TKey key)
        {
            return Get(root, key);
        }

        public void Insert(TKey key, TValue val)
        {
            root = Insert(root, key, val);
        }

        public void Delete(TKey key)
        {
            root = Delete(root, key);
        }

        public bool Exists(TKey key)
        {
            return Exists(root, key);
        }

        /// <summary>
        /// Finds the key with the minimum value.
        /// </summary>
        /// <returns>Key that has the minimum value.</returns>
        public TKey Min()
        {
            return Min(root).Key;
        }

        /// <summary>
        /// Finds the key with the maximum value.
        /// </summary>
        /// <returns>Key that has the maximum value.</returns>
        public TKey Max()
        {
            return Max(root).Key;
        }

        /// <summary>
        /// Finds the largest key less than or equal to <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Referent value.</param>
        /// <returns>Largest key less than or equal to <paramref name="key"/>.</returns>
        public TKey Floor(TKey key)
        {
            Node x = Floor(root, key);
            if (x == null)
                throw new InvalidOperationException("Given key is smaller than any key in the collection.");
            return x.Key;
        }

        /// <summary>
        /// Finds the smallest key larger than or equal to <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Referent value.</param>
        /// <returns>Smallest key larger than or equal to <paramref name="key"/>.</returns>
        public TKey Ceiling(TKey key)
        {
            Node x = Ceiling(root, key);
            if (x == null)
                throw new InvalidOperationException("Given key is larger than any key in the collection.");
            return x.Key;
        }

        /// <summary>
        /// Finds the key of rank <paramref name="k"/> (the key such that precisely k other keys in the collection are smaller).
        /// </summary>
        /// <param name="k">Rank of the key.</param>
        /// <returns>Key of the given rank.</returns>
        public TKey Select(int k)
        {
            Node x = Select(root, k);
            if (x == null)
                throw new InvalidOperationException("No key with the given rank exists in the collection.");
            return x.Key;
        }

        /// <summary>
        /// Gets the rank of the <paramref name="key"/> (number of keys that are smaller).
        /// </summary>
        /// <param name="key">Key.</param>
        /// <returns>Rank of the key.</returns>
        public int Rank(TKey key)
        {
            return Rank(key, root);
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
        }

        public void DeleteMax()
        {
            root = DeleteMax(root);
        }

        public IEnumerable<TKey> Keys()
        {
            return Keys(Min(), Max());
        }

        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            Queue<TKey> queue = new Queue<TKey>();
            Keys(root, queue, lo, hi);
            return queue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Print(root, 1, sb);
            return sb.ToString();
        }

        private int GetCount(Node x)
        {
            return x == null ? 0 : x.N;
        }

        private TValue Get(Node x, TKey key)
        {
            if (x == null)
                throw new InvalidOperationException("Key doesn't exist.");
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Get(x.Left, key);
            else if (cmp > 0)
                return Get(x.Right, key);
            else
                return x.Value;
        }

        private Node Insert(Node x, TKey key, TValue val)
        {
            if (x == null)
                return new Node(key, val, 1);
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Insert(x.Left, key, val);
            else if (cmp > 0)
                x.Right = Insert(x.Right, key, val);
            else x.Value = val;
            x.N = GetCount(x.Left) + GetCount(x.Right) + 1;
            return x;
        }

        private bool Exists(Node x, TKey key)
        {
            if (x == null)
                return false;
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Exists(x.Left, key);
            else if (cmp > 0)
                return Exists(x.Right, key);
            else
                return true;
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

        private Node Floor(Node x, TKey key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;
            if (cmp < 0)
                return Floor(x.Left, key);
            Node t = Floor(x.Right, key);
            return t ?? x;
        }

        private Node Ceiling(Node x, TKey key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
                return x;
            if (cmp > 0)
                return Ceiling(x.Right, key);
            Node t = Ceiling(x.Left, key);
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

        private int Rank(TKey key, Node x)
        {
            if (x == null)
                throw new InvalidOperationException("Key not found.");
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Rank(key, x.Left);
            else if (cmp > 0)
                return 1 + GetCount(x.Left) + Rank(key, x.Right);
            else
                return GetCount(x.Left);
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

        private Node Delete(Node x, TKey key)
        {
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                x.Left = Delete(x.Left, key);
            else if (cmp > 0)
                x.Right = Delete(x.Right, key);
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

        private void Keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null)
                return;
            int cmplo = lo.CompareTo(x.Key);
            int cmphi = hi.CompareTo(x.Key);
            if (cmplo < 0)
                Keys(x.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0)
                queue.Enqueue(x.Key);
            if (cmphi > 0)
                Keys(x.Right, queue, lo, hi);
        }

        private void Print(Node x, int level, StringBuilder sb)
        {
            throw new NotImplementedException();
        }

        [System.Diagnostics.DebuggerDisplay("{ToString()}")]
        private class Node
        {
            internal Node(TKey key, TValue val, int n)
            {
                Key = key;
                Value = val;
                N = n;
            }

            internal TKey Key { get; }
            internal TValue Value { get; set; }
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            internal int N { get; set; } //Number of nodes in the subtree rooted here

            public override string ToString()
            {
                return $"({Key},{Value}) L: {(Left == null ? string.Empty : Left.Key.ToString())} R: {(Right == null ? string.Empty : Right.Key.ToString())}";
            }
        }
    }
}
