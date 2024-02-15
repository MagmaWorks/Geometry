using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry.Utility;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class Point2d : IPoint2d, IEquatable<IPoint2d>
    {
        public Length X { get; private set; } = Length.Zero;
        public Length Y { get; private set; } = Length.Zero;

        public Point2d() { }

        public Point2d(Length x, Length y)
        {
            X = x;
            Y = y.ToUnit(x.Unit);
        }

        public Point2d(double x, double y, LengthUnit unit)
        {
            X = new Length(x, unit);
            Y = new Length(y, unit);
        }

        public Point2d(IPoint2d other)
        {
            X = other.X;
            Y = other.Y.ToUnit(other.X.Unit);
        }

        public bool Equals(IPoint2d other)
        {
            return X.IsEqual(other.X) && Y.IsEqual(other.Y);
        }

        public static Point2d operator *(double number, Point2d point)
        {
            return new Point2d(point.X * number, point.Y * number);
        }

        /// <summary>
        /// Returns the barycenter of the points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Point2d GetBarycenter(IList<IPoint2d> points)
        {
            Length resX = Length.Zero;
            Length resY = Length.Zero;
            for (int i = 0; i < points.Count; i++)
            {
                resX += points[i].X;
                resY += points[i].Y;
            }

            resX /= points.Count;
            resY /= points.Count;

            return new Point2d(resX, resY);
        }

        /// <summary>
        /// Returns the distance between the 2D points p1 and p2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Length Distance(IPoint2d p1, IPoint2d p2)
        {
            LengthUnit unit = p1.X.Unit;
            double area = Math.Pow((p1.X.As(unit) - p2.X.As(unit)), 2) + Math.Pow((p1.Y.As(unit) - p2.Y.As(unit)), 2);
            return new Length(Math.Sqrt(area), unit);
        }

        public static Point2d GetClosest(IPoint2d pt, IList<IPoint2d> pts)
        {
            List<Length> dists = pts.Select(p => Distance(pt, p)).ToList();
            return (Point2d)pts[dists.IndexOf(dists.Min())];
        }

        /// <summary>
        /// Returns the distance between p3 and the infinite line formed by p1 and p2
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns> Returns the distance between p3 and the infinite line formed by p1 and p2 </returns>
        public static Length DistancePointToLine(IPoint2d l1, IPoint2d l2, IPoint2d p0, bool infinite = true)
        {
            LengthUnit unit = l1.X.Unit;
            double d = 0;
            if (((Point2d)l1).Equals(l2) == false)
            {
                d = Math.Abs((l2.Y.As(unit) - l1.Y.As(unit)) * p0.X.As(unit)
                           - (l2.X.As(unit) - l1.X.As(unit)) * p0.Y.As(unit)
                           + l2.X.As(unit) * l1.Y.As(unit) - l2.Y.As(unit) * l1.X.As(unit))
                    / Math.Sqrt(Math.Pow(l2.Y.As(unit) - l1.Y.As(unit), 2) + Math.Pow(l2.X.As(unit) - l1.X.As(unit), 2));
            }

            if (!infinite)
            {
                var v1 = new Vector2d(p0.X - l1.X, p0.Y - l1.Y);
                var v2 = new Vector2d(p0.X - l2.X, p0.Y - l2.Y);
                var v12 = new Vector2d(l2.X - l1.X, l2.Y - l1.Y);
                var v21 = new Vector2d(l1.X - l2.X, l1.Y - l2.Y);
                Angle a1 = Vector2d.VectorAngle(v1, v12);
                Angle a2 = Vector2d.VectorAngle(v2, v21);
                if (a1.Radians > Math.PI / 2)
                {
                    return Distance(p0, l1);
                }
                else if (a2.Radians > Math.PI / 2)
                {
                    return Distance(p0, l2);
                }
            }

            return new Length(d, unit);
        }

        public static Point2d PointProjOnLine(IPoint2d l1, IPoint2d l2, IPoint2d p0)
        {
            LengthUnit unit = l1.X.Unit;
            double d = Math.Pow(l2.X.As(unit) - l1.X.As(unit), 2) + Math.Pow(l2.Y.As(unit) - l1.Y.As(unit), 2);
            double uv = (p0.X.As(unit) - l1.X.As(unit)) * (l2.X.As(unit) - l1.X.As(unit))
                        + (p0.Y.As(unit) - l1.Y.As(unit)) * (l2.Y.As(unit) - l1.Y.As(unit));
            return new Point2d(
                l1.X + uv / d * (l2.X - l1.X),
                l1.Y + uv / d * (l2.Y - l1.Y));
        }

        public static (bool, Point2d) IsClosedToPolygon(IPoint2d p0, IList<IPoint2d> points, Length d)
        {
            var pt = new Point2d(Length.Zero, Length.Zero);
            bool isClosed = false;
            for (int i = 0; i < points.Count; i++)
            {
                int j = (i == points.Count - 1) ? 0 : i + 1;
                if (DistancePointToLine(points[i], points[j], p0) < d)
                {
                    pt = PointProjOnLine(points[i], points[j], p0);
                    isClosed = true;
                    break;
                }
            }

            return (isClosed, pt);
        }

        public static List<Point2d> RotatePoints(IList<IPoint2d> pts, Angle angle)
        {
            double cosa = Math.Cos(angle.Radians);
            double sina = Math.Sin(angle.Radians);
            return pts.Select(p => new Point2d(cosa * p.X - sina * p.Y, sina * p.X + cosa * p.Y)).ToList();
        }

        public static Point2d RotatePoint(IPoint2d pt, Angle angle)
        {
            if (angle.Value != 0)
            {
                double cosa = Math.Cos(angle.Radians);
                double sina = Math.Sin(angle.Radians);
                return new Point2d(cosa * pt.X - sina * pt.Y, sina * pt.X + cosa * pt.Y);
            }
            else return new Point2d(pt);
        }

        public static Point2d RotatePoint(IPoint2d pt, Angle angle, IPoint2d p0)
        {
            if (angle.Value != 0)
            {
                double cosa = Math.Cos(angle.Radians);
                double sina = Math.Sin(angle.Radians);
                return new Point2d(cosa * (pt.X - p0.X) - sina * (pt.Y - p0.Y) + p0.X, sina * (pt.X - p0.X) + cosa * (pt.Y - p0.Y) + p0.Y);
            }
            else return new Point2d(pt);
        }

        public static List<Point2d> GetBoundingBox(IList<IPoint2d> pts)
        {
            var vecs = new List<Vector2d>();
            for (int i = 0; i < pts.Count; i++)
            {
                for (int j = 0; j < pts.Count; j++)
                {
                    if (i != j)
                    {
                        if (!(pts[i].X.IsEqual(pts[j].X) && pts[i].Y.IsEqual(pts[j].Y)))
                        {
                            var v = new Vector2d(pts[i].X - pts[j].X, pts[i].Y - pts[j].Y);
                            vecs.Add(v);
                        }
                    }
                }
            }

            Vector2d vy = Vector2d.UnitY;
            Area area = new Area(100000, AreaUnit.SquareMillimeter);
            var boundingPts = new List<Point2d>();
            for (int i = 0; i < vecs.Count; i++)
            {
                Angle alpha = Vector2d.VectorAngle(vy, vecs[i]);
                double cosa = Math.Cos(alpha.Radians);
                double sina = Math.Sin(alpha.Radians);
                List<Point2d> pts2 = pts.Select(p => new Point2d(cosa * p.X - sina * p.Y, sina * p.X + cosa * p.Y)).ToList();

                Length Xmin = pts2.Select(q => q.X).Min();
                Length Xmax = pts2.Select(q => q.X).Max();
                Length Ymin = pts2.Select(q => q.Y).Min();
                Length Ymax = pts2.Select(q => q.Y).Max();

                if ((Xmax - Xmin) * (Ymax - Ymin) < area)
                {
                    area = (Xmax - Xmin) * (Ymax - Ymin);
                    boundingPts = new List<Point2d>
                    {
                        new Point2d(Xmin * cosa + Ymin * sina, -Xmin * sina + Ymin * cosa),
                        new Point2d(Xmax * cosa + Ymin * sina, -Xmax * sina + Ymin * cosa),
                        new Point2d(Xmax * cosa + Ymax * sina, -Xmax * sina + Ymax * cosa),
                        new Point2d(Xmin * cosa + Ymax * sina, -Xmin * sina + Ymax * cosa)
                    };
                }
            }

            return boundingPts;
        }

        /// <summary>
        /// Returns true if point is inside the polygon defined by the vertices.
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsInside(IList<IPoint2d> vertices, IPoint2d point, double tol = 0, bool border = true)
        {
            if (border)
            {
                if (vertices.Contains(point))
                    return true;
            }
            if (tol > 0)
            {

                vertices = Extend(vertices, tol);
            }

            bool inside = false;
            int nvert = vertices.Count;
            for (int i = 0; i < nvert; i++)
            {
                int j = (i == 0) ? nvert - 1 : i - 1;
                if (((vertices[i].Y >= point.Y) != (vertices[j].Y >= point.Y))
                    && (point.X <= (vertices[j].X - vertices[i].X) * (point.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X))
                    inside = !inside;
            }

            return inside;
        }

        public static Area GetPolygonArea(IList<IPoint2d> vertices, bool closed = false)
        {
            Area res = Area.Zero;
            int n = vertices.Count;
            if (closed)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    res += (vertices[i].X * vertices[i + 1].Y - vertices[i].Y * vertices[i + 1].X) / 2;
                }
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    res += (vertices[i].X * vertices[i + 1].Y - vertices[i].Y * vertices[i + 1].X) / 2;
                }
                res += (vertices[n - 1].X * vertices[0].Y - vertices[n - 1].Y * vertices[0].X) / 2;
            }

            return res.Abs();
        }


        public static IList<IPoint2d> Contract(IList<IPoint2d> lpts, double factor)
        {
            Point2d cog = GetBarycenter(lpts);
            var points = new List<IPoint2d>();
            for (int i = 0; i < lpts.Count; i++)
            {
                Length x = (1 - factor) * cog.X + factor * lpts[i].X;
                Length y = (1 - factor) * cog.Y + factor * lpts[i].Y;
                points.Add(new Point2d(x, y));
            }

            return points;
        }

        public static IList<IPoint2d> Extend(IList<IPoint2d> lpts, double factor)
        {
            Point2d cog = GetBarycenter(lpts);
            var points = new List<IPoint2d>();
            foreach (IPoint2d pt in lpts)
            {
                var v = new Vector2d(pt.X - cog.X, pt.Y - cog.Y);
                v = v.Normalize();
                points.Add(new Point2d(pt.X + v.X * factor, pt.Y + v.Y * factor));
            }

            return points;
        }
    }
}
