using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Strings
{
    public class SubstringSearchBoyerMoore
    {
        private readonly IAlphabet alphabet;
        private readonly string pat;
        private readonly int[] right;

        public SubstringSearchBoyerMoore(string pat, IAlphabet alphabet)
        {
            this.pat = pat;
            this.alphabet = alphabet;
            int M = pat.Length;
            int R = alphabet.R;
            right = new int[R];
            for (int r = 0; r < R; r++)
                right[r] = -1;
            for (int j = 0; j < M; j++)
                right[alphabet.ToIndex(pat[j])] = j;
        }

        public int Search(string s)
        {
            int N = s.Length;
            int M = pat.Length;
            int skip;
            for (int i = 0; i <= N - M; i += skip)
            {
                skip = 0;
                for (int j = M - 1; j >= 0; j--)
                {
                    if (pat[j] != s[i + j])
                    {
                        skip = j - right[alphabet.ToIndex(s[i + j])];
                        if (skip < 1) skip = 1;
                        break;
                    }
                }
                if (skip == 0) return i; // found.
            }
            return -1; // not found
        }
    }
}
