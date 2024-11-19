using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry.Extensions;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class LocalPolygon2d : ILocalPolygon2d
    {
        public IList<ILocalPoint2d> Points { get; set; }
        public bool IsClosed => FirstPointEquivilantToLast();

        public LocalPolygon2d(IList<ILocalPoint2d> points)
        {
            if (points.IsNullOrEmpty() || points.Count < 2)
            {
                throw new ArgumentException("List must contain two or more points");
            }

            Points = points;
        }

        public Area GetArea() => LocalPoint2d.GetPolygonArea(Points);

        public LocalPoint2d GetBarycenter() =>
            new LocalPoint2d(Utility.GetCenterLocal(Points.Select(p => new Point2d(p)).ToList()));

        public LocalPolygon2d Rotate(Angle angle) =>
            new LocalPolygon2d(LocalPoint2d.RotatePoints(Points, angle).Select(x => (ILocalPoint2d)x).ToList());

        public ILocalDomain2d Domain()
        {
            var max = new LocalPoint2d(
                Points.Select(pt => pt.Y).Max(LengthUnit.Meter),
                Points.Select(pt => pt.Z).Max(LengthUnit.Meter));
            var min = new LocalPoint2d(
                Points.Select(pt => pt.Y).Min(LengthUnit.Meter),
                Points.Select(pt => pt.Z).Min(LengthUnit.Meter));
            return new LocalDomain2d(max, min);
        }

        public bool IsClockwise() => LocalPoint2d.IsClockwise(Points);
        public ILocalPolygon2d Offset(Length distance) =>
            new LocalPolygon2d(LocalPoint2d.Offset(Points, distance).Select(x => (ILocalPoint2d)x).ToList());

        private bool FirstPointEquivilantToLast()
        {
            return Points.First().Y.Meters == Points.Last().Y.Meters
                && Points.First().Z.Meters == Points.Last().Z.Meters;
        }
    }
}
