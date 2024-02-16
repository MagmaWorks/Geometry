using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d : IGeometry
    {
        IList<ILocalPoint2d> Points { get; }
    }
}
