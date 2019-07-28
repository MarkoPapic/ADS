using System;

namespace ADS.Algorithms.Sorting
{
    public class MergeSort<T> : SortBase<T> where T : IComparable<T>
    {
        private T[] aux; //Auxiliary array for merges
        public override void Sort(T[] a)
        {
            //Allocate space just once
            aux = new T[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) //We narrowed it down to a single element
                return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid); //Sort left half
            Sort(a, mid + 1, hi); //Sort right half
            Merge(a, lo, mid, hi); //Merge results
        }

        private void Merge(T[] a, int lo, int mid, int hi)
        {
            int i = lo, j = mid + 1;

            //Copy a[lo..hi] to aux[lo..hi].
            for (int k = lo; k <= hi; k++)
                aux[k] = a[k];

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) //Left half exhausted
                    a[k] = aux[j++];
                else if (j > hi) //Right half exhausted
                    a[k] = aux[i++];
                else if (this.IsLessThan(aux[j], aux[i])) //Right smaller
                    a[k] = aux[j++];
                else //Right larger of equal
                    a[k] = aux[i++];
            }
        }
    }
}
