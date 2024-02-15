using System;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalPoint2d : IEquatable<IPoint2d>
    {
        Length Y { get; }
        Length Z { get; }
    }
}
