using System;
using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IModel3d
    {
        List<IMesh> Meshes { get; }
        List<IText3d> Texts { get; }
    }
}
