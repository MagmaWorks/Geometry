using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPoint2d : IGeometry
    {
        Length X { get; }
        Length Y { get; }
    }
}
