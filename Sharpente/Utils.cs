using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    struct Position
    {
        public int X;
        public int Y;
    }

    enum Directions
    {
        Up,
        Down,
        Left,
        Right,
    }

    struct Pixel
    {
        public char Symbol;
        public ConsoleColor Color;
    }

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
    }

}
