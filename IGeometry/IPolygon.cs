using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon

    {
        List<IPoint3d> Points { get; }
    }
}
