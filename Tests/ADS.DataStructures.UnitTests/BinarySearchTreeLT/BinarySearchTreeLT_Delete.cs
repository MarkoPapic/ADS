using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Delete
    {
        [Fact]
        public void Deleted()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);

            //Act & Assert
            foreach (var element in elements)
            {
                bst.Delete(element.Item1);
                bool exists = bst.Exists(element.Item1);
                Assert.False(exists);
            }
        }

        [Fact]
        public void CountUpdated()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);

            //Act & Assert
            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i];
                bst.Delete(element.Item1);
                int expectedLength = elements.Length - i - 1;
                Assert.Equal(expectedLength, bst.Count);
            }
        }
    }
}
