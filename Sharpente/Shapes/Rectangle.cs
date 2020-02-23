using System;
using System.Collections.Generic;
using System.Text;
using Sharpente.Graphics;

namespace Sharpente.Shapes
{
    class Rectangle : IDrawable
    {
        private Line Up;
        private Line Right;
        private Line Left;
        private Line Bottom;

        public Rectangle(Point upperLeft, int height, int width)
        {
            Up = new Line(upperLeft, Directions.Right, width);
            Right = new Line(Up.GetEnd(), Directions.Down, height);
            Left = new Line(upperLeft, Directions.Down, height);
            Bottom = new Line(Left.GetEnd(), Directions.Right, width);
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            Up.Draw(frameBuffer);
            Right.Draw(frameBuffer);
            Left.Draw(frameBuffer);
            Bottom.Draw(frameBuffer);
        }

    }
}
