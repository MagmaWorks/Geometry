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
        public bool IsClosed => FirstPointEquivilantToLast();

        public Polygon2d(IList<IPoint2d> points)
        {
            if (points.IsNullOrEmpty() || points.Count < 2)
            {
                throw new ArgumentException("List must contain two or more points");
            }

            Points = points;
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
        public Area GetArea() => Point2d.GetPolygonArea(Points);
        public Point2d GetBarycenter() => Utility.GetCenterLocal(Points);
        public Point2d GetClosest<P>(P pt) where P : IPoint2d => Point2d.GetClosest(pt, Points);
        public bool IsClockwise() => Point2d.IsClockwise(Points);
        public (bool, Point2d) IsCloseToPolygon<P>(P p0, Length d) where P : IPoint2d
            => Point2d.IsCloseToPolygon(p0, Points, d);
        public bool IsInside<P>(P point, double tol = 0, bool border = true) where P : IPoint2d
            => Point2d.IsInside(Points, point, tol, border);
        public IPolygon2d Offset(Length distance) => new Polygon2d(Point2d.Offset(Points, distance));
        public Polygon2d Rotate(Angle angle) =>
            new Polygon2d(Point2d.RotatePoints(Points, angle).Select(x => (IPoint2d)x).ToList());

        public static explicit operator Line2d(Polygon2d polygon)
        {
            if (polygon.Points.Count != 2)
            {
                throw new InvalidCastException("Only a Polygon with two points can be cast to a Line");
            }

            return new Line2d(polygon.Points[0], polygon.Points[1]);
        }

        private bool FirstPointEquivilantToLast()
        {
            return Points.First().U.Meters == Points.Last().U.Meters
                && Points.First().V.Meters == Points.Last().V.Meters;
        }
    }
}
