using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ADS.Algorithms.Compression
{
    public static class RunLengthEncoding
    {
        public static void Compress(Stream input, Stream output)
        {
            byte cnt = 0;
            bool b;
            bool old = false;
            Helpers.BinaryReader inputReader = new Helpers.BinaryReader(input);

            while (true)
            {
                try
                {
                    b = inputReader.ReadBit();
                }
                catch (EndOfStreamException)
                {
                    break;
                }

                if (b != old)
                {
                    output.WriteByte(cnt);
                    cnt = 0;
                    old = !old;
                }
                else
                {
                    if (cnt == 255)
                    {
                        output.WriteByte(cnt);
                        cnt = 0;
                        output.WriteByte(cnt);
                    }
                }
                cnt++;
            }

            output.WriteByte(cnt);
            output.Close();
        }

        public static void Expand(Stream input, Stream output)
        {
            bool b = false;
            Helpers.BinaryWriter outputWriter = new Helpers.BinaryWriter(output);

            int cnt;
            while (true)
            {
                cnt = input.ReadByte();
                if (cnt == -1)
                    break;

                for (int i = 0; i < cnt; i++)
                    outputWriter.WriteBit(b);
                b = !b;
            }
        }
    }
}
