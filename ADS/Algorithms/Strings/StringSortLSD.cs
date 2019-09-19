using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Strings
{
    public class StringSortLSD
    {
        private readonly IAlphabet alphabet;

        public StringSortLSD(IAlphabet alphabet)
        {
            this.alphabet = alphabet;
        }

        public void Sort(string[] a, int w)
        {
            string[] aux = new string[a.Length];

            for (int d = w - 1; d >= 0; d--)
            {
                // Sort by key-indexed counting on dth char

                // Compute frequency count
                int[] count = new int[alphabet.R + 1];
                for (int i = 0; i < a.Length; i++) {
                    int charIndex = alphabet.ToIndex(a[i][d]);
                    count[charIndex + 1]++; }

                // Transform counts to indices
                for (int r = 0; r < alphabet.R; r++)
                    count[r + 1] += count[r];

                // Distribute
                for (int i = 0; i < a.Length; i++)
                {
                    int charIndex = alphabet.ToIndex(a[i][d]);
                    aux[count[charIndex]++] = a[i];
                }

                // Copy back
                for (int i = 0; i < a.Length; i++)
                    a[i] = aux[i];
            }
        }
    }
}
