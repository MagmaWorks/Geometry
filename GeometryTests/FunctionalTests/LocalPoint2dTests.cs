using MagmaWorks.Geometry;
using OasysUnits;
using OasysUnits.Units;

namespace GeometryTests.FunctionalTests
{
    public class LocalLocalPoint2dTests
    {
        [Fact]
        public void GetPolygonAreaTest()
        {
            // Assemble
            var pt1 = new LocalPoint2d(0, 0, LengthUnit.Millimeter);
            var pt2 = new LocalPoint2d(400, 0, LengthUnit.Centimeter);
            var pt3 = new LocalPoint2d(4, 4, LengthUnit.Meter);
            var pt4 = new LocalPoint2d(0, 4, LengthUnit.Meter);

            // Act
            var list = new List<ILocalPoint2d> { pt1, pt2, pt3, pt4 };
            Area area = LocalPoint2d.GetPolygonArea(list);

            // Assert
            Assert.Equal(AreaUnit.SquareMillimeter, area.Unit);
            Assert.Equal(4 * 4, area.SquareMeters);
        }
    }
}
