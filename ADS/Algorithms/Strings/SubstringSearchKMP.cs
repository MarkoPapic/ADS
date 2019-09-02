using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Strings
{
    /// <summary>
    /// Substring search algorithm using Knuth-Morris-Pratt algorithm.
    /// </summary>
    public class SubstringSearchKMP
    {
        private readonly IAlphabet alphabet;
        private readonly string pat;
        private readonly int[,] dfa;

        public SubstringSearchKMP(string pat, IAlphabet alphabet)
        {
            this.pat = pat;
            this.alphabet = alphabet;
            int M = pat.Length;
            int R = alphabet.R;
            dfa = new int[R, M];

            dfa[alphabet.ToIndex(pat[0]), 0] = 1;
            for (int X = 0, j = 1; j < M; j++)
            {
                for (int r = 0; r < R; r++)
                    dfa[r, j] = dfa[r, X];
                dfa[alphabet.ToIndex(pat[j]), j] = j + 1;
                X = dfa[alphabet.ToIndex(pat[j]), X];
            }
        }

        public int Search(string s)
        {
            int i, j, N = s.Length, M = pat.Length;
            for (i = 0, j = 0; i < N && j < M; i++)
                j = dfa[alphabet.ToIndex(s[i]), j];
            return j == M ? i - M : -1;
        }
    }
}
