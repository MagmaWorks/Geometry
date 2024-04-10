using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Line2dTests
    {
        [Fact]
        public void CreateLineTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(x1, y1);
            IPoint2d pt2 = new Point2d(x2, y2);
            ILine2d ln = new Line2d(pt1, pt2);

            // Assert
            TestUtility.TestLengthsAreEqual(x1, ln.Start.X);
            TestUtility.TestLengthsAreEqual(x2, ln.End.X);
            TestUtility.TestLengthsAreEqual(y1, ln.Start.Y);
            TestUtility.TestLengthsAreEqual(y2, ln.End.Y);
        }

        [Fact]
        public void LineSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(x1, y1);
            IPoint2d pt2 = new Point2d(x2, y2);
            ILine2d ln = new Line2d(pt1, pt2);
            string json = ln.ToJson();
            ILine2d lnDeserialized = json.FromJson<Line2d>();

            // Assert
            TestUtility.TestLengthsAreEqual(x1, lnDeserialized.Start.X);
            TestUtility.TestLengthsAreEqual(x2, lnDeserialized.End.X);
            TestUtility.TestLengthsAreEqual(y1, lnDeserialized.Start.Y);
            TestUtility.TestLengthsAreEqual(y2, lnDeserialized.End.Y);
        }

        [Fact]
        public void LineCastToVectorTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(x1, y1);
            IPoint2d pt2 = new Point2d(x2, y2);
            var ln = new Line2d(pt1, pt2);
            var vector = (Vector2d)ln;

            // Assert
            TestUtility.TestLengthsAreEqual(x1 - x2, vector.U);
            TestUtility.TestLengthsAreEqual(y1 - y2, vector.V);
        }

        [Fact]
        public void LineCastToPolygonTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(x1, y1);
            IPoint2d pt2 = new Point2d(x2, y2);
            var ln = new Line2d(pt1, pt2);
            var polygon = (Polygon2d)ln;

            // Assert
            TestUtility.TestLengthsAreEqual(x1, polygon.Points[0].X);
            TestUtility.TestLengthsAreEqual(x2, polygon.Points[1].X);
            TestUtility.TestLengthsAreEqual(y1, polygon.Points[0].Y);
            TestUtility.TestLengthsAreEqual(y2, polygon.Points[1].Y);
        }
    }
}
