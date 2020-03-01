using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Sharpente.Elements;
using Sharpente.Graphics;
using Sharpente.Shapes;

namespace Sharpente
{
    class Game
    {
        
        private FrameBuffer _frameBuffer;

        private Rectangle _field;
        private Text _status;
        private Text _message;
        private Fruit _fruit;
        private Snake _snake;

        public Game(FrameBuffer frameBuffer, int width, int height)
        {
            _frameBuffer = frameBuffer;

            _snake = new Snake(width, height);

            var upperLeft = new Point(2, 1, Graphics.Graphics.Border);
            _field = new Rectangle(upperLeft, width-2, height-4);

            _fruit = new Fruit(upperLeft.GetAdjacent(Directions.Right).GetAdjacent(Directions.Down), width, height);

            var p = _field.BottomLeft.GetAdjacent(Directions.Down);
            _status = new Text(p, ConsoleColor.Yellow, "Go!");
            _message = new Text(p.GetAdjacent(Directions.Down), ConsoleColor.Yellow, "Running");
        }

        public void Run()
        {
            bool keepGoing = true;

            while(keepGoing)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo ki = Console.ReadKey(intercept: true);
                    switch (ki.Key)
                    {
                        case ConsoleKey.UpArrow:
                            _snake.Course = Directions.Up; 
                            break;
                        case ConsoleKey.DownArrow:
                            _snake.Course = Directions.Down; 
                            break;
                        case ConsoleKey.LeftArrow:
                            _snake.Course = Directions.Left; 
                            break;
                        case ConsoleKey.RightArrow:
                            _snake.Course = Directions.Right; 
                            break;
                    }
                }

                keepGoing = Update();
                Draw();

                _frameBuffer.Render();

                Thread.Sleep(50);
            }
        }

        private bool Update()
        {
            if(_fruit.Touches(_snake.Head))
            {
                _snake.Grow();
                _fruit.GetNew();
            }

            if (_field.Touches(_snake.Head) || _snake.Touches(_snake.Head))
            {
                _message.Color = ConsoleColor.Red;
                _message.TextString = "Game over!";
                return false;
            }

            return true;
        }

        private void Draw()
        {
            _frameBuffer.Clear();

            _field.Draw(_frameBuffer);
            _status.Draw(_frameBuffer);
            _message.Draw(_frameBuffer);
            _fruit.Draw(_frameBuffer);

            _snake.Draw(_frameBuffer);
        }
    }
}
