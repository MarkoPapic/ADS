using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Insert
    {
        [Fact]
        public void ElementInserted()
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

        [Fact]
        public void NoDuplicates()
        {
            //Arrange
            int duplicateKey = 24;
            string newValue = "el24New";
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (duplicateKey, "el24"), (561, "el561"), (-300, "elm300"), (duplicateKey, newValue), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();

            //Act
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
            }

            //Assert
            string foundEl = bst.Get(duplicateKey);
            var allKeys = bst.Keys();
            var matchingKeys = allKeys.Where(x => x == duplicateKey);
            Assert.Equal(newValue, foundEl);
            Assert.Single(matchingKeys);
        }

        [Fact]
        public void CountUpdated()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();

            //Act & Assert
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
                Assert.Equal(i + 1, bst.Count);
            }
        }
    }
}
