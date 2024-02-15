namespace MagmaWorks.Geometry
{
    public class Node : INode
    {
        public IPoint3d Point { get; private set; }
        public IPoint2d TextureCoordinate { get; private set; }

        public Node(IPoint3d point, IPoint2d textureCoords)
        {
            Point = point;
            TextureCoordinate = textureCoords;
        }
    }
}
