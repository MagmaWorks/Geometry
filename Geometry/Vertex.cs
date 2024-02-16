namespace MagmaWorks.Geometry
{
    public class Vertex : IVertex
    {
        public IPoint3d Point { get; private set; }
        public IPoint2d TextureCoordinate { get; private set; }

        public Vertex(IPoint3d point, IPoint2d textureCoords)
        {
            Point = point;
            TextureCoordinate = textureCoords;
        }
    }
}
