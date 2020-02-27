using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class RandomGenerator
    {
        private List<Entity> _entities;
        private Random _rnd;

        public RandomGenerator()
        {
            _entities = new List<Entity>();
            _rnd = new Random();
        }

        public RandomGenerator Add(int value, double probability)
        {
            _entities.Add(new Entity(probability, value));
            _entities.Sort(new EntityComparer());
            return this;
        }

        public int RandomValue()
        {
            var currentRandomProbability = _rnd.NextDouble() * SumProbability();
            var probability = 0.0;
            foreach (var entity in _entities)
            {
                probability += entity.Probability;
                if (probability >= currentRandomProbability)
                    return entity.Value;
            }
            return 0;
        }

        private double SumProbability()
        {
            var p = 0.0;
            foreach (var e in _entities)
                p += e.Probability;
            return p;
        }

        class EntityComparer : IComparer<Entity>
        {
            public int Compare(Entity x, Entity y)
            {
                var xProbability = x.Probability;
                var yProbability = y.Probability;
                return xProbability.CompareTo(yProbability);
            }
        }

        class Entity
        {
            public double Probability { get; }
            public int Value { get; }

            public Entity(double probability, int value)
            {
                Probability = probability;
                Value = value;
            }
        }
    }

    

    
}
