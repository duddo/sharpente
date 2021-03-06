﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    class Game
    {
        private Random _random;
        private FrameBuffer _frameBuffer;
        private Snake _snake;

        public Game(FrameBuffer frameBuffer)
        {
            _random = new Random(DateTimeOffset.UtcNow.Millisecond);
            _frameBuffer = frameBuffer;

            _snake = new Snake(frameBuffer.Center);
        }


        public void Run()
        {
            while(true)
            {
                _frameBuffer.Clear();

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

                _snake.Update();
                _snake.Draw(_frameBuffer);

                _frameBuffer.Render();

                Thread.Sleep(50);
            }
        }
    }
}
