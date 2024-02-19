using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public class Line2d : ILine2d
    {
        public IPoint2d Start { get; set; }
        public IPoint2d End { get; set; }

        public Line2d(IPoint2d start, IPoint2d end)
        {
            Start = start;
            End = end;
        }

        public static implicit operator Polygon2d(Line2d ln)
        {
            return new Polygon2d(new List<IPoint2d> { ln.Start, ln.End });
        }

        public static implicit operator Vector2d(Line2d ln)
        {
            return (Point2d)ln.Start - (Point2d)ln.End;
        }
    }
}
