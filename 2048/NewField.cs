using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class NewField
    {
        private int[,] _items;


        public int this[int i, int j]
        {
            get
            {
                return _items[i, j];
            }
            set
            {
                _items[i, j] = value;
            }
        }

        public NewField(int size)
        {
            _items = new int[size, size];
            for (int i = 0; i < size; i++)
                _items[RandomUnfilledPlace.Value(size), RandomUnfilledPlace.Value(size)] = RandomValue.Value();
        }

        public NewField(int size, int r)
        {
            _items = new int[,] { { 2, 2, 4, 4 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        }

        public bool FreeCellCheck()
        {
            for (int i = 0; i < _items.GetLength(1); i++)
                for (int j = 0; j < _items.GetLength(0); j++)
                    if (_items[i, j] == 0)
                        return true;
            return false;
        }

        public void FreeCellRecording()
        {
            var list = new FreeCellCoordinates();
            for (int i = 0; i < _items.GetLength(1); i++)
                for (int j = 0; j < _items.GetLength(0); j++)
                    if (_items[i, j] == 0)
                        list.ListEntry(i, j);
            var point = list.RandomEmptyCell();
            _items[point._line, point._column] = RandomValue.Value();
        }


        public bool RandomCellForNumber()
        {
            for (int i = 0; i < 4; i++)
            {
                int line = RandomUnfilledPlace.Value(_items.GetLength(1));
                int column = RandomUnfilledPlace.Value(_items.GetLength(0));
                if (_items[line, column] == 0)
                {
                    _items[line, column] = RandomValue.Value();
                    return true;
                }
            }
            return false;
        }

        public void Movement(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    for (int i = 0; i < _items.GetLength(1); i++)
                        for (int j = 0; j < _items.GetLength(0); j++)
                            for (int k = j + 1; k < _items.GetLength(0); k++)
                            {
                                if ((_items[k, i] != 0))
                                {
                                    if (_items[j, i] == 0)
                                    {
                                        _items[j, i] = _items[k, i];
                                        _items[k, i] = 0;
                                    }
                                    else
                                    {
                                        if (_items[j, i] == _items[k, i])
                                        {
                                            _items[j, i] *= 2;
                                            _items[k, i] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.RightArrow:
                    for (int i = 0; i < _items.GetLength(1); i++)
                        for (int j = _items.GetLength(0) - 1; j >= 0; j--)
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if ((_items[i, k] != 0))
                                {
                                    if (_items[i, j] == 0)
                                    {
                                        _items[i, j] = _items[i, k];
                                        _items[i, k] = 0;
                                    }
                                    else
                                    {
                                        if (_items[i, j] == _items[i, k])
                                        {
                                            _items[i, j] *= 2;
                                            _items[i, k] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.DownArrow:
                    for (int i = 0; i < _items.GetLength(1); i++)
                        for (int j = _items.GetLength(0) - 1; j >= 0; j--)
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if ((_items[k, i] != 0))
                                {
                                    if (_items[j, i] == 0)
                                    {
                                        _items[j, i] = _items[k, i];
                                        _items[k, i] = 0;
                                    }
                                    else
                                    {
                                        if (_items[j, i] == _items[k, i])
                                        {
                                            _items[j, i] *= 2;
                                            _items[k, i] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;
                case ConsoleKey.LeftArrow:
                    for (int i = 0; i < _items.GetLength(1); i++)
                        for (int j = 0; j < _items.GetLength(0); j++)
                            for (int k = j + 1; k < _items.GetLength(0); k++)
                            {
                                if ((_items[i, k] != 0))
                                {
                                    if (_items[i, j] == 0)
                                    {
                                        _items[i, j] = _items[i, k];
                                        _items[i, k] = 0;
                                    }
                                    else
                                    {
                                        if (_items[i, j] == _items[i, k])
                                        {
                                            _items[i, j] *= 2;
                                            _items[i, k] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;
            }
        }

        private int FieldAfterMovement()
        {
            return 1;
        }
    }
}
