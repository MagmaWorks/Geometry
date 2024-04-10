using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d : IGeometryBase
    {
        IEnumerable<IPoint2d> Points { get; }
    }
}
