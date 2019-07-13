using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.HashTable
{
    public class HashTable_ContainsKey
    {
        [Fact]
        public void KeyPresent_TrueReturned()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);

            //Act
            bool containsKey = hashTable.ContainsKey("key2");

            //Assert
            Assert.True(containsKey);
        }

        [Fact]
        public void KeyNotPresent_FalseReturned()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);

            //Act
            bool containsKey = hashTable.ContainsKey("key5");

            //Assert
            Assert.False(containsKey);
        }
    }
}
