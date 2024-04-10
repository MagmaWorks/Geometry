using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class VertexTests
    {
        [Fact]
        public void CreateVertexTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            var pt = new Point3d(x, y, z);
            var txtCoord = new Point2d();
            var vertex = new Vertex(pt, txtCoord);

            // Assert
            TestUtility.TestLengthsAreEqual(x, vertex.X);
            TestUtility.TestLengthsAreEqual(y, vertex.Y);
            TestUtility.TestLengthsAreEqual(z, vertex.Z);
        }

        [Fact]
        public void VertexSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            var pt = new Point3d(x, y, z);
            var txtCoord = new Point2d();
            var vertex = new Vertex(pt, txtCoord);
            string json = vertex.ToJson();
            ICartesianVertex vectDeserialized = json.FromJson<Vertex>();

            // Assert
            TestUtility.TestLengthsAreEqual(x, vectDeserialized.X);
            TestUtility.TestLengthsAreEqual(y, vectDeserialized.Y);
            TestUtility.TestLengthsAreEqual(z, vectDeserialized.Z);
        }

        [Fact]
        public void VertexCastToVectorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            var p = new Point3d(x, y, z);
            var txtCoord = new Point2d();
            var vertex = new Vertex(p, txtCoord);
            var pt = (Point3d)vertex;

            // Assert
            TestUtility.TestLengthsAreEqual(x, pt.X);
            TestUtility.TestLengthsAreEqual(y, pt.Y);
            TestUtility.TestLengthsAreEqual(z, pt.Z);
        }
    }
}
