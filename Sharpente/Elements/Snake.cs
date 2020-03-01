using Sharpente.Graphics;
using Sharpente.Interfaces;
using Sharpente.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpente.Elements
{
    class Snake : IDrawable, ITouchable
    {
        public Directions Course { get; set; }
        public Point Head => _body.First();
        
        private readonly List<Point> _body = new List<Point>();

        public Snake(int width, int height)
        {
            _body.Add(new Point(width / 2, height / 2, Graphics.Graphics.Snake));
        }

        public void Grow()
        {
            _body.Add(_body.Last().GetAdjacent(Course));
        }

        public void Update()
        {
            _body.Insert(0, Head.GetAdjacent(Course));
            _body.RemoveAt(_body.Count-1);
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            foreach (var b in _body)
                frameBuffer.SetPixel(b);
        }

        public bool Touches(Point point)
        {
            foreach (var b in _body)
            {
                if (b.IsEqual(Head))
                    continue;

                if (b.Touches(point))
                    return true;
            }

            return false;
        }
    }
}
