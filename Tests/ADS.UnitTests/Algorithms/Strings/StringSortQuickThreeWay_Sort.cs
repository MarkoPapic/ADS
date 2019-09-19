using ADS.Algorithms.Strings;
using System;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Algorithms.Strings
{
    public class StringSortQuickThreeWay_Sort
    {
        [Fact]
        public void Test()
        {
            //Arrange
            string[] strings = { "she", "sells", "seashells", "by", "the", "seashore", "the", "shells", "she", "sells", "are", "surely", "seashells" };
            string[] expected = { "are", "by", "seashells", "seashells", "seashore", "sells", "sells", "she", "she", "shells", "surely", "the", "the" };

            //Act
            StringSortQuickThreeWay.Sort(strings);

            //Assert
            Assert.True(expected.SequenceEqual(strings));
        }
    }
}
