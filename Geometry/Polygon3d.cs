using System;
using System.Collections.Generic;
using MagmaWorks.Geometry.Utility.Extensions;

namespace MagmaWorks.Geometry
{
    public class Polygon3d : IPolygon3d<IList<Point3d>>
    {
        public IList<Point3d> Points { get; set; }

        public Polygon3d(IList<Point3d> points)
        {
            if (points.IsNullOrEmpty() || points.Count < 2)
            {
                throw new ArgumentException("List must contain two or more points");
            }

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

        public static Point3d PlaneLineIntersection(Polygon3d line, Polygon3d plane, bool within = true)
        {
            return Point3d.PlaneLineIntersection(line.Points, plane.Points, within);
        }

        public static explicit operator Line3d(Polygon3d polygon)
        {
            if (polygon.Points.Count != 2)
            {
                throw new InvalidCastException("Only a Polygon with two points can be cast to a Line");
            }

            return new Line3d(polygon.Points[0], polygon.Points[1]);
        }
    }
}
