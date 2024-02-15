using System;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface INode
    {
        IPoint3d Point { get; }
        IPoint2d TextureCoordinate { get; }
    }
}
