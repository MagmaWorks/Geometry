using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon3d : IGeometryBase
    {
        IList<IPoint3d> Points { get; }
    }
}
