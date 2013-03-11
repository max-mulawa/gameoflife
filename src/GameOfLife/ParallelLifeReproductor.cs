using System.Threading.Tasks;

namespace GameOfLife
{
    public class ParallelLifeReproductor : BaseLifeReproductor, ILifeReproductor
    {
        public void Procreate(ILife life)
        {
            Region[] r = life.GetRegions(10);
            Parallel.ForEach(r,(region, state) =>
                                          {
                                              foreach (Cell cell in life.GetCellsByRegion(region))
                                              {
                                                  GrowCell(cell);
                                              }
                                          }
                );
        }
    }
}