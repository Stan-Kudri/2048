
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        public static void Conclusion(Field field)
        {
            for (int i = 0; i < field.Row; i++)
            {
                for (int j = 0; j < field.Column; j++)
                {
                    PrintDigit(field[i, j]);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static ConsoleColor GetColor(int i)
        {
            switch (i)
            {
                case 0:
                    return ConsoleColor.White;
                case 2:
                    return ConsoleColor.Blue;
                case 4:
                    return ConsoleColor.Magenta;
                case 8:
                    return ConsoleColor.Cyan;
                case 16:
                    return ConsoleColor.Green;
                case 32:
                    return ConsoleColor.Yellow;
                case 64:
                    return ConsoleColor.DarkBlue;
                case 128:
                    return ConsoleColor.DarkMagenta;
                case 256:
                    return ConsoleColor.DarkCyan;
                case 512:
                    return ConsoleColor.DarkGreen;
                case 1024:
                    return ConsoleColor.DarkYellow;
                case 2048:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.Red;
            }
        }

        private static void PrintDigit(int digit)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(digit);
            Console.Write(digit);
            Console.ForegroundColor = oldColor;
        }
        
        static void Main(string[] args)
        {
            int size = 4;
            var field = new Field(size);
            Conclusion(field);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (field.Movement(key))
                {
                    if (!field.RandomCellFilling())
                        field.CellFilling();
                    Conclusion(field);
                }                                    
            }
            while (field.GameCheck());
            Console.WriteLine("Игра окончена!");
            Console.ReadKey();
        }
    }
}
