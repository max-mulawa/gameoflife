namespace GameOfLife
{
    public class BaseLifeReproductor
    {
        protected void GrowCell(Cell cell)
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