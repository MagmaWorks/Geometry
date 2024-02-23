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
            m.AddVertex(x1, y1, z1, new Point2d());

            // Assert
            Assert.Single(m.Verticies);
            TestUtility.TestLengthsAreEqual(x1, m.Verticies[0].X);
            TestUtility.TestLengthsAreEqual(y1, m.Verticies[0].Y);
            TestUtility.TestLengthsAreEqual(z1, m.Verticies[0].Z);
        }
    }
}
