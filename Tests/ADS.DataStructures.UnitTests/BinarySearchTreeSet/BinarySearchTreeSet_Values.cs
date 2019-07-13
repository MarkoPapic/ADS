using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Values
    {
        [Fact]
        public void NoArguments_AllReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act
            IEnumerable<int> values = bst.Values();

            //Assert
            int[] expectedValues = elements.OrderBy(x => x).ToArray();
            int[] valuesArray = values.ToArray();
            Assert.True(expectedValues.SequenceEqual(valuesArray));
        }

        [Fact]
        public void ArgumentsOutOfRange_AllReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act
            IEnumerable<int> values = bst.Values(-1000, 1000);

            //Assert
            int[] expectedValues = elements.OrderBy(x => x).ToArray();
            int[] valuesArray = values.ToArray();
            Assert.True(expectedValues.SequenceEqual(valuesArray));
        }

        [Fact]
        public void ArgumentsInRange_RangeReturned()
        {
            //Arrange
            int lo = 1;
            int hi = 100;
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act
            IEnumerable<int> values = bst.Values(lo, hi);

            //Assert
            int[] expectedValues = elements.Where(x => x >= lo && x <= hi).OrderBy(x => x).ToArray();
            int[] valuesArray = values.ToArray();
            Assert.True(expectedValues.SequenceEqual(valuesArray));
        }
    }
}
