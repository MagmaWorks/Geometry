using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d
    {
        List<ILocalPoint2d> Points { get; }
    }
}
