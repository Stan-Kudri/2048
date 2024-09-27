using _2048.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2048.Model.Cell
{
    public class RandomGenerator
    {
        private readonly List<BlockValues> _entities = new List<BlockValues>();
        private readonly Random _rnd = new Random();

        public RandomGenerator(List<BlockValues> blocksValues)
        {
            if (blocksValues.Sum(e => e.Probability) != 100)
            {
                throw new ArgumentException("The total probability of all values ​​is not 100%.");
            }

            foreach (var item in blocksValues)
            {
                Add(item.Value, item.Probability);
            }
        }

        public RandomGenerator Add(int value, double probability)
        {
            _entities.Add(new BlockValues(probability, value));
            _entities.Sort(new BlockValuesComparer());
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
