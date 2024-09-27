namespace _2048.Model.Cell
{
    public class Point
    {
        private readonly int _row;
        private readonly int _column;

        public Point(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int Row => _row;

        public int Column => _column;
    }
}
