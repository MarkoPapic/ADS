using ADS.Algorithms.Strings;
using Xunit;

namespace ADS.UnitTests.Algorithms.Strings
{
    public class SubstringSearchKMP_Search
    {
        [Theory]
        [InlineData("AABRAACADABRAACAADABRA", "AACAA", 12)]
        [InlineData("In computer science, the Knuth-Morris-Pratt string-searching algorithm (or KMP algorithm) searches for occurrences of a 'word' W within a main 'text string' S by employing the observation that when a mismatch occurs, the word itself embodies sufficient information to determine where the next match could begin, thus bypassing re-examination of previously matched characters.", "KMP algorithm", 75)]
        public void Exists_IndexReturned(string txt, string pattern,  int expectedPos)
        {
            //Arrange
            SubstringSearchKMP kmp = new SubstringSearchKMP(pattern, new AsciiAlphabet());

            //Act
            int pos = kmp.Search(txt);

            //Assert
            Assert.Equal(expectedPos, pos);
        }

        [Fact]
        public void DoesntExist_IndicatorReturned()
        {
            //Arrange
            string pattern = "hello";
            string txt = "Hi! This is some test sentence. This sentence doesn't contain the word hell0 in it.";
            SubstringSearchKMP kmp = new SubstringSearchKMP(pattern, new AsciiAlphabet());

            //Act
            int pos = kmp.Search(txt);

            //Assert
            Assert.Equal(-1, pos);
        }
    }
}
