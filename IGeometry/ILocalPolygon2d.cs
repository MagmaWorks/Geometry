using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolygon2d : IGeometryBase, IPolygonBase<ILocalDomain2d, ILocalPoint2d>
    {
        IList<ILocalPoint2d> Points { get; }
        bool IsClockwise();
        ILocalPolygon2d Offset(Length distance);
    }
}
