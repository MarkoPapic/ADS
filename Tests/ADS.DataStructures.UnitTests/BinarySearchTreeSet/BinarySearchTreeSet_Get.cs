using System;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Get
    {
        [Fact]
        public void NoKey_ExceptionThrown()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act
            Action act = () => bst.Get(85);

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_ElementReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Assert
            foreach (int el in elements)
            {
                int foundEl = bst.Get(el);
                Assert.Equal(el, foundEl);
            }
        }
    }
}
