using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ILocalPoint2d : IGeometryBase
    {
        Length Y { get; }
        Length Z { get; }
    }
}
