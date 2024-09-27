using _2048.Model;
using System;

namespace _2048
{
    public static class ColorPrintingDigit
    {
        public static void Print(this Field field)
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
            Console.ForegroundColor = GetColor(digit);
            Console.Write(digit);
            Console.ResetColor();
        }
    }
}
