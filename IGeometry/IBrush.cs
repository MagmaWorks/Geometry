namespace MagmaWorks.Geometry
{
    public interface IBrush : IGeometry
    {
        ShadingType Shading { get; }
        IColor Color { get; }
    }
}
