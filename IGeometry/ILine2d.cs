using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILine2d : IGeometry
    {
        IPoint2d Start { get; }
        IPoint2d End { get; }
    }
}
