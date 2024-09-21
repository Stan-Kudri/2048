namespace _2048.Extension
{
    public static class MoveByPressingArrowExtension
    {
        public static void MovedUpOrDownItems(this int[,] items, int columnNumber, int rowNumber, int nextRowNumber, ref bool isMoveField)
        {
            if (items[nextRowNumber, columnNumber] != 0)
            {
                if (items[rowNumber, columnNumber] == 0)
                {
                    items[rowNumber, columnNumber] = items[nextRowNumber, columnNumber];
                    items[nextRowNumber, columnNumber] = 0;
                    isMoveField = true;
                }
                else
                {
                    if (items[rowNumber, columnNumber] == items[nextRowNumber, columnNumber])
                    {
                        items[rowNumber, columnNumber] *= 2;
                        items[nextRowNumber, columnNumber] = 0;
                        isMoveField = true;
                    }

                    return;
                }
            }
        }

        public static void MovedRightOrLeftItems(this int[,] items, int rowNumber, int columnNumber, int nextColumnNumber, ref bool isMoveField)
        {
            if (items[rowNumber, nextColumnNumber] != 0)
            {
                if (items[rowNumber, columnNumber] == 0)
                {
                    items[rowNumber, columnNumber] = items[rowNumber, nextColumnNumber];
                    items[rowNumber, nextColumnNumber] = 0;
                    isMoveField = true;
                }
                else
                {
                    if (items[rowNumber, columnNumber] == items[rowNumber, nextColumnNumber])
                    {
                        items[rowNumber, columnNumber] *= 2;
                        items[rowNumber, nextColumnNumber] = 0;
                        isMoveField = true;
                    }

                    return;
                }
            }
        }
    }
}
