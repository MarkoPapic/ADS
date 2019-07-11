using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Ceiling
    {
        [Fact]
        public void KeyDoesntExist_CeilingReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            int referentKey = 38;
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);

            //Act
            int ceilingKey = bst.Ceiling(referentKey);

            //Assert
            int actualCeiling = elements.Select(x => x.Item1).Where(x => x >= referentKey).Min();
            Assert.Equal(actualCeiling, ceilingKey);
        }

        [Fact]
        public void KeyExists_KeyReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            int referentKey = 36;
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);

            //Act
            int ceilingKey = bst.Ceiling(referentKey);

            //Assert
            Assert.Equal(referentKey, ceilingKey);
        }
    }
}
