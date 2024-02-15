using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d
    {
        List<IPoint2d> Points { get; }
    }
}
