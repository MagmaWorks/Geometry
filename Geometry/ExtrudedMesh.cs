using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public class ExtrudedMesh : IExtrudedMesh
    {
        public IList<IPoint3d> Points { get; private set; }
        public IVector3d Direction { get; private set; }

        public ExtrudedMesh(IList<IPoint3d> points, IVector3d direction)
        {
            Points = points;
            Direction = direction;
        }
    }
}
