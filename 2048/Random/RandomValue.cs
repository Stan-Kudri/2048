using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class RandomValue
    {
        private static Random rnd = new Random();

        public static int Tile(int [] value)
        {
            int k = rnd.Next(value.Length);
            return value[k];
        }

        public static int Value(int number)
        {
            return rnd.Next(number);
        }

    }
}
