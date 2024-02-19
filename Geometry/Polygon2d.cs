using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry.Utility.Extensions;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public class Polygon2d : IPolygon2d
    {
        public IList<IPoint2d> Points { get; set; }

        public Polygon2d(IList<IPoint2d> points)
        {
            if (points.IsNullOrEmpty() || points.Count < 2)
            {
                throw new ArgumentException("List must contain two or more points");
            }

            Points = points;
        }

        public Polygon2d Contract(double factor)
        {
            return new Polygon2d(Point2d.Contract(Points, factor));
        }

        public Polygon2d Extend(double factor)
        {
            return new Polygon2d(Point2d.Extend(Points, factor));
        }

        public Area GetArea()
        {
            return Point2d.GetPolygonArea(Points);
        }

        public Polygon2d GetBoundingBox(IList<IPoint2d> pts)
        {
            List<IPoint2d> list = Point2d.GetBoundingBox(pts).Select(x => (IPoint2d)x).ToList();
            return new Polygon2d(list);
        }

        public Polygon2d GetBoundingBox(IPolygon2d polygon)
        {
            return GetBoundingBox(polygon.Points);
        }

        public Point2d GetBarycenter()
        {
            return Point2d.GetBarycenter(Points);
        }

        public Point2d GetClosest(IPoint2d pt)
        {
            return Point2d.GetClosest(pt, Points);
        }

        public (bool, Point2d) IsClosedToPolygon(IPoint2d p0, Length d)
        {
            return Point2d.IsClosedToPolygon(p0, Points, d);
        }

        public bool IsInside(IPoint2d point, double tol = 0, bool border = true)
        {
            return Point2d.IsInside(Points, point, tol, border);
        }

        public Polygon2d Rotate(Angle angle)
        {
            List<IPoint2d> list = Point2d.RotatePoints(Points, angle).Select(x => (IPoint2d)x).ToList();
            return new Polygon2d(list);
        }

        public static explicit operator Line2d(Polygon2d polygon)
        {
            if (polygon.Points.Count != 2)
            {
                throw new InvalidCastException("Only a Polygon with two points can be cast to a Line");
            }

            return new Line2d(polygon.Points[0], polygon.Points[1]);
        }
    }
}
