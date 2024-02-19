using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILine3d : IGeometry
    {
        IPoint3d Start { get; }
        IPoint3d End { get; }
    }
}
