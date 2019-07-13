using System;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Get
    {
        [Fact]
        public void NoKey_ExceptionThrown()
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
            Action act = () => bst.Get(85);

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_ElementReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();

            //Act
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
            }

            //Assert
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                string foundEl = bst.Get(currentEl.Item1);
                Assert.Equal(currentEl.Item2, foundEl);
            }
        }
    }
}
