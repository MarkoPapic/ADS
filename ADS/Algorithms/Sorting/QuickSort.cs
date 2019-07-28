using System;

namespace ADS.Algorithms.Sorting
{
    public class QuickSort<T> : SortBase<T> where T : IComparable<T>
    {
        public override void Sort(T[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo)
                return;
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        private int Partition(T[] a, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;
            T pivot = a[lo];
            while (true)
            {
                //Go from left to right as long as elements are smaller than pivot (where they are supposed to be)
                while (IsLessThan(a[++i], pivot))
                    if (i == hi) //Pivot is the maximum of the unprocessed elements
                        break;
                //Go from right to left as long as elements are larger than pivot (where they are supposed to be)
                while (IsLessThan(pivot, a[--j]))
                    if (j == lo) //Pivot is the minimum of the unprocessed elements
                        break;
                if (i >= j) //We reached the end of partitioning
                    break;
                //If we reached this line, one of the 2 scenarios happened
                //Scenario 1: break hit in nested while loops, which means pivot is the minimum or maximum element of the array.
                //In this scenario, i == j. Swap will do nothing.
                //Scenario 2: Loop condition returned false for both nested loops.
                //In this scenario, a[i] is larger (or equal) than pivot and a[j] is smaller (or equal) than pivot. We just swap them.
                Swap(a, i, j);
            }
            //All the elements ordered so the ones smaller than pivot are left from j, and ones larger than pivot are right from j
            Swap(a, lo, j); //Move the pivot to its original place (pivot is on index lo initially, j is where pivot is supposed to be)
            return j;
        }
    }
}
