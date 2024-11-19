using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalPolyline2d : IGeometryBase, IPolylineBase<ILocalDomain2d, ILocalPoint2d>
    {
        IList<ILocalPoint2d> Points { get; }
        bool IsClockwise();
        ILocalPolyline2d Offset(Length distance);
    }
}
