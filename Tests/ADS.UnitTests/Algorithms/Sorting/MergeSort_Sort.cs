﻿using ADS.Algorithms.Sorting;
using System;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Algorithms.Sorting
{
    public class MergeSort_Sort
    {
        [Fact]
        public void Test()
        {
            //Arrange
            int[] elements = { 2, 50, -4, 194, -3004, 2890, 67, 68, 900, 350, -400, 648, 120, 29 };
            MergeSort<int> ms = new MergeSort<int>();

            //Act
            ms.Sort(elements);

            //Assert
            int[] sortedElements = { -3004, -400, -4, 2, 29, 50, 67, 68, 120, 194, 350, 648, 900, 2890 };
            Assert.True(sortedElements.SequenceEqual(elements));
        }
    }
}
