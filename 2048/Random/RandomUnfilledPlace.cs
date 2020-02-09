using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class RandomUnfilledPlace
    {
        private static Random rnd = new Random();

        public static int Value(int number)
        {
            return rnd.Next(0, number);
        }
    }
}
