using System;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalPoint2d : IGeometry
    {
        Length Y { get; }
        Length Z { get; }
    }
}
