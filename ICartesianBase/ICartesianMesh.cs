using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ICartesianMesh<TVertex, TCoordinate, Tx, Ty, Tz> : IGeometryBase
        where TVertex : ICartesianVertex<TCoordinate, Tx, Ty, Tz>
        where TCoordinate : ICoordinate
        where Tx : IQuantity where Ty : IQuantity where Tz : IQuantity
    {
        IList<int[]> MeshIndices { get; }
        IList<TVertex> Verticies { get; }
        double Opacity { get; set; }
        IBrush Brush { get; set; }
    }
}
