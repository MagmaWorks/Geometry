using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IVector3d : IPoint3d
    {
        Length Length { get; }
    }
}
