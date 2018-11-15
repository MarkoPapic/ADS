using System;
using System.Collections.Generic;
using Xunit;

namespace ADS.DataStructures.UnitTests.DynamicArray
{
    public class DynamicArray_Enumeration
    {
        [Fact]
        public void EmptyArray_NothingEnumerated() {
            //Arrange
            List<int> enumeratedElements = new List<int>();
            DynamicArray<int> array = new DynamicArray<int>();

            //Act
            foreach (int el in array)
                enumeratedElements.Add(el);

            //Assert
            Assert.Empty(enumeratedElements);
        }

        [Fact]
        public void HappyPath_ElementsEnumerated() {
            //Arrange
            List<int> elements = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            List<int> enumeratedElements = new List<int>();
            DynamicArray<int> array = new DynamicArray<int>();
            foreach (int el in elements)
                array.Add(el);

            //Act
            foreach (int el in array)
                enumeratedElements.Add(el);

            //Assert
            Assert.Equal(elements, enumeratedElements);
        }
    }
}
