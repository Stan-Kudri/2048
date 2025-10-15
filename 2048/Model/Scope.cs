namespace _2048.Model
{
    public class Scope
    {
        private const int CellMultiplier = 2;

        public int Value { get; private set; } = 0;

        public void AddPoints(int cellValue) => Value += CellMultiplier * cellValue;
    }
}
