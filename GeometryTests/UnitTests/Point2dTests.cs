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
    }
}
