using ADS.Algorithms.Compression;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Compression
{
    public class RunLengthEncoding_Expand
    {
        [Fact]
        public void Test()
        {
            //Arrange
            byte[] originalBytes = { 0, 4, 2, 2, 2, 3, 5, 10, 8, 2, 9, 1 };
            byte[] expectedExpandedBytes = { 243, 56, 63, 240, 12, 1 };
            Stream originalStream = new MemoryStream(originalBytes);
            MemoryStream expandedStream = new MemoryStream();

            //Act
            RunLengthEncoding.Expand(originalStream, expandedStream);
            byte[] expandedBytes = expandedStream.ToArray();
            originalStream.Dispose();
            expandedStream.Dispose();

            //Assert
            Assert.True(expectedExpandedBytes.SequenceEqual(expandedBytes));
        }
    }
}
