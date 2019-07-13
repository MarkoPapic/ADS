using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Floor
    {
        [Fact]
        public void KeyDoesntExist_FloorReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            int referentKey = 49;

            //Act
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);
            int floorKey = bst.Floor(referentKey);

            //Assert
            int actualFloor = elements.Select(x => x.Item1).Where(x => x <= referentKey).Max();
            Assert.Equal(actualFloor, floorKey);
        }

        [Fact]
        public void KeyExists_KeyReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            int referentKey = 36;

            //Act
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);
            int floorKey = bst.Floor(referentKey);

            //Assert
            Assert.Equal(referentKey, floorKey);
        }
    }
}
