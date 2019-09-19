using ADS.Algorithms.Strings;
using ADS.DataStructures;
using Xunit;

namespace ADS.UnitTests.DataStructures.TrieRWay
{
    public class TrieRWay_Insert
    {
        [Fact]
        public void ElementInserted()
        {
            //Arrange
            (string, int)[] elements = new (string, int)[] { ("one",1), ("five",5), ("nine", 9), ("two", 2), ("three", 3), ("six", 6), ("four", 4), ("seven", 7), ("eight", 8) };
            TrieRWay<int> trie = new TrieRWay<int>(new AsciiAlphabet());

            //Act
            foreach (var el in elements)
                trie.Insert(el.Item1, el.Item2);

            //Assert
            foreach (var el in elements)
            {
                int found = trie.Get(el.Item1);
                Assert.Equal(el.Item2, found);
            }
        }

        [Fact]
        public void NoDuplicates()
        {
            //Arrange
            (string, int) duplicate = ("nine", 24);
            (string, int)[] elements = new (string, int)[] { ("one", 1), ("five", 5), ("nine", 9), ("two", 2), ("three", 3), ("six", 6), ("four", 4), ("seven", 7), ("eight", 8) };
            TrieRWay<int> trie = new TrieRWay<int>(new AsciiAlphabet());

            //Act
            foreach (var el in elements)
                trie.Insert(el.Item1, el.Item2);
            trie.Insert(duplicate.Item1, duplicate.Item2);

            //Assert
            int found = trie.Get(duplicate.Item1);
            Assert.Equal(duplicate.Item2, found);
        }
    }
}
