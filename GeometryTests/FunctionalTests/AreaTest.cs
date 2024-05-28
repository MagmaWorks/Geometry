﻿using MagmaWorks.Geometry;
using OasysUnits;

namespace GeometryTests.FunctionalTests
{
    public class AreaTest
    {
        [Fact]
        public void TestAreaXY()
        {
            var p1 = new Point3d(-5, 10, 0, OasysUnits.Units.LengthUnit.Centimeter);
            var p2 = new Point3d(20, -7, 0, OasysUnits.Units.LengthUnit.Centimeter);
            var p3 = new Point3d(-5, -7, 0, OasysUnits.Units.LengthUnit.Centimeter);

            Area a = MagmaWorks.Geometry.Utility.GetArea(p1, p2, p3);

            double expecpted = 25 * 17 / (double)2;
            Assert.Equal(expecpted, a.SquareCentimeters, 12);
        }

        [Fact]
        public void TestAreaYZ()
        {
            var p1 = new Point3d(0, -5, 10, OasysUnits.Units.LengthUnit.Centimeter);
            var p2 = new Point3d(0, 20, -7, OasysUnits.Units.LengthUnit.Centimeter);
            var p3 = new Point3d(0, -5, -7, OasysUnits.Units.LengthUnit.Centimeter);

            Area a = MagmaWorks.Geometry.Utility.GetArea(p1, p2, p3);

            double expecpted = 25 * 17 / (double)2;
            Assert.Equal(expecpted, a.SquareCentimeters, 12);
        }

        [Fact]
        public void TestAreaZx()
        {
            var p1 = new Point3d(-5, 0, 10, OasysUnits.Units.LengthUnit.Centimeter);
            var p2 = new Point3d(20, 0, -7, OasysUnits.Units.LengthUnit.Centimeter);
            var p3 = new Point3d(-5, 0, -7, OasysUnits.Units.LengthUnit.Centimeter);

            Area a = MagmaWorks.Geometry.Utility.GetArea(p1, p2, p3);

            double expecpted = 25 * 17 / (double)2;
            Assert.Equal(expecpted, a.SquareCentimeters, 12);
        }
    }
}
