using System;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class Vector2d : IVector2d
    {
        public Length X { get; private set; }
        public Length Y { get; private set; }
        public Length Length
        {
            get
            {
                LengthUnit unit = X.Unit;
                double area = Math.Pow(X.As(unit), 2) + Math.Pow(Y.As(unit), 2);
                return new Length(Math.Sqrt(area), unit);
            }
        }
        public Vector2d(Length x, Length y)
        {
            X = x;
            Y = y.ToUnit(x.Unit);
        }

        public Vector2d(double x, double y, LengthUnit unit)
        {
            X = new Length(x, unit);
            Y = new Length(y, unit);
        }

        public Vector2d(IVector2d other)
        {
            X = other.X;
            Y = other.Y.ToUnit(other.X.Unit);
        }

        public Vector2d Normalize()
        {
            LengthUnit unit = X.Unit;
            return new Vector2d(new Length(X / Length, unit), new Length(Y / Length, unit));
        }

        public static Vector2d operator *(double number, Vector2d point)
        {
            return new Vector2d(point.X * number, point.Y * number);
        }

        public static double ScalarProduct(IVector2d v1, IVector2d v2)
        {
            LengthUnit unit = v1.X.Unit;
            return v1.X.As(unit) * v2.X.As(unit) + v1.Y.As(unit) * v2.Y.As(unit);
        }

        public static Angle VectorAngle(IVector2d v1, IVector2d v2)
        {
            LengthUnit unit = v1.X.Unit;
            return new Angle(Math.Acos(ScalarProduct(v1, v2)) / (v1.Length.As(unit) * v2.Length.As(unit)), AngleUnit.Radian);
        }

        public static Vector2d UnitX => new Vector2d(new Length(1, LengthUnit.Meter), Length.Zero);
        public static Vector2d UnitY => new Vector2d(Length.Zero, new Length(1, LengthUnit.Meter));
    }
}
