using System;

namespace GameOfLife
{
    class GameOfLife : IGameOfLife
    {
        public ILifeBootstraper LifeBootstraper { get; set; }

        public IRenderingEngine RenderingEngine { get; set; }

        public ILifeReproductor Reproductor { get; set; }

        public void Play()
        {
            var life = new Life(50);
            LifeBootstraper.Initialize(life);
            while (!life.IsDead)
            {
                RenderingEngine.Draw(life);
                Console.Read();
                Reproductor.Procreate(life);
            }
        }
      }
}