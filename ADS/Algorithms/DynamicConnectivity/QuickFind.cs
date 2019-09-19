using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.DynamicConnectivity
{
    public class QuickFind : UnionFind
    {
        public QuickFind(int n) : base(n) { }

        public override int Find(int p)
        {
            return id[p];
        }

        public override void Union(int p, int q)
        {
            // Put p and q into the same component.
            int pID = Find(p);
            int qID = Find(q);

            // Nothing to do if p and q are already in the same component.
            if (pID == qID) return;

            // Rename p’s component to q’s name.
            for (int i = 0; i < id.Length; i++)
                if (id[i] == pID) id[i] = qID;
            _count--;
        }
    }
}
