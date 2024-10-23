using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d : IGeometryBase, IPolygonBase<ILocalDomain2d, ILocalPoint2d>
    {
        IList<ILocalPoint2d> Points { get; }
    }
}
