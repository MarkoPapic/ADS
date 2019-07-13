using System;
using Xunit;

namespace ADS.DataStructures.UnitTests.DynamicArray
{
    public class DynamicArray_Indexer
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(56)]
        [InlineData(100)]
        public void IndexTooLarge_ExceptionThrown(int value) {
            //Arrange
            DynamicArray<int> arr = new DynamicArray<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            //Act
            Action act = () => { int el = arr[value]; };

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        [InlineData(-56)]
        [InlineData(-100)]
        public void IndexTooSmall_ExceptionThrown(int value)
        {
            //Arrange
            DynamicArray<int> arr = new DynamicArray<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            //Act
            Action act = () => { int el = arr[value]; };

            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }
    }
}
