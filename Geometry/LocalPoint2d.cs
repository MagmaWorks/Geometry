using System;
using MagmaWorks.Geometry.Utility;
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

        public bool Equals(ILocalPoint2d other)
        {
            return Y.IsEqual(other.Y) && Z.IsEqual(other.Z);
        }

        public static LocalPoint2d operator *(double number, LocalPoint2d point)
        {
            return new LocalPoint2d(point.Y * number, point.Z * number);
        }
    }
}
