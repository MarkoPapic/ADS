using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms
{
    /// <summary>
    /// Finds the maximum sub-array of an array
    /// </summary>
    public static class MaximumSubarrayKadane
    {
        public static (int, int) FindIndexes(int[] a)
        {
            int currentSum = 0;
            int bestStart = 0;
            int currentStart = 0;
            int end = 0;
            int bestSoFar = 0;

            for (int i = 0; i < a.Length; i++)
            {
                int x = a[i];
                currentSum += x;
                bestSoFar = bestSoFar >= currentSum ? bestSoFar : currentSum;
                if (currentSum <= 0)
                {
                    currentStart = i + 1;
                    currentSum = 0;
                }
                else if (currentSum == bestSoFar)
                {
                    bestStart = currentStart;
                    end = i;
                }
            }

            //Sum is contained in bestSoFar
            return (bestStart, end);
        }
    }
}
