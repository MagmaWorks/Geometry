using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IModel3d : ICartesianModel3d<IMesh, IVertex, ICoordinate,
        IText3d, IPoint3d, IVector3d, Length, Length, Length, Length>
    {
        IEnumerable<IPolygon3d> Polygons { get; }
        IEnumerable<ILine3d> Lines { get; }
        IEnumerable<IPoint3d> Points { get; }
    }
}
