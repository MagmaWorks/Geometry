using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Polygon3dTests
    {
        [Fact]
        public void CreatePolygonTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var z1 = new Length(10, LengthUnit.Centimeter);
            var x2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);
            var z2 = new Length(-2.5, LengthUnit.Centimeter);

            // Act
            IPoint3d pt1 = new Point3d(x1, y1, z1);
            IPoint3d pt2 = new Point3d(x2, y2, z2);
            var pts = new List<IPoint3d>() { pt1, pt2 };
            IPolygon3d polygon = new Polygon3d(pts);

            // Assert
            TestUtility.TestLengthsAreEqual(x1, polygon.Points[0].X);
            TestUtility.TestLengthsAreEqual(y1, polygon.Points[0].Y);
            TestUtility.TestLengthsAreEqual(z1, polygon.Points[0].Z);
            TestUtility.TestLengthsAreEqual(x2, polygon.Points[1].X);
            TestUtility.TestLengthsAreEqual(y2, polygon.Points[1].Y);
            TestUtility.TestLengthsAreEqual(z2, polygon.Points[1].Z);
        }

        [Fact]
        public void PolygonSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var z1 = new Length(10, LengthUnit.Centimeter);
            var x2 = new Length(-5.0, LengthUnit.Centimeter);
            var y2 = new Length(7.1, LengthUnit.Centimeter);
            var z2 = new Length(-2.5, LengthUnit.Centimeter);

            // Act
            IPoint3d pt1 = new Point3d(x1, y1, z1);
            IPoint3d pt2 = new Point3d(x2, y2, z2);
            var pts = new List<IPoint3d>() { pt1, pt2 };
            IPolygon3d polygon = new Polygon3d(pts);
            string json = polygon.ToJson();
            IPolygon3d poligonDeserialized = json.FromJson<Polygon3d>();

            // Assert
            TestUtility.TestLengthsAreEqual(x1, polygon.Points[0].X);
            TestUtility.TestLengthsAreEqual(y1, polygon.Points[0].Y);
            TestUtility.TestLengthsAreEqual(z1, polygon.Points[0].Z);
            TestUtility.TestLengthsAreEqual(x2, polygon.Points[1].X);
            TestUtility.TestLengthsAreEqual(y2, polygon.Points[1].Y);
            TestUtility.TestLengthsAreEqual(z2, polygon.Points[1].Z);
        }

        [Fact]
        public void ThrowsForInvalidInputTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(10, LengthUnit.Centimeter);

            // Assert
            Assert.Throws<ArgumentException>(() => new Polygon3d(new List<IPoint3d>()));

            // Act
            IPoint3d pt = new Point3d(x, y, z);
            var pts = new List<IPoint3d>() { pt };
            Assert.Throws<ArgumentException>(() => new Polygon3d(pts));
        }
    }
}
