using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.DynamicConnectivity
{
    public class QuickUnion : UnionFind
    {
        public QuickUnion(int n) : base(n) { }

        public override int Find(int p)
        {
            while (p != id[p]) p = id[p];
            return p;
        }

        public override void Union(int p, int q)
        {
            // Give p and q the same root.
            int pRoot = Find(p);
            int qRoot = Find(q);
            if (pRoot == qRoot) return;
            id[pRoot] = qRoot;
            _count--;
        }
    }
}
