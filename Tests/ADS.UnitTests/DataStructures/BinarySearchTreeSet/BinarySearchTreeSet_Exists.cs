using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Exists
    {
        [Fact]
        public void Test()
        {
            //Arrange
            int[] nonExistingElements = new int[] { 2, -14, 85 };
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act & Assert
            foreach (var el in elements)
            {
                bool exists = bst.Exists(el);
                Assert.True(exists);
            }

            foreach (int nonExistingKey in nonExistingElements)
            {
                bool exists = bst.Exists(nonExistingKey);
                Assert.False(exists);
            }
        }
    }
}
