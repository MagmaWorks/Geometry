using GeometryTests.Utility;
using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;

namespace GeometryTests.UnitTests
{
    public class Polygon2dTests
    {
        [Fact]
        public void CreatePolygonTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, y1);
            IPoint2d pt2 = new Point2d(u2, y2);
            var pts = new List<IPoint2d>() { pt1, pt2 };
            IPolygon2d polygon = new Polygon2d(pts);

            // Assert
            TestUtility.TestLengthsAreEqual(u1, polygon.Points[0].U);
            TestUtility.TestLengthsAreEqual(y1, polygon.Points[0].V);
            TestUtility.TestLengthsAreEqual(u2, polygon.Points[1].U);
            TestUtility.TestLengthsAreEqual(y2, polygon.Points[1].V);
        }

        [Fact]
        public void ToStringTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, y1);
            IPoint2d pt2 = new Point2d(u2, y2);
            var pts = new List<IPoint2d>() { pt1, pt2 };
            var polygon = new Polygon2d(pts);

            // Assert
            Assert.Equal("2D Polygon (2 points;Open)", polygon.ToString());
        }

        [Fact]
        public void CastPolygonToLineTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, y1);
            IPoint2d pt2 = new Point2d(u2, y2);
            var pts = new List<IPoint2d>() { pt1, pt2 };
            var polygon = new Polygon2d(pts);
            Line2d ln = (Line2d)polygon;

            // Assert
            TestUtility.TestLengthsAreEqual(u1, ln.Start.U);
            TestUtility.TestLengthsAreEqual(y1, ln.Start.V);
            TestUtility.TestLengthsAreEqual(u2, ln.End.U);
            TestUtility.TestLengthsAreEqual(y2, ln.End.V);
        }

        [Fact]
        public void PolygonSurvivesJsonRoundtripTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, y1);
            IPoint2d pt2 = new Point2d(u2, y2);
            var pts = new List<IPoint2d>() { pt1, pt2 };
            IPolygon2d polygon = new Polygon2d(pts);
            string json = polygon.ToJson();
            IPolygon2d poligonDeserialized = json.FromJson<Polygon2d>();

            // Assert
            TestUtility.TestLengthsAreEqual(u1, poligonDeserialized.Points[0].U);
            TestUtility.TestLengthsAreEqual(y1, poligonDeserialized.Points[0].V);
            TestUtility.TestLengthsAreEqual(u2, poligonDeserialized.Points[1].U);
            TestUtility.TestLengthsAreEqual(y2, poligonDeserialized.Points[1].V);
        }

        [Fact]
        public void ThrowsForInvalidInputTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Assert
            Assert.Throws<ArgumentException>(() => new Polygon2d(new List<IPoint2d>()));

            // Act
            IPoint2d pt = new Point2d(x, y);
            var pts = new List<IPoint2d>() { pt };
            Assert.Throws<ArgumentException>(() => new Polygon2d(pts));
        }
    }
}
