using System;

namespace ADS.Algorithms.Compression.Helpers
{
    public class BinaryReader
    {
        private System.IO.Stream stream;
        private bool streamExhausted;
        private byte buffer;
        private int bufferSizeInBits;

        public BinaryReader(System.IO.Stream stream)
        {
            this.stream = stream;
            FillBuffer();
        }

        public bool ReadBit()
        {
            if (!HasMore())
                throw new System.IO.EndOfStreamException();

            bufferSizeInBits--;
            bool bit = ((buffer >> bufferSizeInBits) & 1) == 1;
            FillBufferIfNeeded();
            return bit;
        }

        public bool HasMore()
        {
            if (streamExhausted)
                return false;
            FillBufferIfNeeded();
            return !streamExhausted;
        }

        private void FillBuffer()
        {
            if (bufferSizeInBits > 0)
                throw new InvalidOperationException("Buffer can only be filled when empty.");

            int b = stream.ReadByte();
            if (b == -1)
                streamExhausted = true;
            else
            {
                buffer = (byte)b;
                bufferSizeInBits = 8;
            }
        }

        private void FillBufferIfNeeded()
        {
            if (bufferSizeInBits == 0)
                FillBuffer();
        }
    }
}
