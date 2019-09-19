using ADS.Algorithms.Strings;
using ADS.DataStructures;
using Xunit;

namespace ADS.UnitTests.DataStructures.TrieRWay
{
    public class TrieRWay_ContainsKey
    {
        [Fact]
        public void Test()
        {
            //Arrange
            (string, int)[] elements = new (string, int)[] { ("one", 1), ("five", 5), ("nine", 9), ("two", 2), ("three", 3), ("six", 6), ("four", 4), ("seven", 7), ("eight", 8) };
            TrieRWay<int> trie = new TrieRWay<int>(new AsciiAlphabet());
            foreach (var el in elements)
                trie.Insert(el.Item1, el.Item2);

            //Act & Assert
            foreach (var el in elements)
            {
                bool exists = trie.ContainsKey(el.Item1);
                Assert.True(exists);
            }
        }
    }
}
