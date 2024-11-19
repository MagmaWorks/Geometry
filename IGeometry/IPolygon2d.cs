using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPolygon2d : IGeometryBase, IPolygonBase<IDomain2d, IPoint2d>
    {
        IList<IPoint2d> Points { get; }
        bool IsClockwise();
        IPolygon2d Offset(Length distance);
    }
}
