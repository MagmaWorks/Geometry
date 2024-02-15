using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IMesh
    {
        IList<int[]> MeshIndices { get; }
        IList<INode> Nodes { get; }
        double Opacity { get; set; }
        IBrush Brush { get; set; }
    }
}
