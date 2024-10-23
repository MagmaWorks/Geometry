using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface IPolygonBase<D, T> where D : IExtrema<T>
    {
        bool IsClosed { get; }
        D Domain();
    }
}
