﻿using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry.Extensions;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class LocalPoint2d : ILocalPoint2d, IEquatable<ILocalPoint2d>
    {
        public Length Y { get; set; } = Length.Zero;
        public Length Z { get; set; } = Length.Zero;

        public LocalPoint2d() { }

        public LocalPoint2d(Length y, Length z)
        {
            Y = y;
            Z = z.ToUnit(y.Unit);
        }

        public LocalPoint2d(double y, double z, LengthUnit unit)
        {
            Y = new Length(y, unit);
            Z = new Length(z, unit);
        }

        public LocalPoint2d(ILocalPoint2d other)
        {
            Y = other.Y;
            Z = other.Z.ToUnit(other.Y.Unit);
        }

        public LocalPoint2d(IPoint2d other)
        {
            Y = other.U;
            Z = other.V.ToUnit(other.U.Unit);
        }

        public bool Equals(ILocalPoint2d other)
        {
            return Y.IsEqual(other.Y) && Z.IsEqual(other.Z);
        }

        public static LocalPoint2d operator *(double number, LocalPoint2d point)
        {
            return new LocalPoint2d(point.Y * number, point.Z * number);
        }

        public static Area GetPolygonArea(IList<ILocalPoint2d> vertices, bool closed = false)
        {
            return Point2d.GetPolygonArea(vertices.Select(p => (IPoint2d)new Point2d(p)).ToList(), closed);
        }

        public static List<LocalPoint2d> RotatePoints(IList<ILocalPoint2d> pts, Angle angle)
        {
            return Point2d.RotatePoints(pts.Select(p => (IPoint2d)new Point2d(p)).ToList(), angle)
                .Select(p => new LocalPoint2d(p)).ToList();
        }
    }
}
