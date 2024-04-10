using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon3d<T> : IGeometryBase
        where T : IEnumerable<IPoint3d>
    {
         T Points { get; }
    }
}
