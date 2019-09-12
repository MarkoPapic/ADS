using ADS.Algorithms.Strings;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Algorithms.Strings
{
    public class StringSortLSD_Sort
    {
        [Fact]
        public void Test()
        {
            //Arrange
            string[] strings = { "4PGC938", "2IYE230", "3CIO720", "1ICK750", "1OHV845", "4JZY524", "1ICK750", "3CIO720", "1OHV845", "1OHV845", "2RLA629", "2RLA629", "3ATW723" };
            string[] expected = { "1ICK750", "1ICK750", "1OHV845", "1OHV845", "1OHV845", "2IYE230", "2RLA629", "2RLA629", "3ATW723", "3CIO720", "3CIO720", "4JZY524", "4PGC938" };
            StringSortLSD ss = new StringSortLSD(new AsciiAlphabet());

            //Act
            ss.Sort(strings, 7);

            //Assert
            Assert.True(expected.SequenceEqual(strings));
        }
    }
}
