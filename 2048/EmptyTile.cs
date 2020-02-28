using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048;

namespace _2048
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        
        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    class FreeCell
    {        
        private List<Point> list = new List<Point>();

        public void Cell(int [,] items)
        {
            for (int i = 0; i < items.GetLength(0); i++)
                for (int j = 0; j < items.GetLength(1); j++)
                    if (items[i, j] == 0)
                        this.Add(i, j);
        }

        private void Add(int row, int column)
        {
            list.Add(new Point(row, column));
        }

        public Point RandomEmptyCell()
        {
            int number = list.Count;
            number = (new Random()).Next(number);
            return list[number];
        }
    }
}
