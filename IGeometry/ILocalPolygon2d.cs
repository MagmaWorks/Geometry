using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d : IGeometryBase
    {
        IEnumerable<ILocalPoint2d> Points { get; }
    }
}
