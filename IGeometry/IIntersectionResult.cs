namespace MagmaWorks.Geometry
{
    public interface IIntersectionResult : IGeometry
    {
        IntersectionType IntersectionType { get; }
        IPoint2d Point { get; }
    }
}
