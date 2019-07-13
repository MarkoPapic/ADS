using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.DataStructures.Contracts
{
    public interface IGraph
    {
        int V { get; }
        void AddEdge(int v, int w);
        IEnumerable<int> Adj(int v);
    }
}
