using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Sorting
{
    public abstract class SortBase<T> where T : IComparable<T>
    {
        public abstract void Sort(T[] a);

        protected bool IsLessThan(T v, T w)
        {
            return v.CompareTo(w) < 0;
        }

        protected void Swap(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
