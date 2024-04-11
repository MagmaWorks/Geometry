using MagmaWorks.Geometry;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.FunctionalTests
{
    public class MeshTests
    {
        [Fact]
        public void CreateMeshAddVertexTest()
        {
            // Assemble
            var x1 = new Length(0, LengthUnit.Centimeter);
            var y1 = new Length(0, LengthUnit.Centimeter);
            var z1 = new Length(1.2, LengthUnit.Centimeter);

            var x2 = new Length(0, LengthUnit.Centimeter);
            var y2 = new Length(5.4, LengthUnit.Centimeter);
            var z2 = new Length(0, LengthUnit.Centimeter);

            var x3 = new Length(2.3, LengthUnit.Centimeter);
            var y3 = new Length(5.4, LengthUnit.Centimeter);
            var z3 = new Length(1.2, LengthUnit.Centimeter);

            // Act
            var m = new Mesh();

            var p1 = new Point3d(x1, y1, z1);
            var v1 = new Vertex(p1, new Coordinate());
            m.AddVertex(v1);

            var v2 = new Vertex(x2, y2, z2);
            m.AddVertex(v2);

            var v3 = new Vertex(x3.Value, y3.Value, z3.Value, LengthUnit.Centimeter);
            m.AddVertex(v3);

            // Assert
            Assert.Equal(3, m.Verticies.Count());
            TestUtility.TestLengthsAreEqual(x1, m.Verticies[0].X);
            TestUtility.TestLengthsAreEqual(y1, m.Verticies[0].Y);
            TestUtility.TestLengthsAreEqual(z1, m.Verticies[0].Z);
            TestUtility.TestLengthsAreEqual(x2, m.Verticies[1].X);
            TestUtility.TestLengthsAreEqual(y2, m.Verticies[1].Y);
            TestUtility.TestLengthsAreEqual(z2, m.Verticies[1].Z);
            TestUtility.TestLengthsAreEqual(x3, m.Verticies[2].X);
            TestUtility.TestLengthsAreEqual(y3, m.Verticies[2].Y);
            TestUtility.TestLengthsAreEqual(z3, m.Verticies[2].Z);
        }
    }
}
