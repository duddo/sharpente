using Sharpente.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using Sharpente.Graphics;

namespace Sharpente
{
    class FrameBuffer
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Area { get => Width * Height; }

        private readonly Pixel[] _buffer;

        public FrameBuffer(int width, int height)
        {
            Width = width;
            Height = height;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            Console.Title = AppDomain.CurrentDomain.FriendlyName;
            Console.CursorVisible = false;

            _buffer = new Pixel[Area];
        }

        public void SetPixel(Point position)
        {
             _buffer[position.Y * Width + position.X] = position.Pixel;
        }

        public void Clear()
        {
            for (int i = 0; i < Area; i++)
                _buffer[i] = Graphics.Graphics.Background;
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < Area; i++)
            {
                var toWrite = _buffer[i];
                Console.ForegroundColor = toWrite.Color;
                Console.Write(toWrite.Symbol);

                if (i % Width == 0)
                {
                    Console.SetCursorPosition(0, i / (Width - 1));
                }
            }
        }
    }

}
