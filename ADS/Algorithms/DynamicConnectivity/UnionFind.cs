using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.DynamicConnectivity
{
    public abstract class UnionFind
    {
        protected int[] id;
        protected int _count;

        /// <summary>
        /// Number of connected components.
        /// </summary>
        public int Count => _count;

        public UnionFind(int n)
        {
            id = new int[n];
            for (int i = 0; i < n; i++)
                id[i] = i;
            _count = n;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// Gets a component id for p.
        /// </summary>
        /// <param name="p">Object id.</param>
        /// <returns>Component id for p.</returns>
        public abstract int Find(int p);

        /// <summary>
        /// Add connection between p and q.
        /// </summary>
        /// <param name="p">First object id.</param>
        /// <param name="q">Second object id.</param>
        public abstract void Union(int p, int q);
    }
}
