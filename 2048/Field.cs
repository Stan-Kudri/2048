using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2048
{
    public class Field
    {
        private int[,] items;
        private int[] valuetiles = new int[] { 2, 4 };

        public int Column { get => items.GetLength(1); }
        public int Line { get => items.GetLength(0); }

        public int[] ValueTiles { get => valuetiles; set => valuetiles = value; }

        public int this[int i, int j]
        {
            get
            {
                return items[i, j];
            }
            set
            {
                items[i, j] = value;
            }
        }

        public void Conclusion()
        {
            for (int i = 0; i < Line; i++)
            {
                for (int j = 0; j < Column; j++)
                    Console.Write(items[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Field(int size)
        {
            items = new int[size, size];
            for (int i = 0; i < size; i++)
                items[RandomValue.Value(size), RandomValue.Value(size)] = RandomValue.Tile(this.valuetiles);
        }


        public bool CellCheck()
        {
            for (int i = 0; i < Line; i++)
                for (int j = 0; j < Column; j++)
                    if (items[i, j] == 0)
                        return true;
            return false;
        }

        public void CellFilling()
        {
            var list = new EmptyTile();
            list.Tile(items);
            var point = list.RandomEmptyCell();
            items[point.Line, point.Column] = RandomValue.Tile(this.valuetiles);
        }


        public bool RandomCellFilling()
        {
            for (int i = 0; i < 4; i++)
            {
                int line = RandomValue.Value(Line);
                int column = RandomValue.Value(Column);
                if (items[line, column] == 0)
                {
                    items[line, column] = RandomValue.Tile(this.valuetiles);
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
                    for (int i = 0; i < Column; i++)
                        for (int j = 0; j < Line; j++)
                            for (int k = j + 1; k < Line; k++)
                            {
                                if ((items[k, i] != 0))
                                {
                                    if (items[j, i] == 0)
                                    {
                                        items[j, i] = items[k, i];
                                        items[k, i] = 0;
                                    }
                                    else
                                    {
                                        if (items[j, i] == items[k, i])
                                        {
                                            items[j, i] *= 2;
                                            items[k, i] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.RightArrow:
                    for (int i = 0; i < Line; i++)
                        for (int j = Column - 1; j >= 0; j--)
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if ((items[i, k] != 0))
                                {
                                    if (items[i, j] == 0)
                                    {
                                        items[i, j] = items[i, k];
                                        items[i, k] = 0;
                                    }
                                    else
                                    {
                                        if (items[i, j] == items[i, k])
                                        {
                                            items[i, j] *= 2;
                                            items[i, k] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;

                case ConsoleKey.DownArrow:
                    for (int i = 0; i < Column; i++)
                        for (int j = Line - 1; j >= 0; j--)
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if ((items[k, i] != 0))
                                {
                                    if (items[j, i] == 0)
                                    {
                                        items[j, i] = items[k, i];
                                        items[k, i] = 0;
                                    }
                                    else
                                    {
                                        if (items[j, i] == items[k, i])
                                        {
                                            items[j, i] *= 2;
                                            items[k, i] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;
                case ConsoleKey.LeftArrow:
                    for (int i = 0; i < Line; i++)
                        for (int j = 0; j < Column; j++)
                            for (int k = j + 1; k < Column; k++)
                            {
                                if ((items[i, k] != 0))
                                {
                                    if (items[i, j] == 0)
                                    {
                                        items[i, j] = items[i, k];
                                        items[i, k] = 0;
                                    }
                                    else
                                    {
                                        if (items[i, j] == items[i, k])
                                        {
                                            items[i, j] *= 2;
                                            items[i, k] = 0;
                                        }
                                        break;
                                    }
                                }
                            }
                    break;
            }
        }

    }
}
