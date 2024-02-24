using System;
using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry.Utility
{
    internal static class LengthEquatable
    {
        internal static bool IsEqual(this Length length, Length other, double tolerance = 0)
        {
            double otherAsLengthUnit = other.As(length.Unit);
            double difference = Math.Abs(length.Value - otherAsLengthUnit);
            return difference <= tolerance;
        }

        internal static bool IsEqual(this List<Length> lengths, List<Length> others, double tolerance = 0)
        {
            if (lengths.Count != others.Count)
            {
                return false;
            }


            for (int i = 0; i < lengths.Count; i++)
            {
                if (lengths[i].IsEqual(others[i]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
