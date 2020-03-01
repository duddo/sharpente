using System;
using System.Collections.Generic;
using System.Text;
using Sharpente.Graphics;
using Sharpente.Interfaces;

namespace Sharpente.Shapes
{
    class Rectangle : IDrawable, ITouchable
    {
        private readonly Line _up;
        private readonly Line _right;
        private readonly Line _left;
        private readonly Line _bottom;

        public Point BottomLeft { get; private set; }
                         
        public Rectangle(Point upperLeft, int width, int height)
        {
            _up = new Line(upperLeft, Directions.Right, width);
            _right = new Line(_up.End, Directions.Down, height);
            _left = new Line(upperLeft, Directions.Down, height);
            _bottom = new Line(_left.End, Directions.Right, width);

            BottomLeft = _bottom.Start;
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            _up.Draw(frameBuffer);
            _right.Draw(frameBuffer);
            _left.Draw(frameBuffer);
            _bottom.Draw(frameBuffer);
        }

        public bool Touches(Point point)
        {
            if (_up.Touches(point) || _right.Touches(point) ||
                _left.Touches(point) || _bottom.Touches(point))
                return true;
            return false;
        }
    }
}
