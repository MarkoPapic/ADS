using ADS.Algorithms;
using Xunit;

namespace ADS.UnitTests.Algorithms.Graphs
{
    public class MaximumSubarrayKadane_FindIndexes
    {
        [Fact]
        public void Test()
        {
            //Arrange
            (int, int) expectedIndexes = (5, 10);
            int[] a = new int[] { 2, 5, -1, 4, -30, 3, 2, 6, -2, 8, 15, -6, 1 };

            //Act
            (int, int) indexes = MaximumSubarrayKadane.FindIndexes(a);

            //Assert
            Assert.Equal(expectedIndexes, indexes);
        }
    }
}
