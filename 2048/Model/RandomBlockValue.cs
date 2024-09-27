using _2048.Model.Cell;
using System;

namespace _2048.Model.Entities
{
    public class RandomBlockValue
    {
        private const int RandomCellFillAttempts = 4;

        private readonly Random _rnd = new Random();
        private readonly RandomGenerator _randomGenerator;
        private readonly Field _field;

        public RandomBlockValue(Field field, RandomGenerator randomGenerator)
        {
            _field = field;
            _randomGenerator = randomGenerator;
        }

        public void FillOneOfTheRandomCells()
        {
            for (int i = 0; i < RandomCellFillAttempts; i++)
            {
                var row = _rnd.Next(_field.Row);
                var column = _rnd.Next(_field.Column);

                if (_field[row, column] == 0)
                {
                    _field[row, column] = _randomGenerator.RandomValue();
                    return;
                }
            }

            FillingTheEmptyCellValue();
        }

        private void FillingTheEmptyCellValue()
        {
            var list = new FreeCell();
            list.Cell(_field.Items);
            var point = list.RandomEmptyCell();
            _field[point.Row, point.Column] = _randomGenerator.RandomValue();
        }
    }
}
