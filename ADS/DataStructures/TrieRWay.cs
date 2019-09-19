using ADS.Algorithms.Strings;
using System;

namespace ADS.DataStructures
{
    /// <summary>
    /// R-way trie that works with the keys that consists of English lowercase letters (a-z).
    /// </summary>
    /// <typeparam name="T">Elements type.</typeparam>
    public class TrieRWay<T>
    {
        private readonly int R;
        private Node root;

        private readonly IAlphabet alphabet;

        public TrieRWay(IAlphabet alphabet)
        {
            this.alphabet = alphabet;
            this.R = alphabet.R;
        }

        public void Insert(string key, T val)
        {
            root = Insert(root, key, val, 0);
        }

        public T Get(string key)
        {
            Node x = Get(root, key, 0);
            if (x == null)
                throw new InvalidOperationException("No value with the given rank exists in the collection.");
            return x.Value;
        }

        public bool ContainsKey(string key)
        {
            Node x = Get(root, key, 0);
            return x != null;
        }

        private Node Insert(Node x, string key, T val, int d)
        {
            if (x == null)
                x = new Node(R);
            if (d == key.Length)
            {
                x.Value = val;
                return x;
            }
            char c = key[d];
            int i = alphabet.ToIndex(c);
            x.Next[i] = Insert(x.Next[i], key, val, d + 1);
            return x;
        }

        private Node Get(Node x, string key, int d)
        {
            if (x == null)
                return null;
            if (d == key.Length)
                return x;
            char c = key[d];
            int i = alphabet.ToIndex(c);
            return Get(x.Next[i], key, d + 1);
        }

        private class Node
        {
            public Node(int r)
            {
                Next = new Node[r];
            }

            internal T Value { get; set; }
            internal Node[] Next { get; set; }
        }
    }
}
