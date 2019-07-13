using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Keys
    {
        [Fact]
        public void NoArguments_AllReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
            }

            //Act
            IEnumerable<int> keys = bst.Keys();

            //Assert
            int[] expectedKeys = elements.OrderBy(x => x.Item1).Select(x => x.Item1).ToArray();
            int[] keysArray = keys.ToArray();
            Assert.True(expectedKeys.SequenceEqual(keysArray));
        }

        [Fact]
        public void ArgumentsOutOfRange_AllReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
            }

            //Act
            IEnumerable<int> keys = bst.Keys(-1000, 1000);

            //Assert
            int[] expectedKeys = elements.Select(x => x.Item1).OrderBy(x =>x).ToArray();
            int[] keysArray = keys.ToArray();
            Assert.True(expectedKeys.SequenceEqual(keysArray));
        }

        [Fact]
        public void ArgumentsInRange_RangeReturned()
        {
            //Arrange
            int lo = 1;
            int hi = 100;
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
            }

            //Act
            IEnumerable<int> keys = bst.Keys(lo, hi);

            //Assert
            int[] expectedKeys = elements.Select(x => x.Item1).Where(x => x >= lo && x <= hi).OrderBy(x => x).ToArray();
            int[] keysArray = keys.ToArray();
            Assert.True(expectedKeys.SequenceEqual(keysArray));
        }
    }
}
