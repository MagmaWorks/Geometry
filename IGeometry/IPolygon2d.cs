using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d : IGeometryBase
    {
        IList<IPoint2d> Points { get; }
    }
}
