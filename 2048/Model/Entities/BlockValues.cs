namespace _2048.Model.Entities
{
    public class BlockValues
    {
        private readonly double _probability;
        private readonly int _value;

        public BlockValues(double probability, int value)
        {
            _probability = probability;
            _value = value;
        }

        public double Probability => _probability;

        public int Value => _value;
    }
}
