using System;


namespace _2048.Model
{
    public class Field
    {
        private const int FieldCells = 2;
        private const int RandomCellFillAttempts = 4;

        private readonly int[,] _items;

        private readonly Random _rnd = new Random();

        private readonly RandomGenerator _randomGenerator;

        public int this[int i, int j]
        {
            get => _items[i, j];
            set => _items[i, j] = value;
        }

        public Field(int size, RandomGenerator generator)
        {
            _randomGenerator = generator;
            _items = new int[size, size];
            for (var i = 0; i < FieldCells; i++)
            {
                _items[_rnd.Next(size), _rnd.Next(size)] = _randomGenerator.RandomValue();
            }
        }

        public int Column => _items.GetLength(1);

        public int Row => _items.GetLength(0);

        public double Points()
        {
            var summ = 0;
            foreach (var item in _items)
            {
                summ += item;
            }

            return summ;
        }

        public void FillingTheEmptyCellValue()
        {
            var list = new FreeCell();
            list.Cell(_items);
            var point = list.RandomEmptyCell();
            _items[point.Row, point.Column] = _randomGenerator.RandomValue();
        }

        public void FillOneOfTheRandomCells()
        {
            for (int i = 0; i < RandomCellFillAttempts; i++)
            {
                var row = _rnd.Next(Row);
                var column = _rnd.Next(Column);

                if (_items[row, column] == 0)
                {
                    _items[row, column] = _randomGenerator.RandomValue();
                    return;
                }
            }

            FillingTheEmptyCellValue();
        }

        public bool GameCheck()
        {
            for (var i = 0; i < Row; i++)
            {
                for (var j = 0; j < Column; j++)
                {
                    if (TryAddingCellValues(i, j) || _items[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Movement(ConsoleKeyInfo key)
        {
            var check = false;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    for (var i = 0; i < Column; i++)
                        for (var j = 0; j < Row; j++)
                            for (var k = j + 1; k < Row; k++)
                            {
                                if (_items[k, i] != 0)
                                {
                                    if (_items[j, i] == 0)
                                    {
                                        _items[j, i] = _items[k, i];
                                        _items[k, i] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (_items[j, i] == _items[k, i])
                                        {
                                            _items[j, i] *= 2;
                                            _items[k, i] = 0;
                                            check = true;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.DownArrow:
                    for (var i = 0; i < Column; i++)
                        for (var j = Row - 1; j >= 0; j--)
                            for (var k = j - 1; k >= 0; k--)
                            {
                                if (_items[k, i] != 0)
                                {
                                    if (_items[j, i] == 0)
                                    {
                                        _items[j, i] = _items[k, i];
                                        _items[k, i] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (_items[j, i] == _items[k, i])
                                        {
                                            _items[j, i] *= 2;
                                            _items[k, i] = 0;
                                            check = true;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.RightArrow:
                    for (var i = 0; i < Row; i++)
                        for (var j = Column - 1; j >= 0; j--)
                            for (var k = j - 1; k >= 0; k--)
                            {
                                if (_items[i, k] != 0)
                                {
                                    if (_items[i, j] == 0)
                                    {
                                        _items[i, j] = _items[i, k];
                                        _items[i, k] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (_items[i, j] == _items[i, k])
                                        {
                                            _items[i, j] *= 2;
                                            _items[i, k] = 0;
                                            check = true;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.LeftArrow:
                    for (var i = 0; i < Row; i++)
                        for (var j = 0; j < Column; j++)
                            for (var k = j + 1; k < Column; k++)
                            {
                                if (_items[i, k] != 0)
                                {
                                    if (_items[i, j] == 0)
                                    {
                                        _items[i, j] = _items[i, k];
                                        _items[i, k] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (_items[i, j] == _items[i, k])
                                        {
                                            _items[i, j] *= 2;
                                            _items[i, k] = 0;
                                            check = true;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;
            }
            return check;
        }

        private bool TryAddingCellValues(int row, int column)
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
