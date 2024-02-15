namespace MagmaWorks.Geometry
{
    public interface IBrush
    {
        ShadingType Shading { get; }
        IColor Color { get; }
    }
}
