using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IIntersectionResult
    {
        IntersectionType IntersectionType { get; }
        IPoint2d Point { get; }
    }
}
