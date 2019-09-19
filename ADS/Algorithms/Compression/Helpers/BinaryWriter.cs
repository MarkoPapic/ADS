using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Compression.Helpers
{
    public class BinaryWriter
    {
        private System.IO.Stream stream;
        private byte buffer;
        private int bufferSizeInBits;

        public BinaryWriter(System.IO.Stream stream)
        {
            this.stream = stream;
        }

        public void WriteBit(bool bit)
        {
            // add bit to buffer
            buffer <<= 1;
            if (bit) buffer |= 1;

            // if buffer is full (8 bits), write out as a single byte
            bufferSizeInBits++;
            if (bufferSizeInBits == 8)
                ClearBuffer();
        }

        public void WriteByte(byte b)
        {
            // optimized if byte-aligned
            if (bufferSizeInBits == 0)
                stream.WriteByte(b);
            else
            {
                // otherwise write one bit at a time
                for (int i = 0; i < 8; i++)
                {
                    bool bit = ((b >> (8 - i - 1)) & 1) == 1;
                    WriteBit(bit);
                }
            }
        }

        private void ClearBuffer()
        {
            if (bufferSizeInBits == 0)
                return;

            buffer <<= (8 - bufferSizeInBits);
            stream.WriteByte(buffer);
            bufferSizeInBits = 0;
            buffer = 0;
        }
    }
}
