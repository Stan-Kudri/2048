using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Point
    {
        public int _line { get; set; }
        public int _column { get; set; }

        
        public Point(int line, int column)
        {
            _line = line;
            _column = column;
        }
    }

    class FreeCellCoordinates
    {        
        private List<Point> list = new List<Point>();

        

        public void ListEntry(int line, int column)
        {
            list.Add(new Point(line, column));
        }

        public Point RandomEmptyCell()
        {
            int number = list.Count;
            number = RandomUnfilledPlace.Value(number);
            return list[number];
        }
    }
}
