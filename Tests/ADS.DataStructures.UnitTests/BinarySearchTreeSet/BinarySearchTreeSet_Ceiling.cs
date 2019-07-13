using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeSet
{
    public class BinarySearchTreeSet_Ceiling
    {
        [Fact]
        public void ElementDoesntExist_CeilingReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);
            int referentValue = 38;

            //Act
            int ceilingValue = bst.Ceiling(referentValue);

            //Assert
            int actualCeiling = elements.Where(x => x >= referentValue).Min();
            Assert.Equal(actualCeiling, ceilingValue);
        }

        [Fact]
        public void ElementExists_ElementReturned()
        {
            //Arrange
            int[] elements = new int[] { 1, -5, 24, 561, -300, 15, 36, 82, 4, 50 };
            BinarySearchTreeSet<int> bst = new BinarySearchTreeSet<int>();
            foreach (int el in elements)
                bst.Insert(el);
            int referentValue = 36;

            //Act
            int ceilingValue = bst.Ceiling(referentValue);

            //Assert
            Assert.Equal(referentValue, ceilingValue);
        }
    }
}
