using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d : IGeometry
    {
        IList<IPoint2d> Points { get; }
    }
}
