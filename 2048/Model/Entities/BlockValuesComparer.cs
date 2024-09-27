using System.Collections.Generic;

namespace _2048.Model.Entities
{
    public class BlockValuesComparer : IComparer<BlockValues>
    {
        public int Compare(BlockValues x, BlockValues y)
            => x.Probability.CompareTo(y.Probability);
    }
}
