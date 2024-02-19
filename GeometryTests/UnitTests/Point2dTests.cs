using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Point2dTests
    {
        [Fact]
        public void CreatePointTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt = new Point2d(x, y);

            // Assert
            TestUtility.TestLengthsAreEqual(x, pt.X);
            TestUtility.TestLengthsAreEqual(y, pt.Y);
        }

        [Fact]
        public void PointsAreEqualTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(2.3, LengthUnit.Centimeter);
            var y2 = new Length(5.4, LengthUnit.Centimeter);
            var x3 = new Length(666, LengthUnit.Centimeter);
            var y3 = new Length(777, LengthUnit.Centimeter);

            // Act
            var pt1 = new Point2d(x1, y1);
            var pt2 = new Point2d(x2, y2);
            var pt3 = new Point2d(x3, y3);

            // Assert
            Assert.True(pt1.Equals(pt2));
            Assert.False(pt1.Equals(pt3));
        }

        [Fact]
        public void PointSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            IPoint2d pt = new Point2d(x, y);
            string json = pt.ToJson();
            IPoint2d ptDeserialized = json.FromJson<Point2d>();

            // Assert
            TestUtility.TestLengthsAreEqual(pt.X, ptDeserialized.X);
            TestUtility.TestLengthsAreEqual(pt.Y, ptDeserialized.Y);
        }

        [Fact]
        public void PointCastToVectorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            var pt = new Point2d(x, y);
            var vector = (Vector2d)pt;

            // Assert
            TestUtility.TestLengthsAreEqual(x, vector.X);
            TestUtility.TestLengthsAreEqual(y, vector.Y);
        }

        [Fact]
        public void PointMinusOperatorTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var x2 = new Length(2.3, LengthUnit.Centimeter);
            var y2 = new Length(5.4, LengthUnit.Centimeter);

            // Act
            var pt1 = new Point2d(x1, y1);
            var pt2 = new Point2d(x2, y2);
            Vector2d vector = pt1 - pt2;

            // Assert
            Assert.Equal(0, vector.X.Value);
            Assert.Equal(0, vector.Y.Value);
        }

        [Fact]
        public void PointMultiplyOperatorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            var pt = new Point2d(x, y);
            double scalar = 5.6;
            Point2d ptScaled = scalar * pt;

            // Assert
            Assert.Equal(scalar * 2.3, ptScaled.X.Value);
            Assert.Equal(scalar * 5.4, ptScaled.Y.Value);
        }
    }
}
