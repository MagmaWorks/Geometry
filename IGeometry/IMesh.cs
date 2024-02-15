using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IMesh
    {
        List<int[]> MeshIndices { get; }
        List<INode> Nodes { get; }
        double Opacity { get; set; }
        IBrush Brush { get; set; }
    }
}
