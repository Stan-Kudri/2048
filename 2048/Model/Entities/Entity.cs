namespace _2048.Model.Entities
{
    public partial class RandomGenerator
    {
        public class Entity
        {
            public Entity(double probability, int value)
            {
                Probability = probability;
                Value = value;
            }

            public double Probability { get; }

            public int Value { get; }

        }
    }




}
