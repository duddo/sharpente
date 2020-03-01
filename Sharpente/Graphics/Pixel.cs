using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpente.Graphics
{
    struct Pixel
    {
        public char Symbol;
        public ConsoleColor Color;

        public override string ToString()
        {
            return Symbol.ToString();
        }
    }
}
