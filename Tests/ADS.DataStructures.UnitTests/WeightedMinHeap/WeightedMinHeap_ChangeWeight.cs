using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.WeightedMinHeap
{
    public class WeightedMinHeap_ChangeWeight
    {
        [Fact]
        public void DecreaseWeight_UpdatedCorrectly()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();
            int elToBeChanged = 80;

            //Act
            for (int i = 0; i < elements.Length; i++)
                weightedMinHeap.Insert(elements[i].Item1, elements[i].Item2);
            weightedMinHeap.ChangeWeight(elToBeChanged, 3);

            //Assert
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            int changedElement = weightedMinHeap.PopMin();
            Assert.Equal(elToBeChanged, changedElement);
        }

        [Fact]
        public void IncreaseWeight_UpdatedCorrectly()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();
            int elToBeChanged = 5;

            //Act
            for (int i = 0; i < elements.Length; i++)
                weightedMinHeap.Insert(elements[i].Item1, elements[i].Item2);
            weightedMinHeap.ChangeWeight(elToBeChanged, 18);

            //Assert
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            int changedElement = weightedMinHeap.PopMin();
            Assert.Equal(elToBeChanged, changedElement);
        }

        [Fact]
        public void IncreaseWeightToMax_UpdatedCorrectly()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();
            int elToBeChanged = -2;

            //Act
            for (int i = 0; i < elements.Length; i++)
                weightedMinHeap.Insert(elements[i].Item1, elements[i].Item2);
            weightedMinHeap.ChangeWeight(elToBeChanged, 1000);

            //Assert
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            _ = weightedMinHeap.PopMin();
            int changedElement = weightedMinHeap.PopMin();
            Assert.Equal(elToBeChanged, changedElement);
            Assert.Equal(0, weightedMinHeap.Count);
        }

        [Fact]
        public void DecreaseWeightToMin_UpdatedCorrectly()
        {
            //Arrange
            (int, double)[] elements = { (5, 2), (-2, 4), (1, 60), (6, 100), (7, -2), (80, 20), (-481, 15) };
            WeightedMinHeap<int, double> weightedMinHeap = new WeightedMinHeap<int, double>();
            int elToBeChanged = 80;

            //Act
            for (int i = 0; i < elements.Length; i++)
                weightedMinHeap.Insert(elements[i].Item1, elements[i].Item2);
            weightedMinHeap.ChangeWeight(elToBeChanged, -500);

            //Assert
            int changedElement = weightedMinHeap.PopMin();
            Assert.Equal(elToBeChanged, changedElement);
        }
    }
}
