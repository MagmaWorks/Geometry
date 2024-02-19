using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Polygon2dTests
    {
        [Fact]
        public void CreatePolygonTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(x1, y1);
            IPoint2d pt2 = new Point2d(x2, y2);
            var pts = new List<IPoint2d>() { pt1, pt2 };
            IPolygon2d polygon = new Polygon2d(pts);

            // Assert
            TestUtility.TestLengthsAreEqual(x1, polygon.Points[0].X);
            TestUtility.TestLengthsAreEqual(y1, polygon.Points[0].Y);
            TestUtility.TestLengthsAreEqual(x2, polygon.Points[1].X);
            TestUtility.TestLengthsAreEqual(y2, polygon.Points[1].Y);
        }

        [Fact]
        public void PolygonSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(x1, y1);
            IPoint2d pt2 = new Point2d(x2, y2);
            var pts = new List<IPoint2d>() { pt1, pt2 };
            IPolygon2d polygon = new Polygon2d(pts);
            string json = polygon.ToJson();
            IPolygon2d poligonDeserialized = json.FromJson<Polygon2d>();

            // Assert
            TestUtility.TestLengthsAreEqual(x1, poligonDeserialized.Points[0].X);
            TestUtility.TestLengthsAreEqual(y1, poligonDeserialized.Points[0].Y);
            TestUtility.TestLengthsAreEqual(x2, poligonDeserialized.Points[1].X);
            TestUtility.TestLengthsAreEqual(y2, poligonDeserialized.Points[1].Y);
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
