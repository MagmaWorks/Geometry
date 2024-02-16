using System.Collections.Generic;
using System.Linq;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public class Polygon3d : IPolygon3d
    {
        public IList<IPoint3d> Points { get; set; }

        public Polygon3d(IList<IPoint3d> points)
        {
            Points = points;
        }

        public Point3d GetBarycenter()
        {
            return Point3d.GetBarycenter(Points);
        }

        public bool IsInsidePlane(IPoint3d p)
        {
            return Point3d.IsInsidePlane(p, Points);
        }

        public static Point3d PlaneLineIntersection(IPolygon3d line, IPolygon3d plane, bool within = true)
        {
            return Point3d.PlaneLineIntersection(line.Points, plane.Points, within);
        }
    }
}
