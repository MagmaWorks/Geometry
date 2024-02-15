using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IVector2d : IPoint2d
    {
        Length Length { get; }
    }
}
