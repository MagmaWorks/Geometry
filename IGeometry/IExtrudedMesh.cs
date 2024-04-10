using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IExtrudedMesh : IGeometryBase
    {
        IEnumerable<IPoint3d> Points { get; }
        IVector3d Direction { get; }
    }
}
