using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Min
    {
        [Fact]
        public void MaxReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act
            int maxEl = bst.Min();

            //Assert
            int actualMax = elements.Min();
            Assert.Equal(actualMax, maxEl);
        }
    }
}
