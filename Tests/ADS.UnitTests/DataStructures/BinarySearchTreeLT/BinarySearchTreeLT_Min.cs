using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Min
    {
        [Fact]
        public void MinReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            foreach (var element in elements)
                bst.Insert(element.Item1, element.Item2);

            //Act
            int minKey = bst.Min();

            //Assert
            int actualMin = elements.Select(x => x.Item1).Min();
            Assert.Equal(actualMin, minKey);
        }
    }
}
