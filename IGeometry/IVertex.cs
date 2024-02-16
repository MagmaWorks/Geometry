namespace MagmaWorks.Geometry
{
    public interface IVertex : IGeometry
    {
        IPoint3d Point { get; }
        IPoint2d TextureCoordinate { get; }
    }
}
