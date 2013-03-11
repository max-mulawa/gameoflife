using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Life : ILife
    {
        private readonly bool[,] _life;
        private readonly int _size;
        private Life _clone;

        private Life(bool[,] life)
        {
            _life = life;
            _size = life.GetUpperBound(0);
        }

        public Life(int size)
        {
            _size = size;
            _life = new bool[size,size];
        }

        public void BeginCycle()
        {
            _clone = Clone();
        }

        public void EndCycle()
        {
            _clone = null;
        }

        private Life Clone()
        {
            return new Life((bool[,]) _life.Clone());
        }

        public bool this[int rowNumber, int columnNumber]
        {
            get
            {
                return GetValue(rowNumber, columnNumber);
            }
            set
            {
                SetValue(rowNumber, columnNumber, value);
            }
        }
        
        private void SetValue(int rowNumber, int columnNumber, bool value)
        {
            if (IsInsideOfBounds(rowNumber, columnNumber))
            {
                _life[rowNumber, columnNumber] = value;
            }
        }

        private bool GetValue(int rowNumber, int columnNumber)
        {
            if (IsInsideOfBounds(rowNumber, columnNumber))
            {
                return _life[rowNumber, columnNumber];
            }

            return false;
        }

        private bool IsInsideOfBounds(int rowNumber, int columnNumber)
        {
            return rowNumber >= 0 && columnNumber >= 0 && rowNumber < Size && columnNumber < Size;
        }

        public IEnumerable<Cell> Cells
        {
            get
            {
                Region region = new Region();
                region.RowNumber = 0;
                region.ColumnNumber = 0;
                region.RowSize = Size;
                region.ColumnSize = Size;
                return GetCellsByRegion(region);
            }
        }

        public IEnumerable<Cell> GetCellsByRegion(Region region)
        {
            for (int i = region.RowNumber; i < region.RowNumber+region.RowSize; i++)
            {
                for (int j = region.ColumnNumber; j < region.ColumnNumber+region.ColumnSize; j++)
                {
                    yield return new Cell { IsAlive = _life[i, j], RowNumber = i, ColumnNumber = j, Life = this, StateOfLife = _clone };
                }
            }
        }
        
        public bool IsDead 
        { 
            get
            {
                return !Cells.Any(c => c.IsAlive);
            }
        }

        private int Size
        {
            get { return _size; }
        }

        public Region[] GetRegions(int regions)
        {
           var regionList = new List<Region>();
           int divideInto = Convert.ToInt32(Math.Sqrt(regions));
           int regionSize = Convert.ToInt32(Size/divideInto);
           int lastRegionSize = Size - regionSize*divideInto;
           Console.WriteLine(lastRegionSize);

            for (int regionsRowCount = 0; regionsRowCount < divideInto; regionsRowCount++)
            {
                for (int regionsColumnCount = 0; regionsColumnCount < divideInto; regionsColumnCount++)
                {
                    var region = new Region();
                    region.ColumnNumber = regionSize*regionsColumnCount;
                    region.RowNumber = regionSize*regionsRowCount;
                    region.RowSize = regionSize + (regionsRowCount == divideInto - 1 ? lastRegionSize : 0);
                    region.ColumnSize = regionSize + (regionsColumnCount == divideInto - 1 ? lastRegionSize : 0);
                    regionList.Add(region);
                }
                
            }
            return regionList.ToArray();
        }
    }
}