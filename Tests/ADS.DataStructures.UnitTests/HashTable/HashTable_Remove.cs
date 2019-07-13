using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.HashTable
{
    public class HashTable_Remove
    {
        [Fact]
        public void KeyNotPresent_KeyNotPresent()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);
            string keyToRemove = "key5";

            //Act
            bool removed = hashTable.Remove(keyToRemove);

            //Assert
            bool valuePresent = hashTable.ContainsKey(keyToRemove);
            Assert.False(removed);
            Assert.False(valuePresent);
        }

        [Fact]
        public void KeyNotPresent_CountStaysSame()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);
            string keyToRemove = "key5";

            //Act
            bool removed = hashTable.Remove(keyToRemove);

            //Assert
            Assert.False(removed);
            Assert.Equal(3, hashTable.Count);
        }

        [Fact]
        public void KeyPresent_Value()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);
            string keyToRemove = "key2";

            //Act
            bool removed = hashTable.Remove(keyToRemove);

            //Assert
            bool valuePresent = hashTable.ContainsKey(keyToRemove);
            Assert.True(removed);
            Assert.False(valuePresent);
        }

        [Fact]
        public void KeyPresent_CountDecreased()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);
            string keyToRemove = "key2";

            //Act
            bool removed = hashTable.Remove(keyToRemove);

            //Assert
            Assert.True(removed);
            Assert.Equal(2, hashTable.Count);
        }
    }
}
