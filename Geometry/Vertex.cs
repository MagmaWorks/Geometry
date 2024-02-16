namespace MagmaWorks.Geometry
{
    public class Vertex : IVertex
    {
        public IPoint3d Point { get; set; }
        public IPoint2d TextureCoordinate { get; set; }

        public Vertex(IPoint3d point, IPoint2d textureCoords)
        {
            Point = point;
            TextureCoordinate = textureCoords;
        }
    }
}
