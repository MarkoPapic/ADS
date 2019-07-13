using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.BinarySearchTreeLT
{
    public class BinarySearchTreeLT_Rank
    {
        [Fact]
        public void CorrectRankReturned()
        {
            //Arrange
            (int, string)[] elements = new (int, string)[] { (1, "el1"), (-5, "elm5"), (24, "el24"), (561, "el561"), (-300, "elm300"), (15, "el15"), (36, "el36"), (82, "el82"), (4, "el4"), (50, "el50") };
            BinarySearchTreeLT<int, string> bst = new BinarySearchTreeLT<int, string>();
            for (int i = 0; i < elements.Length; i++)
            {
                var currentEl = elements[i];
                bst.Insert(currentEl.Item1, currentEl.Item2);
            }

            //Act & Assert
            var sortedElements = elements.OrderBy(x => x.Item1).ToArray();
            for (int i = 0; i < sortedElements.Length; i++)
            {
                var currentElement = sortedElements[i];
                int rank = bst.Rank(currentElement.Item1);
                Assert.Equal(i, rank);
            }
        }
    }
}
