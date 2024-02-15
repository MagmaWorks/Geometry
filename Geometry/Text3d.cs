namespace MagmaWorks.Geometry
{
    public class Text3d : IText3d
    {
        public IPoint3d Position { get; private set; }
        public double Height { get; private set; }
        public string Text { get; private set; }
        public IVector3d Direction { get; private set; }
        public IVector3d Up { get; private set; } = Vector3d.UnitZ;
        public bool IsDoubleSided { get; private set; } = true;
        public IColor Color { get; private set; } = new Color(255, 0, 0, 0);
        public VerticalAlignment VerticalAlignment { get; private set; } = VerticalAlignment.Centre;
        public HorizontalAlignment HorizontalAlignment { get; private set; } = HorizontalAlignment.Centre;

        public Text3d(string text, IPoint3d position, IVector3d direction, double height)
        {
            Position = position;
            Direction = direction;
            Text = text;
            Height = height;
        }

        public Text3d(string text, IPoint3d position, IVector3d direction, double height, IVector3d up)
        {
            Position = position;
            Direction = direction;
            Text = text;
            Height = height;
            Up = up;
        }
    }
}
