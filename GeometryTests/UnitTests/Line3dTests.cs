using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Line3dTests
    {
        [Fact]
        public void CreateLineTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var z1 = new Length(6.8, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);
            var z2 = new Length(-6.8, LengthUnit.Centimeter);

            // Act
            IPoint3d pt1 = new Point3d(x1, y1, z1);
            IPoint3d pt2 = new Point3d(x2, y2, z2);
            ILine3d ln = new Line3d(pt1, pt2);

            // Assert
            TestUtility.TestLengthsAreEqual(x1, ln.Start.X);
            TestUtility.TestLengthsAreEqual(x2, ln.End.X);
            TestUtility.TestLengthsAreEqual(y1, ln.Start.Y);
            TestUtility.TestLengthsAreEqual(y2, ln.End.Y);
            TestUtility.TestLengthsAreEqual(z1, ln.Start.Z);
            TestUtility.TestLengthsAreEqual(z2, ln.End.Z);
        }

        [Fact]
        public void LineSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var z1 = new Length(6.8, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);
            var z2 = new Length(-6.8, LengthUnit.Centimeter);

            // Act
            IPoint3d pt1 = new Point3d(x1, y1, z1);
            IPoint3d pt2 = new Point3d(x2, y2, z2);
            ILine3d ln = new Line3d(pt1, pt2);
            string json = ln.ToJson();
            ILine3d lnDeserialized = json.FromJson<Line3d>();

            // Assert
            TestUtility.TestLengthsAreEqual(x1, lnDeserialized.Start.X);
            TestUtility.TestLengthsAreEqual(x2, lnDeserialized.End.X);
            TestUtility.TestLengthsAreEqual(y1, lnDeserialized.Start.Y);
            TestUtility.TestLengthsAreEqual(y2, lnDeserialized.End.Y);
            TestUtility.TestLengthsAreEqual(z1, lnDeserialized.Start.Z);
            TestUtility.TestLengthsAreEqual(z2, lnDeserialized.End.Z);
        }

        [Fact]
        public void LineCastToVectorTest()
        {
            // Assemble
            var x1 = new Length(2.3, LengthUnit.Centimeter);
            var y1 = new Length(5.4, LengthUnit.Centimeter);
            var z1 = new Length(6.8, LengthUnit.Centimeter);
            var x2 = new Length(-2.3, LengthUnit.Centimeter);
            var y2 = new Length(-5.4, LengthUnit.Centimeter);
            var z2 = new Length(-6.8, LengthUnit.Centimeter);

            // Act
            IPoint3d pt1 = new Point3d(x1, y1, z1);
            IPoint3d pt2 = new Point3d(x2, y2, z2);
            var ln = new Line3d(pt1, pt2);
            var vector = (Vector3d)ln;

            // Assert
            TestUtility.TestLengthsAreEqual(x1 - x2, vector.X);
            TestUtility.TestLengthsAreEqual(y1 - y2, vector.Y);
            TestUtility.TestLengthsAreEqual(z1 - z2, vector.Z);
        }
    }
}
