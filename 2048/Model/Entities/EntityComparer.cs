using System.Collections.Generic;

namespace _2048.Model.Entities
{
    public partial class RandomGenerator
    {
        public class EntityComparer : IComparer<Entity>
        {
            public int Compare(Entity x, Entity y)
                => x.Probability.CompareTo(y.Probability);
        }
    }
}
