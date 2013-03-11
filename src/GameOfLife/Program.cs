using Funq;

namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new Container();
            container.Register<ILifeBootstraper>(c=>new SimpleLifeBootstraper());
            container.Register<ILifeReproductor>(c => new LifeReproductor());
            container.Register<IRenderingEngine>(c => new ConsoleRenderingEngine());
            container.Register<IGameOfLife>(c => new GameOfLife
                                                     {
                                                         LifeBootstraper = container.Resolve<ILifeBootstraper>(),
                                                         RenderingEngine = container.Resolve<IRenderingEngine>(),
                                                         Reproductor = container.Resolve<ILifeReproductor>(),
                                                         LifeFactory = container.Resolve<ILifeFactory>() 
                                                     }); 
           
            var game = container.Resolve<IGameOfLife>();
            game.Play();
        }
    }
}
