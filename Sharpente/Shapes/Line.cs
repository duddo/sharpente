using System;
using System.Collections.Generic;
using System.Linq;
using Sharpente.Graphics;

namespace Sharpente.Shapes
{
    /// <summary>
    /// Represents a line that can only be oriented along one of <see cref="Directions"/>.
    /// A line of zero length will have one point.
    /// </summary>
    class Line : IDrawable
    {
        private List<Point> _points = new List<Point>();

        public Line(Point start, Directions direction, int length)
        {
            var tmp = start;

            for (int i = 0; i < length; i++)
            {
                _points.Add(tmp);
                tmp.GetAdjacent(direction);
            }
        }

        public Point GetStart()
        {
            return _points.First();
        }

        public Point GetEnd()
        {
            return _points.Last();
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            foreach (var p in _points)
                p.Draw(frameBuffer);
        }

    }

}
