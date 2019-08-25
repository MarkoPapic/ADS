using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.DynamicConnectivity
{
    public class WeightedQuickUnion : UnionFind
    {
        // size of component for roots
        private int[] size;

        public WeightedQuickUnion(int n) : base(n)
        {
            size = new int[n];
            for (int i = 0; i < n; i++)
                size[i] = 1;
        }

        public override int Find(int p)
        {
            while (p != id[p])
                p = id[p];
            return p;
        }

        public override void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i == j)
                return;

            // Make smaller root point to larger one.
            if (size[i] < size[j])
            {
                id[i] = j;
                size[j] += size[i];
            }
            else
            {
                id[j] = i;
                size[i] += size[j];
            }
            _count--;
        }
    }
}
