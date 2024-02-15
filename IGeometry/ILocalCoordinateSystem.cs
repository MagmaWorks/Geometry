using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalCoordinateSystem
    {
        IVector3d XAxis { get; }
        IVector3d YAxis { get; }
        IVector3d ZAxis { get; }
        IPoint3d Origin { get; }
    }
}
