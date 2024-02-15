using System;
using MagmaWorks.Geometry.Utility;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class LocalCoordinateSystem : ILocalCoordinateSystem
    {
        public IVector3d XAxis { get; private set; } = Vector3d.UnitX;
        public IVector3d YAxis { get; private set; } = Vector3d.UnitY;
        public IVector3d ZAxis { get; private set; } = Vector3d.UnitZ;
        public IPoint3d Origin { get; private set; } = new Point3d();

        public LocalCoordinateSystem() { }

        public LocalCoordinateSystem(IVector3d xaxis, IVector3d yaxis, IVector3d zaxis, IPoint3d origin)
        {
            XAxis = xaxis;
            YAxis = yaxis;
            ZAxis = zaxis;
            Origin = origin;
        }

        public static ILocalCoordinateSystem LocalCoordSystemFromLinePoints(IPoint3d point1, IPoint3d point2)
        {
            LengthUnit unit = point1.X.Unit;
            Vector3d normal = ((Point3d)point2) - ((Point3d)point1);
            Vector3d newX;
            if (normal.Z.As(unit) < 0.99)
            {
                newX = Vector3d.CrossProduct(normal, Vector3d.UnitZ);
            }
            else
            {
                newX = Vector3d.CrossProduct(normal, Vector3d.UnitX);
            }

            Vector3d newY = Vector3d.CrossProduct(normal, newX);
            Vector3d newX2 = newX.Normalised();
            Vector3d newY2 = newY.Normalised();
            Vector3d newZ2 = normal.Normalised();

            return new LocalCoordinateSystem(newX2, newY2, newZ2, point1);
        }
    }
}
