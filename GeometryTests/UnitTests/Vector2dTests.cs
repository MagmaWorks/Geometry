using MagmaWorks.Geometry;
using MagmaWorks.Geometry.Serialization.Extensions;
using OasysUnits;
using OasysUnits.Units;
using ProfileTests.Utility;

namespace GeometryTests.UnitTests
{
    public class Vector2dTests
    {
        [Fact]
        public void CreateVectorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            IVector2d vect = new Vector2d(x, y);

            // Assert
            TestUtility.TestLengthsAreEqual(x, vect.X);
            TestUtility.TestLengthsAreEqual(y, vect.Y);
        }

        [Fact]
        public void VectorLengthTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            IVector2d vect = new Vector2d(x, y);
            double expectedLength = Math.Sqrt(2.3 * 2.3 + 5.4 * 5.4);

            // Assert
            Assert.Equal(expectedLength, vect.Length.Value);
        }

        [Fact]
        public void VectorSurvivesJsonRoundtripTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            IVector2d vect = new Vector2d(x, y);
            string json = vect.ToJson();
            IVector2d vectDeserialized = json.FromJson<Vector2d>();

            // Assert
            TestUtility.TestLengthsAreEqual(vect.X, vectDeserialized.X);
            TestUtility.TestLengthsAreEqual(vect.Y, vectDeserialized.Y);
        }

        [Fact]
        public void VectorMultiplyOperatorTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            var vect = new Vector2d(x, y);
            Vector2d scaled = 1.5 * vect;

            // Assert
            Assert.Equal(1.5 * 2.3, scaled.U.Value);
            Assert.Equal(1.5 * 5.4, scaled.V.Value);
        }

        [Fact]
        public void VectorCastToPointTest()
        {
            // Assemble
            var x = new Length(2.3, LengthUnit.Centimeter);
            var y = new Length(5.4, LengthUnit.Centimeter);

            // Act
            var vect = new Vector2d(x, y);
            var pt = (Point2d)vect;

            // Assert
            TestUtility.TestLengthsAreEqual(x, pt.X);
            TestUtility.TestLengthsAreEqual(y, pt.Y);
        }
    }
}
