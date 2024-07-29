
using _2048.Model;
using System;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 4;
            var valuetiles = new RandomGenerator();
            valuetiles.Add(2, 90).Add(4, 10);
            var field = new Field(size, valuetiles);
            ColorPrintingDigit.Print(field);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }

                if (field.Movement(key))
                {
                    field.FillOneOfTheRandomCells();
                    Console.Clear();
                    ColorPrintingDigit.Print(field);
                }
            }
            while (field.GameCheck());

            Console.WriteLine("Игра окончена!");
            Console.ReadKey();
        }
    }
}
