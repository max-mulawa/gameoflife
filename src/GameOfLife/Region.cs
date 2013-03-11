namespace GameOfLife
{
    public class Region
    {
        public int RowNumber { get; set; }

        public int ColumnNumber { get; set; }

        public int RowSize { get; set; }

        public int ColumnSize { get; set; }

        public override string ToString()
        {
            return string.Format("Row Number:{0}, Column Number:{1}, Row Size:{2}, Column Size:{3}", RowNumber, ColumnNumber, RowSize, ColumnSize);
        }
    }
}