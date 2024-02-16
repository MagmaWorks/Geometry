using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Point3dTests
    {
        [Fact]
        public void CreatePointTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            IPoint3d pt = new Point3d(x, y, z);

            // Assert
            TestUtility.TestLengthsAreEqual(x, pt.X);
            TestUtility.TestLengthsAreEqual(y, pt.Y);
            TestUtility.TestLengthsAreEqual(z, pt.Z);
        }

        [Fact]
        public void PointSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            IPoint3d pt = new Point3d(x, y, z);
            string json = pt.ToJson();
            IPoint3d ptDeserialized = json.FromJson<Point3d>();

            // Assert
            TestUtility.TestLengthsAreEqual(pt.X, ptDeserialized.X);
            TestUtility.TestLengthsAreEqual(pt.Y, ptDeserialized.Y);
            TestUtility.TestLengthsAreEqual(pt.Z, ptDeserialized.Z);
        }
    }
}
