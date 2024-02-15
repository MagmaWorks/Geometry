using System;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPoint3d
    {
        Length X { get; }
        Length Y { get; }
        Length Z { get; }
    }
}
