using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{

    class Snake
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
        private readonly List<Position> _body = new List<Position>();

        public Snake(Position start)
        {
            _body.Add(start);
        }

        public void Update()
        {
            var last = _body.First();

            switch(_course)
            {
                case Directions.Up:
                    last.Y--;
                    break;
                case Directions.Down:
                    last.Y++;
                    break;
                case Directions.Left:
                    last.X--;
                    last.X--;
                    break;
                case Directions.Right:
                    last.X++;
                    last.X++;
                    break;
            }

            _body.Clear();
            _body.Add(last);
        }

        public void Draw(FrameBuffer frameBuffer)
        {
            foreach (var b in _body)
                frameBuffer.SetPixel(b, Graphics.Snake);
        }
    }
}
