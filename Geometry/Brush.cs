namespace MagmaWorks.Geometry
{
    public class Brush : IBrush
    {
        public ShadingType Shading { get; private set; }
        public IColor Color { get; private set; }

        public Brush(byte red, byte green, byte blue)
        {
            Shading = ShadingType.Solid;
            Color = new Color(255, red, green, blue);
        }

        public Brush(byte alpha, byte red, byte green, byte blue)
        {
            Shading = ShadingType.Solid;
            Color = new Color(alpha, red, green, blue);
        }
    }
}
