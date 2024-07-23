using _2048.Model.Entities;
using System;
using System.Collections.Generic;

namespace _2048
{
    public class FreeCell
    {
        private List<Point> list = new List<Point>();

        public void Cell(int[,] items)
        {
            for (int i = 0; i < items.GetLength(0); i++)
                for (int j = 0; j < items.GetLength(1); j++)
                    if (items[i, j] == 0)
                        Add(i, j);
        }

        private void Add(int row, int column)
            => list.Add(new Point(row, column));

        public Point RandomEmptyCell()
        {
            int number = list.Count;
            number = (new Random()).Next(number);
            return list[number];
        }
    }
}
