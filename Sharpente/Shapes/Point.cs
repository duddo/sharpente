using System;
using System.Collections.Generic;
using System.Text;
using Sharpente.Graphics;

namespace Sharpente.Shapes
{
    class Point : IDrawable
    {
        public int X = 0;
        public int Y = 0;
        public Pixel Pixel = Graphics.Graphics.Background;

        public Point() { }

        public Point(Point other)
        {
            X = other.X;
            Y = other.Y;
            Pixel = other.Pixel;
        }

        public Point GetAdjacent(Directions direction)
        {
            var res = new Point(this);

            switch (direction)
            {
                case Directions.Up:
                    res.Y--;
                    break;
                case Directions.Down:
                    res.Y++;
                    break;
                case Directions.Left:
                    res.X--;
                    res.X--;
                    break;
                case Directions.Right:
                    res.X++;
                    res.X++;
                    break;
            }

            return res;
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            frameBuffer.SetPixel(this);
        }
    }
}
