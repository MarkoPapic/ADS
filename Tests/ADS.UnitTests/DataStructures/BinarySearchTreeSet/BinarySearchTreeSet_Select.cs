using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Select
    {
        [Fact]
        public void CorrectKeyReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act & Assert
            var sortedElements = elements.OrderBy(x => x).ToArray();
            for (int i = 0; i < sortedElements.Length; i++)
            {
                var currentElement = sortedElements[i];
                int selectedElement = bst.Select(i);
                Assert.Equal(currentElement, selectedElement);
            }
        }
    }
}
