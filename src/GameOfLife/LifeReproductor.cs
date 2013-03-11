namespace GameOfLife
{
    public class LifeReproductor : ILifeReproductor
    {
        public void Procreate(Life life)
         {
            foreach (Cell cell in life.Cells)
            {
                int neighbours = cell.GetAliveNeighboursCount();
                if (cell.IsAlive && (neighbours == 2 || neighbours == 3))
                {
                    //live to next generation
                }
                else if (cell.IsAlive && (neighbours < 2 || neighbours > 3))
                {
                    cell.Dies();
                }
                else if (cell.IsDead && neighbours == 3)
                {
                    cell.Alive();
                }
            }
         }

         
    }
}