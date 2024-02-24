using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Vector3dTests
    {
        [Fact]
        public void CreateVectorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            IVector3d pt = new Vector3d(x, y, z);

            // Assert
            TestUtility.TestLengthsAreEqual(x, pt.X);
            TestUtility.TestLengthsAreEqual(y, pt.Y);
            TestUtility.TestLengthsAreEqual(z, pt.Z);
        }

        [Fact]
        public void VectorLengthTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            IVector3d vect = new Vector3d(x, y, z);
            double expectedLength = Math.Sqrt(2.3 * 2.3 + 5.4 * 5.4 + 6.8 * 6.8);

            // Assert
            Assert.Equal(expectedLength, vect.Length.Value);
        }

        [Fact]
        public void VectorSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            IVector3d vect = new Vector3d(x, y, z);
            string json = vect.ToJson();
            IVector3d vectDeserialized = json.FromJson<Vector3d>();

            // Assert
            TestUtility.TestLengthsAreEqual(vect.X, vectDeserialized.X);
            TestUtility.TestLengthsAreEqual(vect.Y, vectDeserialized.Y);
            TestUtility.TestLengthsAreEqual(vect.Z, vectDeserialized.Z);
        }

        [Fact]
        public void VectorCastToVectorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);
            var z = new Length(6.8, LengthUnit.Centimeter);

            // Act
            var vect = new Vector3d(x, y, z);
            var pt = (Point3d)vect;

            // Assert
            TestUtility.TestLengthsAreEqual(x, pt.X);
            TestUtility.TestLengthsAreEqual(y, pt.Y);
            TestUtility.TestLengthsAreEqual(z, pt.Z);
        }
    }
}
