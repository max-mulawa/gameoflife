using System.Collections.Generic;

namespace GameOfLife
{
    public interface ILife
    {
        void BeginCycle();
        void EndCycle();
        bool this[int rowNumber, int columnNumber] { get; set; }
        IEnumerable<Cell> Cells { get; }
        bool IsDead { get; }
        IEnumerable<Cell> GetCellsByRegion(Region region);
        Region[] GetRegions(int regions);
    }
}