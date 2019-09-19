using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.RedBlackBstSet
{
    public class RedBlackBstSet_Max
    {
        [Fact]
        public void MaxReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            RedBlackBstSet<int> bst = new RedBlackBstSet<int>();
            foreach (int el in elements)
                bst.Insert(el);

            //Act
            int maxEl = bst.Max();

            //Assert
            int actualMax = elements.Max();
            Assert.Equal(actualMax, maxEl);
        }
    }
}
