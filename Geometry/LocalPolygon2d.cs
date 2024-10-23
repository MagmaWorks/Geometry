using System;
using System.Collections;
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
        public bool IsClosed => ((LocalPoint2d)Points.First()).Equals(Points.Last());

        public LocalPolygon2d(IList<ILocalPoint2d> points)
        {
            if (points.IsNullOrEmpty() || points.Count < 2)
            {
                throw new ArgumentException("List must contain two or more points");
            }

            Points = points;
        }

        public Area GetArea()
        {
            return LocalPoint2d.GetPolygonArea(Points);
        }

        public LocalPoint2d GetBarycenter()
        {
            return new LocalPoint2d(Utility.GetCenterLocal(Points.Select(p => new Point2d(p)).ToList()));
        }

        public LocalPolygon2d Rotate(Angle angle)
        {
            List<ILocalPoint2d> list = LocalPoint2d.RotatePoints(Points, angle).Select(x => (ILocalPoint2d)x).ToList();
            return new LocalPolygon2d(list);
        }

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
    }
}
