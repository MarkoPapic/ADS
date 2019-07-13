using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.DataStructures.UnitTests.HashTable
{
    public class HashTable_Add
    {
        [Fact]
        public void NewKey_Added()
        {
            //Arrange
            (string, int)[] elements = new (string, int)[] { ("key1", 1), ("key2", -5), ("key3", 24), ("key4", 561), ("key5", -300), ("key6", 15), ("key7", 36), ("key8", 82), ("key9", 4), ("key10", 50) };
            HashTable<string, int> hashTable = new HashTable<string, int>();

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                hashTable.Add(elements[i].Item1, elements[i].Item2);
                int foundValue = hashTable.Get(elements[i].Item1);
                Assert.Equal(elements[i].Item2, foundValue);
            }
        }

        [Fact]
        public void NewKey_CountUpdated()
        {
            //Arrange
            (string, int)[] elements = new (string, int)[] { ("key1", 1), ("key2", -5), ("key3", 24), ("key4", 561), ("key5", -300), ("key6", 15), ("key7", 36), ("key8", 82), ("key9", 4), ("key10", 50) };
            HashTable<string, int> hashTable = new HashTable<string, int>();

            //Act && assert
            for (int i = 0; i < elements.Length; i++)
            {
                hashTable.Add(elements[i].Item1, elements[i].Item2);
                Assert.Equal(i + 1, hashTable.Count);
            }
        }

        [Fact]
        public void ExistingKey_ExistingUpdated()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();

            //Act
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);
            hashTable.Add("key2", 5);
            int updatedEl = hashTable.Get("key2");

            //Assert
            Assert.Equal(5, updatedEl);
        }

        [Fact]
        public void ExistingKey_CountStaysSame()
        {
            //Arrange
            HashTable<string, int> hashTable = new HashTable<string, int>();

            //Act
            hashTable.Add("key1", 1);
            hashTable.Add("key2", 2);
            hashTable.Add("key3", 3);
            hashTable.Add("key2", 5);

            //Assert
            Assert.Equal(3, hashTable.Count);
        }
    }
}
