using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d : IGeometryBase, IPolygonBase<IDomain2d, IPoint2d>
    {
        IList<IPoint2d> Points { get; }
    }
}
