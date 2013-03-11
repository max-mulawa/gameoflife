using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        private bool _isDead = true;
        private bool _isAlive;
        
        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public Life Life { get; set; }

        public bool IsAlive
        {
            get { return _isAlive; }
            set
            {
                _isAlive = value;
                _isDead = !_isAlive;
            }
        }

        public bool IsDead
        {
            get { return _isDead; }
            set
            {
                _isDead = value;
                _isAlive = !_isDead;
            }
        }

        public Life StateOfLife { get; set; }

        public int GetAliveNeighboursCount()
        {
            int[] indexes = Enumerable.Range(-1, 3).ToArray();
            int aliveNeigbours = 0;
            for (int k = 0; k < indexes.Length; k++)
            {
                for (int l = 0; l < indexes.Length; l++)
                {
                    if (k == 1 && l == 1)
                    {
                        continue;
                    }

                    if (StateOfLife[RowNumber + indexes[k], ColumnNumber + indexes[l]])
                    {
                        aliveNeigbours++;
                    }
                }
            }

            return aliveNeigbours;
        }

        public void Dies()
        {
            Life[RowNumber, ColumnNumber] = false;
        }

        public void Alive()
        {
            Life[RowNumber, ColumnNumber] = true;
        }
    }
}