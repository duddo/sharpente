using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpente.Graphics
{
    class Graphics
    {
        public static Pixel Background = new Pixel
        {
            Symbol = ' ',
            Color = ConsoleColor.Black
        };

        public static Pixel Snake = new Pixel
        {
            Symbol = '*',
            Color = ConsoleColor.Green
        };

        public static Pixel Fruit = new Pixel
        {
            Symbol = '0',
            Color = ConsoleColor.Red
        };

        public static Pixel Border = new Pixel
        {
            Symbol = '█',
            Color = ConsoleColor.White
        };
    }

}
