namespace GameOfLife
{
    public class LifeFactory : ILifeFactory
    {
        public ILife Create()
        {
             return new Life(50);
        }
    }
}