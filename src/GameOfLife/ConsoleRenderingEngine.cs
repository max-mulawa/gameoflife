using System;

namespace GameOfLife
{
    public class ConsoleRenderingEngine : IRenderingEngine
    {
        public void Draw(Life life)
        {
            Console.Clear();

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.Write(life[i, j] ? "*" : " ");
                }
                Console.Write(Environment.NewLine);
            }
        } 
    }
}