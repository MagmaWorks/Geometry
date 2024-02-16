using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon3d : IGeometry

    {
        IList<IPoint3d> Points { get; }
    }
}
