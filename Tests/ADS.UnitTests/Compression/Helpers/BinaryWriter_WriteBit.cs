using ADS.Algorithms.Compression.Helpers;
using System.Linq;
using Xunit;

namespace ADS.UnitTests.Compression.Helpers
{
    public class BinaryWriter_WriteBit
    {
        [Fact]
        public void Test()
        {
            //Arrange
            bool[] bits = { false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, true, false, false, false, false, false, true, false, true, false, false, false, false, true, false, true, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, true, false, false, true, false, false, false, false, false, false, false, true };
            byte[] expectedBytes = { 0, 4, 2, 2, 2, 3, 5, 10, 8, 2, 9, 1 };
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(ms);

            //Act
            for (int i = 0; i < bits.Length; i++)
            {
                bool currentBit = bits[i];
                binaryWriter.WriteBit(currentBit);
            }
            byte[] bytesWritten = ms.ToArray();
            ms.Dispose();

            //Assert
            Assert.True(expectedBytes.SequenceEqual(bytesWritten));
        }
    }
}
