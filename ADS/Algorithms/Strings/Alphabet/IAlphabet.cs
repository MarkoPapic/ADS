using System;
using System.Collections.Generic;
using System.Text;

namespace ADS.Algorithms.Strings
{
    public interface IAlphabet
    {
        int R { get; }
        bool Contains(char c);
        char ToChar(int i);
        int ToIndex(char c);
    }
}
