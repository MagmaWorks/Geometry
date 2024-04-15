namespace MagmaWorks.Geometry
{
    public interface IBrush : IGeometryBase
    {
        ShadingType Shading { get; }
        IColor Color { get; }
    }
}
