using MagmaWorks.Geometry;
using OasysUnits;
using OasysUnits.Units;

namespace GeometryTests.FunctionalTests
{
    public class Polygon2dTests
    {
        [Fact]
        public void GetBarycenterTest()
        {
            // Assemble
            var pt1 = new Point2d(1, 2, LengthUnit.Meter);
            var pt2 = new Point2d(3, 4, LengthUnit.Meter);

            // Act
            var poly = new Polygon2d(new List<IPoint2d>() { pt1, pt2 });
            Point2d center = poly.GetBarycenter();

            // Assert
            Assert.Equal(2, center.U.Value);
            Assert.Equal(3, center.V.Value);
        }


        [Fact]
        public void GetClosestVertexTest()
        {
            // Assemble
            var pt1 = new Point2d(0, 0, LengthUnit.Meter);
            var pt2 = new Point2d(4, 0, LengthUnit.Meter);
            var pt = new Point2d(5, 1, LengthUnit.Meter);

            // Act
            var poly = new Polygon2d(new List<IPoint2d>() { pt1, pt2 });
            Point2d ptOnLine = poly.GetClosest(pt);

            // Assert
            Assert.Equal(4, ptOnLine.U.Value);
            Assert.Equal(0, ptOnLine.V.Value);
        }

        [Fact]
        public void IsCloseToPolygonTest()
        {
            // Assemble
            var pt1 = new Point2d(0, 0, LengthUnit.Meter);
            var pt2 = new Point2d(4, 0, LengthUnit.Meter);
            var pt3 = new Point2d(5, 2, LengthUnit.Meter);
            var pt = new Point2d(2, 2, LengthUnit.Meter);
            Length dist1 = new Length(0.5, LengthUnit.Meter);
            Length dist2 = new Length(2, LengthUnit.Meter);

            // Act
            var polygon = new Polygon2d(new List<IPoint2d> { pt1, pt2, pt3 });
            (bool close, Point2d pt) ptClose1 = polygon.IsCloseToPolygon(pt, dist1);
            (bool close, Point2d pt) ptClose2 = polygon.IsCloseToPolygon(pt, dist2);

            // Assert
            Assert.False(ptClose1.close);
            Assert.Null(ptClose1.pt);
            Assert.True(ptClose2.close);
            Assert.Equal(2, ptClose2.pt.U.Value);
            Assert.Equal(0, ptClose2.pt.V.Value);
        }

        [Fact]
        public void RotatePointsTest()
        {
            // Assemble
            var pt1 = new Point2d(0, 0, LengthUnit.Meter);
            var pt2 = new Point2d(4, 0, LengthUnit.Meter);
            var pt3 = new Point2d(4, 4, LengthUnit.Meter);
            var pt4 = new Point2d(0, 4, LengthUnit.Meter);

            // Act
            var polygon = new Polygon2d(new List<IPoint2d> { pt1, pt2, pt3, pt4 });
            Polygon2d rotated = polygon.Rotate(new Angle(90, AngleUnit.Degree));

            // Assert
            Assert.Equal(0, rotated.Points[0].U.Value, 6);
            Assert.Equal(0, rotated.Points[0].V.Value, 6);
            Assert.Equal(0, rotated.Points[1].U.Value, 6);
            Assert.Equal(4, rotated.Points[1].V.Value, 6);
            Assert.Equal(-4, rotated.Points[2].U.Value, 6);
            Assert.Equal(4, rotated.Points[2].V.Value, 6);
            Assert.Equal(-4, rotated.Points[3].U.Value, 6);
            Assert.Equal(0, rotated.Points[3].V.Value, 6);
        }


        [Fact]
        public void IsInsideTest()
        {
            // Assemble
            var pt1 = new Point2d(0, 0, LengthUnit.Meter);
            var pt2 = new Point2d(4, 0, LengthUnit.Meter);
            var pt3 = new Point2d(4, 4, LengthUnit.Meter);
            var pt4 = new Point2d(0, 4, LengthUnit.Meter);
            var testInside = new Point2d(2, 2, LengthUnit.Meter);
            var testOutside = new Point2d(-2, 2, LengthUnit.Meter);

            // Act
            var polygon = new Polygon2d(new List<IPoint2d> { pt1, pt2, pt3, pt4 });

            // Assert
            Assert.True(polygon.IsInside(testInside));
            Assert.False(polygon.IsInside(testOutside));
        }

        [Fact]
        public void GetPolygonAreaTest()
        {
            // Assemble
            var pt1 = new Point2d(0, 0, LengthUnit.Millimeter);
            var pt2 = new Point2d(400, 0, LengthUnit.Centimeter);
            var pt3 = new Point2d(4, 4, LengthUnit.Meter);
            var pt4 = new Point2d(0, 4, LengthUnit.Meter);

            // Act
            var polygon = new Polygon2d(new List<IPoint2d> { pt1, pt2, pt3, pt4 });
            Area area = polygon.GetArea();

            // Assert
            Assert.Equal(AreaUnit.SquareMillimeter, area.Unit);
            Assert.Equal(4 * 4, area.SquareMeters);
        }
    }
}
