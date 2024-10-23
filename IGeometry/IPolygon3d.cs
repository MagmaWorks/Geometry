using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon3d : IGeometryBase, IPolygonBase
    {
        IList<IPoint3d> Points { get; }
    }
}
