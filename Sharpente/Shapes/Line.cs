using System;
using System.Collections.Generic;
using System.Linq;
using Sharpente.Graphics;
using Sharpente.Interfaces;

namespace Sharpente.Shapes
{
    /// <summary>
    /// Represents a line that can only be oriented along one of <see cref="Directions"/>.
    /// A line of zero length will have one point.
    /// </summary>
    class Line : IDrawable, ITouchable
    {
        private List<Point> _points = new List<Point>();

        public Point Start => _points.First();
        public Point End => _points.Last();

        public Line(Point start, Directions direction, int length)
        {
            var tmp = start;

            for (int i = 0; i < length; i++)
            {
                _points.Add(tmp);
                tmp = tmp.GetAdjacent(direction);
            }
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            foreach (var p in _points)
                p.Draw(frameBuffer);
        }

        public bool Touches(Point point)
        {
            foreach (var p in _points)
            {
                if (p.Touches(point))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return _points.Count.ToString();
        }
    }

}
