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
        public int Row { get => items.GetLength(0); }        

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
        
        public Field(int size)
        {
            items = new int[size, size];
            for (int i = 0; i < size; i++)
                items[RandomValue.Value(size), RandomValue.Value(size)] = RandomValue.Tile(this.valuetiles);
        }
        
        public void CellFilling()
        {
            var list = new EmptyTile();
            list.Tile(items);
            var point = list.RandomEmptyCell();
            items[point.Row, point.Column] = RandomValue.Tile(this.valuetiles);
        }
               
        public bool RandomCellFilling()
        {
            for (int i = 0; i < 4; i++)
            {
                int row = RandomValue.Value(Row);
                int column = RandomValue.Value(Column);
                if (items[row, column] == 0)
                {
                    items[row, column] = RandomValue.Tile(this.valuetiles);
                    return true;
                }
            }
            return false;
        }
        
        public bool GameCheck()
        {
            for(int i = 0; i < Row; i++)
                for(int j = 0; j < Column; j++)
                {
                    if ( (j + 1 != Column) && (items[i, j] == items[i, j + 1])  )
                        return true;
                    if ( (i + 1 != Row) && (items[i, j] == items[i + 1, j]))
                        return true;
                    if (items[i, j] == 0)
                        return true;
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
                                if ((items[k, i] != 0))
                                {
                                    if (items[j, i] == 0)
                                    {
                                        items[j, i] = items[k, i];
                                        items[k, i] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (items[j, i] == items[k, i])
                                        {
                                            items[j, i] *= 2;
                                            items[k, i] = 0;
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
                                if ((items[i, k] != 0))
                                {
                                    if (items[i, j] == 0)
                                    {
                                        items[i, j] = items[i, k];
                                        items[i, k] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (items[i, j] == items[i, k])
                                        {
                                            items[i, j] *= 2;
                                            items[i, k] = 0;
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
                                if ((items[k, i] != 0))
                                {
                                    if (items[j, i] == 0)
                                    {
                                        items[j, i] = items[k, i];
                                        items[k, i] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (items[j, i] == items[k, i])
                                        {
                                            items[j, i] *= 2;
                                            items[k, i] = 0;
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
                                if ((items[i, k] != 0))
                                {
                                    if (items[i, j] == 0)
                                    {
                                        items[i, j] = items[i, k];
                                        items[i, k] = 0;
                                        check = true;
                                    }
                                    else
                                    {
                                        if (items[i, j] == items[i, k])
                                        {
                                            items[i, j] *= 2;
                                            items[i, k] = 0;
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
