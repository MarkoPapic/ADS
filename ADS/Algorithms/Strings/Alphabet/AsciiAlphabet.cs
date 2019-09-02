using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Strings
{
    public class AsciiAlphabet : IAlphabet
    {
        public int R => 256;

        public char ToChar(int i)
        {
            return (char)i;
        }

        public int ToIndex(char c)
        {
            return (int)c;
        }
    }
}
