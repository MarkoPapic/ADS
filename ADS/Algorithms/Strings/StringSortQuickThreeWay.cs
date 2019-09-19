using System;

namespace ADS.Algorithms.Strings
{
    public static class StringSortQuickThreeWay
    {
        public static void Sort(string[] a)
        {
            Sort(a, 0, a.Length - 1, 0);
        }

        private static void Sort(string[] a, int lo, int hi, int d)
        {
            if (hi <= lo) return;
            int lt = lo, gt = hi;
            int v = charAt(a[lo], d);
            int i = lo + 1;
            while (i <= gt)
            {
                int t = charAt(a[i], d);
                if (t < v) Swap(a, lt++, i++);
                else if (t > v) Swap(a, i, gt--);
                else i++;
            }
            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]
            Sort(a, lo, lt - 1, d);
            if (v >= 0) Sort(a, lt, gt, d + 1);
            Sort(a, gt + 1, hi, d);
        }

        private static int charAt(string s, int d) => d < s.Length ? s[d] : -1;

        private static void Swap(string[] a, int i, int j)
        {
            string t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
