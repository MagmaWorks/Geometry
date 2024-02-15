using System.Collections.Generic;
using System.Linq;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public class Model3d : IModel3d
    {
        public IList<IMesh> Meshes { get; private set; }
        public IList<IText3d> Texts { get; private set; }

        public Model3d(IMesh mesh)
        {
            Meshes = new List<IMesh> { mesh };
            Texts = new List<IText3d>();
        }

        public Point3d GetMinimumCorner()
        {
            Length x = Meshes.SelectMany(a => a.Nodes).Min(b => b.Point.X);
            Length y = Meshes.SelectMany(a => a.Nodes).Min(b => b.Point.Y);
            Length z = Meshes.SelectMany(a => a.Nodes).Min(b => b.Point.Z);
            return new Point3d(x, y, z);
        }

        public Point3d GetMaximumCorner()
        {
            Length x = Meshes.SelectMany(a => a.Nodes).Max(b => b.Point.X);
            Length y = Meshes.SelectMany(a => a.Nodes).Max(b => b.Point.Y);
            Length z = Meshes.SelectMany(a => a.Nodes).Max(b => b.Point.Z);
            return new Point3d(x, y, z);
        }
    }
}
