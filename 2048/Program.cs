
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{

    class Program
    {
        static void Main(string[] args)
        {
            int size = 4;
            var field = new Field(size);
            field.Conclusion();
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                field.Movement(key);
                if (!field.RandomCellFilling())
                    field.CellFilling();
                field.Conclusion();

            }
            while (field.CellCheck());
            Console.WriteLine("Игра окончена!");
            Console.ReadKey();
        }
    }
}
