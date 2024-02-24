namespace MagmaWorks.Geometry
{
    public interface IVertex : IPoint3d
    {
        IPoint2d TextureCoordinate { get; }
    }
}
