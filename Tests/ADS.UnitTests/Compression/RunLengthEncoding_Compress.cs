using ADS.Algorithms.Compression;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Compression
{
    public class RunLengthEncoding_Compress
    {
        [Fact]
        public void StartsWithOne_Compressed()
        {
            //Arrange
            byte[] originalBytes = { 243, 56, 63, 240, 12, 1 };
            byte[] expectedCompressedBytes = { 0, 4, 2, 2, 2, 3, 5, 10, 8, 2, 9, 1 };
            Stream originalStream = new MemoryStream(originalBytes);
            MemoryStream compressedStream = new MemoryStream();

            //Act
            RunLengthEncoding.Compress(originalStream, compressedStream);
            byte[] compressedBytes = compressedStream.ToArray();
            originalStream.Dispose();
            compressedStream.Dispose();

            //Assert
            Assert.True(expectedCompressedBytes.SequenceEqual(compressedBytes));
        }

        [Fact]
        public void StartsWithZero_Compressed()
        {
            //Arrange
            byte[] originalBytes = { 16, 243, 56, 63, 240, 12, 1 };
            byte[] expectedCompressedBytes = { 3, 1, 4, 4, 2, 2, 2, 3, 5, 10, 8, 2, 9, 1 };
            Stream originalStream = new MemoryStream(originalBytes);
            MemoryStream compressedStream = new MemoryStream();

            //Act
            RunLengthEncoding.Compress(originalStream, compressedStream);
            byte[] compressedBytes = compressedStream.ToArray();
            originalStream.Dispose();
            compressedStream.Dispose();

            //Assert
            Assert.True(expectedCompressedBytes.SequenceEqual(compressedBytes));
        }
    }
}
