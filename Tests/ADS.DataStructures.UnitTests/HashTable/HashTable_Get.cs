using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.HashTable
{
    public class HashTable_Get
    {
        [Fact]
        public void KeyDoesntExist_ExceptionThrown()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);

            //Act
            Action act = () => { int el = hashTable.Get("key4"); };

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void HappyPath_ValueReturned()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);

            //Act
            int value = hashTable.Get("key2");

            //Assert
            Assert.Equal(2, value);
        }
    }
}
