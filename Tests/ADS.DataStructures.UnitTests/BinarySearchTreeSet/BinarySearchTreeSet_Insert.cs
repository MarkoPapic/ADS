using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTree_Insert
    {
        [Fact]
        public void ElementInserted()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();

            //Act
            foreach (int el in elements)
                bst.Insert(el);

            //Assert
            foreach (int el in elements)
            {
                int foundEl = bst.Get(el);
                Assert.Equal(el, foundEl);
            }
        }

        [Fact]
        public void NoDuplicates()
        {
            //Arrange
            int duplicateValue = 24;
            int[] elements = new int[] { 1, -5, duplicateValue, 561, -300, 15, 36, duplicateValue, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();

            //Act
            foreach (int el in elements)
                bst.Insert(el);

            //Assert
            var allValues = bst.Values();
            var matchingValues = allValues.Where(x => x == duplicateValue);
            Assert.Single(matchingValues);
        }

        [Fact]
        public void CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();

            //Act & Assert
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl);
                Assert.Equal(i + 1, bst.Count);
            }
        }
    }
}
