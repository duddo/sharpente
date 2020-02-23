using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 60;
            int height = 30;

            
            FrameBuffer frameBuffer = new FrameBuffer(width, height);

            Game game = new Game(frameBuffer);
            game.Run();
        }
    }
}
