using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using GeometryTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Line2dTests
    {
        [Fact]
        public void CreateLineTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var v1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-2.3, LengthUnit.Centimeter);
            var v2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, v1);
            IPoint2d pt2 = new Point2d(u2, v2);
            ILine2d ln = new Line2d(pt1, pt2);

            // Assert
            TestUtility.TestLengthsAreEqual(u1, ln.Start.U);
            TestUtility.TestLengthsAreEqual(u2, ln.End.U);
            TestUtility.TestLengthsAreEqual(v1, ln.Start.V);
            TestUtility.TestLengthsAreEqual(v2, ln.End.V);
        }

        [Fact]
        public void LineSurvivesJsonRoundtripTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var v1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-2.3, LengthUnit.Centimeter);
            var v2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, v1);
            IPoint2d pt2 = new Point2d(u2, v2);
            ILine2d ln = new Line2d(pt1, pt2);
            string json = ln.ToJson();
            ILine2d lnDeserialized = json.FromJson<Line2d>();

            // Assert
            TestUtility.TestLengthsAreEqual(u1, lnDeserialized.Start.U);
            TestUtility.TestLengthsAreEqual(u2, lnDeserialized.End.U);
            TestUtility.TestLengthsAreEqual(v1, lnDeserialized.Start.V);
            TestUtility.TestLengthsAreEqual(v2, lnDeserialized.End.V);
        }

        [Fact]
        public void LineCastToVectorTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var v1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-2.3, LengthUnit.Centimeter);
            var v2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, v1);
            IPoint2d pt2 = new Point2d(u2, v2);
            var ln = new Line2d(pt1, pt2);
            var vector = (Vector2d)ln;

            // Assert
            TestUtility.TestLengthsAreEqual(u1 - u2, vector.U);
            TestUtility.TestLengthsAreEqual(v1 - v2, vector.V);
        }

        [Fact]
        public void LineCastToPolygonTest()
        {
            // Assemble
            var u1 = new Length(2.3, LengthUnit.Centimeter);
            var v1 = new Length(5.4, LengthUnit.Centimeter);
            var u2 = new Length(-2.3, LengthUnit.Centimeter);
            var v2 = new Length(-5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt1 = new Point2d(u1, v1);
            IPoint2d pt2 = new Point2d(u2, v2);
            var ln = new Line2d(pt1, pt2);
            var polygon = (Polygon2d)ln;

            // Assert
            TestUtility.TestLengthsAreEqual(u1, polygon.Points[0].U);
            TestUtility.TestLengthsAreEqual(u2, polygon.Points[1].U);
            TestUtility.TestLengthsAreEqual(v1, polygon.Points[0].V);
            TestUtility.TestLengthsAreEqual(v2, polygon.Points[1].V);
        }
    }
}
