using ADS.Algorithms.Sorting;
using System;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Algorithms.Sorting
{
    public class QuickSort_Sort
    {
        [Fact]
        public void HappyPath_Sorted()
        {
            //Arrange
            int[] elements = { 2, 50, -4, 194, -3004, 2890, 67, 68, 900, 350, -400, 648, 120, 29 };
            QuickSort<int> qs = new QuickSort<int>();

            //Act
            qs.Sort(elements);

            //Assert
            int[] sortedElements = { -3004, -400, -4, 2, 29, 50, 67, 68, 120, 194, 350, 648, 900, 2890 };
            Assert.True(sortedElements.SequenceEqual(elements));
        }

        [Fact]
        public void FirstMin_Sorted()
        {
            //Arrange
            int[] elements = { -3004, 2, 50, -4, 194, 2890, 67, 68, 900, 350, -400, 648, 120, 29 };
            QuickSort<int> qs = new QuickSort<int>();

            //Act
            qs.Sort(elements);

            //Assert
            int[] sortedElements = { -3004, -400, -4, 2, 29, 50, 67, 68, 120, 194, 350, 648, 900, 2890 };
            Assert.True(sortedElements.SequenceEqual(elements));
        }

        [Fact]
        public void FirstMax_Sorted()
        {
            //Arrange
            int[] elements = { 2890, 2, 50, -4, 194, -3004, 67, 68, 900, 350, -400, 648, 120, 29 };
            QuickSort<int> qs = new QuickSort<int>();

            //Act
            qs.Sort(elements);

            //Assert
            int[] sortedElements = { -3004, -400, -4, 2, 29, 50, 67, 68, 120, 194, 350, 648, 900, 2890 };
            Assert.True(sortedElements.SequenceEqual(elements));
        }
    }
}
