using ADS.Algorithms.Graphs;
using ADS.DataStructures;
using System.Collections.Generic;

namespace ADS.Algorithms.Strings
{
    public class Regex
    {
        private readonly char[] re; // match transitions
        private readonly Digraph G; // epsilon transitions
        private readonly int M; // number of states
        
        public Regex(string regexp)
        {
            DataStructures.Stack<int> ops = new DataStructures.Stack<int>();
            re = regexp.ToCharArray();
            M = re.Length;
            G = new Digraph(M + 1);

            for (int i = 0; i < M; i++)
            {
                int lp = i;
                if (re[i] == '(' || re[i] == '|')
                    ops.Push(i);
                else if (re[i] == ')')
                {
                    int or = ops.Pop();
                    if (re[or] == '|')
                    {
                        lp = ops.Pop();
                        G.AddEdge(lp, or + 1);
                        G.AddEdge(or, i);
                    }
                    else lp = or;
                }
                if (i < M-1 && re[i+1] == '*') // lookahead
                {
                    G.AddEdge(lp, i + 1);
                    G.AddEdge(i + 1, lp);
                }
                if (re[i] == '(' || re[i] == '*' || re[i] == ')')
                    G.AddEdge(i, i + 1);
            }
        }

        public bool Matches(string txt)
        {
            LinkedList<int> pc = new LinkedList<int>();
            ReachabilityDfs dfs = new ReachabilityDfs(G, 0);
            for (int v = 0; v < G.V; v++)
            {
                if (dfs.Reachable(v))
                    pc.AddLast(v);
            }
            for (int i = 0; i < txt.Length; i++)
            {
                LinkedList<int> match = new LinkedList<int>();
                foreach (int v in pc)
                {
                    if (v < M)
                    {
                        if (re[v] == txt[i] || re[v] == '.')
                            match.AddLast(v + 1);
                    }
                }
                pc = new LinkedList<int>();
                dfs = new ReachabilityDfs(G, match);
                for (int v = 0; v < G.V; v++)
                {
                    if (dfs.Reachable(v))
                        pc.AddLast(v);
                }
            }
            foreach (int v in pc)
            {
                if (v == M)
                    return true;
            }
            return false;
        }
    }
}
