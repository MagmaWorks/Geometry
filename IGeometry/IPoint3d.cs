using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPoint3d : IGeometry
    {
        Length X { get; }
        Length Y { get; }
        Length Z { get; }
    }
}
