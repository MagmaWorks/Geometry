using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry.Extensions;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class Polygon2d : IPolygon2d
    {
        public IList<IPoint2d> Points { get; set; }
        public bool IsClosed => ((Point2d)Points.First()).Equals(Points.Last());

        public Polygon2d(IList<IPoint2d> points)
        {
            if (points.IsNullOrEmpty() || points.Count < 2)
            {
                throw new ArgumentException("List must contain two or more points");
            }

            Points = points;
        }

        public Area GetArea()
        {
            return Point2d.GetPolygonArea(Points);
        }

        public Point2d GetBarycenter()
        {
            return Utility.GetCenterLocal(Points);
        }

        public Point2d GetClosest<P>(P pt) where P : IPoint2d
        {
            return Point2d.GetClosest(pt, Points);
        }

        public (bool, Point2d) IsCloseToPolygon<P>(P p0, Length d) where P : IPoint2d
        {
            return Point2d.IsCloseToPolygon(p0, Points, d);
        }

        public bool IsInside<P>(P point, double tol = 0, bool border = true) where P : IPoint2d
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

        public IDomain2d Domain()
        {
            var max = new Point2d(
                Points.Select(pt => pt.U).Max(LengthUnit.Meter),
                Points.Select(pt => pt.V).Max(LengthUnit.Meter));
            var min = new Point2d(
                Points.Select(pt => pt.U).Min(LengthUnit.Meter),
                Points.Select(pt => pt.V).Min(LengthUnit.Meter));
            return new Domain2d(max, min);
        }
    }
}
