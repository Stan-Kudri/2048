using _2048.Model;
using _2048.Model.Cell;
using _2048.Model.Entities;
using System;
using System.Collections.Generic;

namespace _2048
{
    public class Game
    {
        private readonly RandomGenerator _randomGenerator;
        private readonly Field _field;
        private readonly RandomBlockValue _randomBlockValue;

        public Game(int sizeField)
            : this(sizeField, new List<BlockValues> { new BlockValues(90, 2), new BlockValues(10, 4) })
        {
        }

        public Game(int sizeField, List<BlockValues> blocksValues)
        {
            if (sizeField <= 1)
            {
                throw new ArgumentException("Incorrect field size value.", nameof(sizeField));
            }

            _randomGenerator = new RandomGenerator(blocksValues);
            _field = new Field(sizeField, _randomGenerator);
            _randomBlockValue = new RandomBlockValue(_field, _randomGenerator);
        }

        public void Run()
        {
            _field.Print();
            Console.WriteLine($"Очки:{_field.Scope}");
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }

                if (_field.Movement(key))
                {
                    _randomBlockValue.FillOneOfTheRandomCells();
                    Console.Clear();
                    _field.Print();
                    Console.WriteLine($"Очки:{_field.Scope}");
                }
            }
            while (_field.GameCheck());

            Console.WriteLine("Игра окончена!");
            Console.WriteLine($"Очки:{_field.Scope}");
            Console.ReadKey();
        }
    }
}
