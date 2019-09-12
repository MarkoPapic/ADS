using System;

namespace ADS.Algorithms.Strings
{
    public class StringSortMSD
    {
        private const int M = 15; // cutoff for small subarrays
        private string[] aux;
        private readonly IAlphabet alphabet;

        public StringSortMSD(IAlphabet alphabet)
        {
            this.alphabet = alphabet;
        }

        public void Sort(string[] a)
        {
            aux = new string[a.Length];
            Sort(a, 0, a.Length - 1, 0);
        }

        // Sort from a[lo] to a[hi], starting at the dth character.
        private void Sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo + M)
            {
                InsertionSort(a, lo, hi, d); return;
            }
            
            // Compute frequency counts.
            int[] count = new int[alphabet.R + 2];
            for (int i = lo; i <= hi; i++)
                count[CharAt(a[i], d) + 2]++;

            // Transform counts to indices.
            for (int r = 0; r < alphabet.R + 1; r++)
                count[r + 1] += count[r];

            // Distribute.
            for (int i = lo; i <= hi; i++)
                aux[count[CharAt(a[i], d) + 1]++] = a[i];

            // Copy back.
            for (int i = lo; i <= hi; i++)
                a[i] = aux[i - lo];

            // Recursively sort for each character value.
            for (int r = 0; r < alphabet.R; r++)
                Sort(a, lo + count[r], lo + count[r + 1] - 1, d + 1);
        }

        private int CharAt(string s, int d) => d < s.Length ? s[d] : -1;

        // Sort from a[lo] to a[hi], starting at the dth character.
        private void InsertionSort(string[] a, int lo, int hi, int d)
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && Less(a[j], a[j - 1], d); j--)
                    Swap(a, j, j - 1);
        }
        private bool Less(string v, string w, int d)
        {
            return v.Substring(d).CompareTo(w.Substring(d)) < 0;
        }

        private void Swap(string[] a, int i, int j)
        {
            string t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
