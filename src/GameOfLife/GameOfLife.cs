using System;

namespace GameOfLife
{
    public class GameOfLife : IGameOfLife
    {
        public ILifeBootstraper LifeBootstraper { get; set; }

        public IRenderingEngine RenderingEngine { get; set; }

        public ILifeReproductor Reproductor { get; set; }

        public ILifeFactory LifeFactory { get; set; }

        public void Play()
        {
            ILife life = LifeFactory.Create();
            LifeBootstraper.Initialize(life);
            while (!life.IsDead)
            {
                RenderingEngine.Draw(life);
                Console.Read();
                life.BeginCycle();
                Reproductor.Procreate(life);
                life.EndCycle();
            }
        }
      }
}