namespace GameOfLife
{
    public class LifeReproductor : BaseLifeReproductor, ILifeReproductor
    {
        public void Procreate(ILife life)
         {
            foreach (Cell cell in life.Cells)
            {
                GrowCell(cell);
            }
         }
    }
}