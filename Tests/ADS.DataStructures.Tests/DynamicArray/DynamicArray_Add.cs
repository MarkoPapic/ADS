using System;
using Xunit;

namespace ADS.DataStructures.Tests.DynamicArray
{
    public class DynamicArray_Add
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(-1)]
        [InlineData(2)]
        [InlineData(150)]
        [InlineData(-23)]
        [InlineData(600)]
        public void HappyPath_ElementAdded(int value) {
            //Arrrange
            DynamicArray<int> arr = new DynamicArray<int>();

            //Act
            arr.Add(value);

            //Assert
            Assert.Equal(value, arr[arr.Length - 1]);
        }

        [Fact]
        public void HappyPath_LengthUpdated() {
            //Arrange
            int[] elementsToAdd = new int[3] { 100, -45, 256 };
            DynamicArray<int> arr = new DynamicArray<int>();

            //Act
            foreach (int el in elementsToAdd)
                arr.Add(el);

            //Assert
            Assert.Equal(elementsToAdd.Length, arr.Length);
        }
    }
}
