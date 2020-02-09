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
        private static int [] value = new int []{2,4};

        public static int Value()
        {
            int k = rnd.Next(0,value.Length);
            return value[k];
        }
    }
}
