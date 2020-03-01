using Sharpente.Graphics;
using Sharpente.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharpente
{
    class Snake : IDrawable
    {
        public Directions Course
        {
            get => _course;
            set 
            {
                _oldCourse = _course;
                _course = value; 
            }
        }

        private Directions _course = Directions.Up;
        private Directions _oldCourse = Directions.Up;
        private readonly List<Point> _body = new List<Point>();

        public Snake(int width, int height)
        {
            _body.Add(new Point(width / 2, height / 2, Graphics.Graphics.Snake));
        }

        public void Update()
        {
            var last = _body.First();

            _body.Clear();
            _body.Add(last.GetAdjacent(_course));
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            foreach (var b in _body)
                frameBuffer.SetPixel(b);
        }
    }
}
