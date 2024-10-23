namespace MagmaWorks.Geometry
{
    public interface IExtrema<T> : IGeometryBase
    {
        T Max { get; }
        T Min { get; }
    }
}
