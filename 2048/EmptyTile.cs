using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Point
    {
        public int Line { get; set; }
        public int Column { get; set; }

        
        public Point(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }

    class EmptyTile
    {        
        private List<Point> list = new List<Point>();

        public void Tile(int [,] items)
        {
            for (int i = 0; i < items.GetLength(0); i++)
                for (int j = 0; j < items.GetLength(1); j++)
                    if (items[i, j] == 0)
                        this.Add(i, j);
        }

        public void Add(int line, int column)
        {
            list.Add(new Point(line, column));
        }

        public Point RandomEmptyCell()
        {
            int number = list.Count;
            number = RandomValue.Value(number);
            return list[number];
        }
    }
}
