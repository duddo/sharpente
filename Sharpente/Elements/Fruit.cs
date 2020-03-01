using Sharpente.Interfaces;
using Sharpente.Shapes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpente.Elements
{
    class Fruit : IDrawable, ITouchable
    {
        Random _random;
        Point _start;
        int _width;
        int _height;

        Point _fruit;

        public Fruit( Point start, int width, int height)
        {
            _random = new Random(DateTimeOffset.UtcNow.Millisecond);
            _start = start;
            _width = width;
            _height = height;

            GetNew();
        }

        public void GetNew()
        {
            _fruit = new Point(
                _random.Next(_start.X, _width),
                _random.Next(_start.Y, _height),
                Graphics.Graphics.Fruit
            );
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            _fruit.Draw(frameBuffer);
        }

        public bool Touches(Point point)
        {
            return _fruit.Touches(point);
        }
    }
}
