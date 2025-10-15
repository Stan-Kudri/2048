using _2048.Extension;
using _2048.Model.Cell;
using System;


namespace _2048.Model
{
    public class Field
    {
        private const int StartFieldCells = 2;

        private readonly int[,] _items;

        private readonly Random _rnd = new Random();
        private readonly RandomGenerator _randomGenerator;

        private readonly Scope _scope = new Scope();

        public Field(int size, RandomGenerator generator)
        {
            _randomGenerator = generator;
            _items = new int[size, size];
            for (var i = 0; i < StartFieldCells; i++)
            {
                _items[_rnd.Next(size), _rnd.Next(size)] = _randomGenerator.RandomValue();
            }
        }

        public int this[int i, int j]
        {
            get => _items[i, j];
            set => _items[i, j] = value;
        }

        public int Scope => _scope.Value;

        public int Column => _items.GetLength(1);

        public int Row => _items.GetLength(0);

        public int[,] Items => _items;

        public bool GameCheck()
        {
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Column; j++)
                {
                    if (TryAddCellValues(i, j) || _items[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Movement(ConsoleKeyInfo key)
        {
            var isMoveField = false;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    for (var i = 0; i < Column; i++)
                    {
                        for (var j = 0; j < Row; j++)
                        {
                            for (var k = j + 1; k < Row; k++)
                            {
                                _items.MovedUpOrDownItems(i, j, k, ref isMoveField, _scope);
                            }
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    for (var i = 0; i < Column; i++)
                    {
                        for (var j = Row - 1; j >= 0; j--)
                        {
                            for (var k = j - 1; k >= 0; k--)
                            {
                                _items.MovedUpOrDownItems(i, j, k, ref isMoveField, _scope);
                            }
                        }
                    }
                    break;

                case ConsoleKey.RightArrow:
                    for (var i = 0; i < Row; i++)
                    {
                        for (var j = Column - 1; j >= 0; j--)
                        {
                            for (var k = j - 1; k >= 0; k--)
                            {
                                _items.MovedRightOrLeftItems(i, j, k, ref isMoveField, _scope);
                            }
                        }
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    for (var i = 0; i < Row; i++)
                    {
                        for (var j = 0; j < Column; j++)
                        {
                            for (var k = j + 1; k < Column; k++)
                            {
                                _items.MovedRightOrLeftItems(i, j, k, ref isMoveField, _scope);
                            }
                        }
                    }
                    break;
            }

            return isMoveField;
        }

        private bool TryAddCellValues(int row, int column)
        {
            if (column + 1 != Column && _items[row, column] == _items[row, column + 1])
            {
                return true;
            }

            if (row + 1 != Row && _items[row, column] == _items[row + 1, column])
            {
                return true;
            }

            return false;
        }
    }
}
