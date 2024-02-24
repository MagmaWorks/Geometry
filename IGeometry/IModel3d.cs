using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IModel3d : IGeometry
    {
        IList<IMesh> Meshes { get; }
        IList<IText3d> Texts { get; }
    }
}
