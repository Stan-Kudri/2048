using _2048.Model.Entities;
using System;
using System.Collections.Generic;

namespace _2048.Extension
{
    public static class RandomValueFromListExtension
    {
        public static Point GetRandomCell(this List<Point> cells)
            => cells[new Random().Next(cells.Count)];
    }
}
