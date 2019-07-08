using System.Linq;
using Xunit;

namespace ADS.DataStructures.UnitTests.WeightedMinHeap
{
    public class WeightedMinHeap_Insert
    {
        [Fact]
        public void HappyPath_MinCorrect()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();

            //Act & assert
            for (int i = 0; i < elements.Length; i++)
            {
                weightedMinHeap.Insert(elements[i].Item1, elements[i].Item2);
                int minEl = weightedMinHeap.PeekMin();
                int minFromInserted = elements.Take(i + 1).OrderBy(x => x.Item2).First().Item1;
                Assert.Equal(minFromInserted, minEl);
            }
        }

        [Fact]
        public void HappyPath_CountUpdated()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                weightedMinHeap.Insert(elements[i].Item1, elements[i].Item2);
                Assert.Equal(i + 1, weightedMinHeap.Count);
            }
        }
    }
}
