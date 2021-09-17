using System.Collections.Generic;

namespace OptimalCuts
{
    public class PieceSizeComparer : Comparer<Piece>
    {
        // private const int _decFactor;
        private int _decFactor;

        public PieceSizeComparer(bool isDecreasing)
        {
            _decFactor = isDecreasing ? -1 : 1;
        }

        public override int Compare(Piece c1, Piece c2)
        {
            if (c1 == null && c2 == null)
            {
                return 0;
            }

            if (c1 != null && c2 == null)
            {
                return -1;
            }

            // FIXME: "c2 != null" would always be true!
            // By here, we've already returned for cases where both are null and the inverse of the following condition.
            if (c1 == null && c2 != null)
            {
                return 1;
            }

            // FIXME: Equality comparison of floating point numbers, possible loss of precision while rounding values! 
            if (c1._width != c2._width)
            {
                return (int)((c1._width - c2._width) * _decFactor);
            }

            return (int)((c1._length - c2._length) * _decFactor);
        }
    }
}