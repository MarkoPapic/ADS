using ADS.Algorithms.Compression.Helpers;
using System.Collections.Generic;
using Xunit;

namespace ADS.UnitTests.Compression.Helpers
{
    public class BinaryReader_ReadBit
    {
        [Fact]
        public void Test()
        {
            //Arrange
            byte[] bytes = { 0, 4, 2, 2, 2, 3, 5, 10, 8, 2, 9, 1 };
            bool[] expectedBits = { false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, true, false, false, false, false, false, true, false, true, false, false, false, false, true, false, true, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, true, false, false, true, false, false, false, false, false, false, false, true };
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
            BinaryReader binaryReader = new BinaryReader(ms);

            //Act && assert
            for (int i = 0; i < expectedBits.Length; i++)
            {
                bool currentBit = binaryReader.ReadBit();
                Assert.Equal(expectedBits[i], currentBit);
            }
            Assert.Throws<System.IO.EndOfStreamException>(() => binaryReader.ReadBit());
        }
    }
}
