using MagmaWorks.Geometry;
using OasysUnits;
using OasysUnits.Units;

namespace GeometryTests.FunctionalTests
{
    public class LocalPolygon2dTests
    {
        [Fact]
        public void GetBarycenterTest()
        {
            // Assemble
            var pt1 = new LocalPoint2d(1, 2, LengthUnit.Meter);
            var pt2 = new LocalPoint2d(3, 4, LengthUnit.Meter);

            // Act
            var poly = new LocalPolygon2d(new List<ILocalPoint2d>() { pt1, pt2 });
            LocalPoint2d center = poly.GetBarycenter();

            // Assert
            Assert.Equal(2, center.Y.Value);
            Assert.Equal(3, center.Z.Value);
        }

        [Fact]
        public void RotatePointsTest()
        {
            // Assemble
            var pt1 = new LocalPoint2d(0, 0, LengthUnit.Meter);
            var pt2 = new LocalPoint2d(4, 0, LengthUnit.Meter);
            var pt3 = new LocalPoint2d(4, 4, LengthUnit.Meter);
            var pt4 = new LocalPoint2d(0, 4, LengthUnit.Meter);

            // Act
            var polygon = new LocalPolygon2d(new List<ILocalPoint2d> { pt1, pt2, pt3, pt4 });
            LocalPolygon2d rotated = polygon.Rotate(new Angle(90, AngleUnit.Degree));

            // Assert
            Assert.Equal(0, rotated.Points[0].Y.Value, 6);
            Assert.Equal(0, rotated.Points[0].Z.Value, 6);
            Assert.Equal(0, rotated.Points[1].Y.Value, 6);
            Assert.Equal(4, rotated.Points[1].Z.Value, 6);
            Assert.Equal(-4, rotated.Points[2].Y.Value, 6);
            Assert.Equal(4, rotated.Points[2].Z.Value, 6);
            Assert.Equal(-4, rotated.Points[3].Y.Value, 6);
            Assert.Equal(0, rotated.Points[3].Z.Value, 6);
        }

        [Fact]
        public void GetPolygonAreaTest()
        {
            // Assemble
            var pt1 = new LocalPoint2d(0, 0, LengthUnit.Millimeter);
            var pt2 = new LocalPoint2d(400, 0, LengthUnit.Centimeter);
            var pt3 = new LocalPoint2d(4, 4, LengthUnit.Meter);
            var pt4 = new LocalPoint2d(0, 4, LengthUnit.Meter);

            // Act
            var polygon = new LocalPolygon2d(new List<ILocalPoint2d> { pt1, pt2, pt3, pt4 });
            Area area = polygon.GetArea();

            // Assert
            Assert.Equal(AreaUnit.SquareMillimeter, area.Unit);
            Assert.Equal(4 * 4, area.SquareMeters);
        }
    }
}
