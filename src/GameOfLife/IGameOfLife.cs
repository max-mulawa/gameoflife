namespace GameOfLife
{
    internal interface IGameOfLife
    {
        ILifeBootstraper LifeBootstraper { get; set; }
        IRenderingEngine RenderingEngine { get; set; }
        ILifeReproductor Reproductor { get; set; }
        void Play();
    }
}