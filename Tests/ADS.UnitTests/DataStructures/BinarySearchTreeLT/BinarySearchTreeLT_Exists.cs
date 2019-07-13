using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Exists
    {
        [Fact]
        public void Test()
        {
            //Arrange
            int[] nonExistingKeys = new int[] { 2, -14, 85 };
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);

            //Act & Assert
            foreach (var existingElement in elements)
            {
                bool exists = bst.Exists(existingElement.Item1);
                Assert.True(exists);
            }

            foreach (int nonExistingKey in nonExistingKeys)
            {
                bool exists = bst.Exists(nonExistingKey);
                Assert.False(exists);
            }
        }
    }
}
