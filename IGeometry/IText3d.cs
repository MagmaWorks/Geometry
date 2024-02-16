namespace MagmaWorks.Geometry
{
    public interface IText3d : IGeometry
    {
        IPoint3d Position { get; }
        IVector3d Direction { get; }
        IVector3d Up { get; }
        double Height { get; }
        bool IsDoubleSided { get; }
        string Text { get; }
        VerticalAlignment VerticalAlignment { get; }
        HorizontalAlignment HorizontalAlignment { get; }
        IColor Color { get; }
    }
}
