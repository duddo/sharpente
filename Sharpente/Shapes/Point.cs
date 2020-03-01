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

        public Point(int x, int y, Pixel pixel) 
        {
            X = x;
            Y = y;
            Pixel = pixel;
        }

        public Point(Point other)
            : this(other.X, other.Y, other.Pixel)
        {
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
                    break;
                case Directions.Right:
                    res.X++;
                    break;
            }

            return res;
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            frameBuffer.SetPixel(this);
        }

        public override string ToString()
        {
            return $"[{X},{Y}]-'{Pixel}'";
        }
    }
}
