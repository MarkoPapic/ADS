using System;
using Xunit;

namespace ADS.DataStructures.Tests.DynamicArray
{
    public class DynamicArray_RemoveLast
    {
        [Fact]
        public void EmptyArray_ExceptionThrown() {
            //Arrange
            DynamicArray<int> arr = new DynamicArray<int>();

            //Act
            Action act = () => arr.RemoveLast();

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_LastElementReturned() {
            //Arrange
            DynamicArray<int> arr = new DynamicArray<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            //Act
            int el = arr.RemoveLast();

            //Assert
            Assert.Equal(3, el);
        }

        [Fact]
        public void HappyPath_LengthUpdated() {
            //Arrange
            DynamicArray<int> arr = new DynamicArray<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);

            //Act
            int el = arr.RemoveLast();

            //Assert
            Assert.Equal(2, arr.Length);
        }
    }
}
