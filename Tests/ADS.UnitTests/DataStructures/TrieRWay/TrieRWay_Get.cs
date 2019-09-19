using ADS.Algorithms.Strings;
using ADS.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ADS.UnitTests.DataStructures.TrieRWay
{
    public class TrieRWay_Get
    {
        [Fact]
        public void HappyPath_ElementRetuned()
        {
            //Arrange
            (string, int)[] elements = new (string, int)[] { ("one", 1), ("five", 5), ("nine", 9), ("two", 2), ("three", 3), ("six", 6), ("four", 4), ("seven", 7), ("eight", 8) };
            TrieRWay<int> trie = new TrieRWay<int>(new AsciiAlphabet());
            foreach (var el in elements)
                trie.Insert(el.Item1, el.Item2);

            //Act & Assert
            foreach (var el in elements)
            {
                int foundEl = trie.Get(el.Item1);
                Assert.Equal(el.Item2, foundEl);
            }
        }

        [Fact]
        public void KeyNotPresent_ExceptionThrown()
        {
            //Arrange
            string nonExistingKey = "something";
            (string, int)[] elements = new (string, int)[] { ("one", 1), ("five", 5), ("nine", 9), ("two", 2), ("three", 3), ("six", 6), ("four", 4), ("seven", 7), ("eight", 8) };
            TrieRWay<int> trie = new TrieRWay<int>(new AsciiAlphabet());
            foreach (var el in elements)
                trie.Insert(el.Item1, el.Item2);

            //Act
            Action act = () => trie.Get(nonExistingKey);

            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
