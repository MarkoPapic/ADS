using ADS.Algorithms.Strings;
using Xunit;

namespace ADS.UnitTests.Algorithms.Strings
{
    public class Regex_Matches
    {
        [Theory]
        [InlineData("((A*B|AC)D)", "AABD")]
        [InlineData("((AB)(AB)*)", "AB")]
        [InlineData("((AB)(AB)*)", "ABABAB")]
        [InlineData("((AB)(AB)(AB))", "ABABAB")]
        [InlineData("((AB)|(AB)(AB))", "AB")]
        [InlineData("((AB)|(AB)(AB))", "ABAB")]
        public void Matches_TrueReturned(string re, string txt)
        {
            //Arrange
            Regex regex = new Regex(re);

            //Act
            bool matches = regex.Matches(txt);

            //Assert
            Assert.True(matches);
        }
    }
}
