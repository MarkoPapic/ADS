using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Delete
    {
        [Fact]
        public void Deleted()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act & Assert
            foreach (var element in elements)
            {
                bst.Delete(element);
                bool exists = bst.Exists(element);
                Assert.False(exists);
            }
        }

        [Fact]
        public void CountUpdated()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act & Assert
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i];
                bst.Delete(element);
                int expectedLength = elements.Length - i - 1;
                Assert.Equal(expectedLength, bst.Count);
            }
        }
    }
}
