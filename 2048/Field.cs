using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2048
{
    public class Field
    {
        private int[,] _items;

        public int Column { get => _items.GetLength(1); }
        public int Row { get => _items.GetLength(0); }
        
        private Random _rnd = new Random();

        private RandomGenerator _randomGenerator; 
        
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
        
        public Field(int size, RandomGenerator generator)
        {
            _randomGenerator = generator;
            var filledCells = 2;
            _items = new int[size, size];
            for (int i = 0; i < filledCells; i++)
                _items[_rnd.Next(size), _rnd.Next(size)] = _randomGenerator.RandomValue();
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
            var maxTry = 4;
            bool check = false;
            for (int i = 0; i < maxTry; i++)
            {
                int row = _rnd.Next(Row);
                int column = _rnd.Next(Column);
                if (_items[row, column] == 0)
                {
                    _items[row, column] = _randomGenerator.RandomValue();
                    check = true;
                    break;
                }
            }
            if(!check)
                FillingTheEmptyCellValue();
        }
        
        public bool GameCheck()
        {
            for(int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    if ((j + 1 != Column) && (_items[i, j] == _items[i, j + 1]))
                        return true;
                    if ((i + 1 != Row) && (_items[i, j] == _items[i + 1, j]))
                        return true;
                    if (_items[i, j] == 0)
                        return true;
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
                    for (int i = 0; i < Column; i++)
                        for (int j = 0; j < Row; j++)
                            for (int k = j + 1; k < Row; k++)
                            {
                                if ((_items[k, i] != 0))
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
                    for (int i = 0; i < Row; i++)
                        for (int j = Column - 1; j >= 0; j--)
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if ((_items[i, k] != 0))
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

                case ConsoleKey.DownArrow:
                    for (int i = 0; i < Column; i++)
                        for (int j = Row - 1; j >= 0; j--)
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if ((_items[k, i] != 0))
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

                case ConsoleKey.LeftArrow:
                    for (int i = 0; i < Row; i++)
                        for (int j = 0; j < Column; j++)
                            for (int k = j + 1; k < Column; k++)
                            {
                                if ((_items[i, k] != 0))
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

    }
}
