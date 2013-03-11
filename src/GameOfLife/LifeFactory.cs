namespace GameOfLife
{
    public class LifeFactory : ILifeFactory
    {
        public Life Create()
        {
             return new Life(50);
        }
    }
}