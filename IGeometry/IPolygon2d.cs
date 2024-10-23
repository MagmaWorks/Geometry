using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d : IGeometryBase, IPolygonBase
    {
        IList<IPoint2d> Points { get; }
    }
}
