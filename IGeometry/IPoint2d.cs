using System;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPoint2d : IEquatable<IPoint2d>
    {
        Length X { get; }
        Length Y { get; }
    }
}
