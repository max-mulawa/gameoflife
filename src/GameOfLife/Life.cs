using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Life
    {
        private readonly bool[,] _life;
        private readonly int _size;

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

        public Life Clone()
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
            return rowNumber >= 0 && columnNumber >= 0 && rowNumber < _size && columnNumber < _size;
        }

        public IEnumerable<Cell> Cells
        {
            get
            {
                Life life2 = Clone();
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        yield return new Cell { IsAlive = _life[i, j], RowNumber = i, ColumnNumber = j, Life = this, StateOfLife = life2 };
                    }
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
    }
}