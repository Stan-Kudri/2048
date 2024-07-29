using System;
using System.Collections.Generic;
using System.Linq;
using static _2048.Model.Entities.RandomGenerator;

namespace _2048
{
    public partial class RandomGenerator
    {
        private readonly List<Entity> _entities = new List<Entity>();
        private readonly Random _rnd = new Random();

        public RandomGenerator Add(int value, double probability)
        {
            _entities.Add(new Entity(probability, value));
            _entities.Sort(new EntityComparer());
            return this;
        }

        public int RandomValue()
        {
            var currentRandomProbability = _rnd.NextDouble() * _entities.Sum(s => s.Probability);
            var probability = 0.0;
            foreach (var entity in _entities)
            {
                probability += entity.Probability;
                if (probability >= currentRandomProbability)
                {
                    return entity.Value;
                }
            }

            return 0;
        }
    }
}
