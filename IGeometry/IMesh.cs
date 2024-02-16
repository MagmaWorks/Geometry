using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IMesh : IGeometry
    {
        IList<int[]> MeshIndices { get; }
        IList<IVertex> Nodes { get; }
        double Opacity { get; set; }
        IBrush Brush { get; set; }
    }
}
