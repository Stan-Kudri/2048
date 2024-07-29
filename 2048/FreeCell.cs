using _2048.Model.Entities;
using System;
using System.Collections.Generic;

namespace _2048
{
    public class FreeCell
    {
        private readonly List<Point> _list = new List<Point>();

        public void Cell(int[,] items)
        {
            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    if (items[i, j] == 0)
                    {
                        Add(i, j);
                    }
                }
            }
        }

        private void Add(int row, int column)
            => _list.Add(new Point(row, column));

        public Point RandomEmptyCell()
            => _list[new Random().Next(_list.Count)];
    }
}
