using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ICartesian3d<Tx, Ty, Tz> : IGeometryBase
        where Tx : IQuantity where Ty : IQuantity where Tz : IQuantity
    {
        Tx X { get; }
        Ty Y { get; }
        Tz Z { get; }
    }
}
