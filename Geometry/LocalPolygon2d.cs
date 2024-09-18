using System;
using System.Collections.Generic;
using System.Linq;
using MagmaWorks.Geometry.Extensions;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public class LocalPolygon2d : ILocalPolygon2d
    {
        public IList<ILocalPoint2d> Points { get; set; }

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

        public LocalPolygon2d GetBoundingBox(IList<ILocalPoint2d> pts)
        {
            List<ILocalPoint2d> list = LocalPoint2d.GetBoundingBox(pts).Select(x => (ILocalPoint2d)x).ToList();
            return new LocalPolygon2d(list);
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
    }
}
