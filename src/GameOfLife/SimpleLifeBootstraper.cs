using System;

namespace GameOfLife
{
    public class SimpleLifeBootstraper : ILifeBootstraper
    {
        public void Initialize(Life life)
        {
            var r = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 100 - 1; i++)
            {
                life[i, i] = true;
                life[i + 1, i] = true;
                life[r.Next(i, 100 - 1), r.Next(i, 100 - 1)] = true;
            }  
        }
    }
}