using Sharpente.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpente.Shapes
{
    class Text : IDrawable
    {
        private Pixel[] _pixels;
        private Point _start;
        private string _text;

        public ConsoleColor Color { get; set; }
        public string TextString
        {
            get => _text;
            set
            {
                _text = value;
                _pixels = new Pixel[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    _pixels[i].Color = Color;
                    _pixels[i].Symbol = value[i];
                }
            }
        }

        public Text(Point start, ConsoleColor color, string init = " ")
        {
            Color = color;
            _start = start;
            TextString = init;
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            var tmp = _start;

            foreach (var p in _pixels)
            {
                tmp.Pixel = p;
                frameBuffer.SetPixel(tmp);
                tmp = tmp.GetAdjacent(Directions.Right);
            }
        }
    }
}
