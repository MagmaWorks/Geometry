using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPolyline2d : IGeometryBase, IPolylineBase<IDomain2d, IPoint2d>
    {
        IList<IPoint2d> Points { get; }
        bool IsClockwise();
        IPolyline2d Offset(Length distance);
    }
}
