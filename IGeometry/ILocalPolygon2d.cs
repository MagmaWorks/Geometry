using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d : IGeometryBase, IPolygonBase
    {
        IList<ILocalPoint2d> Points { get; }
    }
}
