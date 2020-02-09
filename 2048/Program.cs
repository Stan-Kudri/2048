
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    //Цифры сделаны под стрелки вверх(1) вправо(2) вниз(3) влево(4)
    

    class Program
    {
        static void Main(string[] args)
        {
            int size = 4;
            var field = new NewField(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(field[i, j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine();
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                field.Movement(key);
                if (!field.RandomCellForNumber())
                    field.FreeCellRecording();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        Console.Write(field[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            while (field.FreeCellCheck());

            Console.ReadKey();
        }
    }
}
