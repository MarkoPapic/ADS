using ADS.Algorithms.Strings;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Algorithms.Strings
{
    public class StringSortMSD_Sort
    {
        [Fact]
        public void Test()
        {
            //Arrange
            string[] strings = { "she", "sells", "seashells", "by", "the", "seashore", "the", "shells", "she", "sells", "are", "surely", "seashells" };
            string[] expected = { "are", "by", "seashells", "seashells", "seashore", "sells", "sells", "she", "she", "shells", "surely", "the", "the" };
            StringSortMSD ss = new StringSortMSD(new AsciiAlphabet());

            //Act
            ss.Sort(strings);

            //Assert
            Assert.True(expected.SequenceEqual(strings));
        }
    }
}
