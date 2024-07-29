namespace _2048.Model.Entities
{
    public partial class RandomGenerator
    {
        public class Entity
        {
            private readonly double _probability;
            private readonly int _value;

            public Entity(double probability, int value)
            {
                _probability = probability;
                _value = value;
            }

            public double Probability => _probability;

            public int Value => _value;
        }
    }




}
