using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d
    {
        IList<ILocalPoint2d> Points { get; }
    }
}
