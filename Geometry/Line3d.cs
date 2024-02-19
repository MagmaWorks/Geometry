using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public class Line3d : ILine3d
    {
        public IPoint3d Start { get; set; }
        public IPoint3d End { get; set; }

        public Line3d(IPoint3d start, IPoint3d end)
        {
            Start = start;
            End = end;
        }

        public static implicit operator Polygon3d(Line3d ln)
        {
            return new Polygon3d(new List<IPoint3d> { ln.Start, ln.End });
        }

        public static implicit operator Vector3d(Line3d ln)
        {
            return (Point3d)ln.Start - (Point3d)ln.End;
        }
    }
}
