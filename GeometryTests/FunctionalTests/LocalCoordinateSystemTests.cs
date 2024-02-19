using MagmaWorks.Geometry;
using OasysUnits.Units;

namespace GeometryTests.FunctionalTests
{
    public class LocalCoordinateSystemTests
    {
        //[Fact]
        //public void LocalCoordSystemFromXAxisLineTest()
        //{
        //    // Assemble
        //    var pt1 = new Point3d(4.5, 0, 0, LengthUnit.Meter);
        //    var pt2 = new Point3d(15, 0, 0, LengthUnit.Meter);

        //    // Act
        //    var ln = new Line3d(pt1, pt2);
        //    ILocalCoordinateSystem local = LocalCoordinateSystem.LocalCoordSystemFromLinePoints(ln);

        //    // Assert
        //    Assert.Equal(4.5, local.Origin.X.Value);
        //    Assert.Equal(0, local.Origin.Y.Value);
        //    Assert.Equal(0, local.Origin.Z.Value);

        //    Assert.Equal(0, local.XAxis.X.Value);
        //    Assert.Equal(-1, local.XAxis.Y.Value);
        //    Assert.Equal(0, local.XAxis.Z.Value);

        //    Assert.Equal(0, local.YAxis.X.Value);
        //    Assert.Equal(0, local.YAxis.Y.Value);
        //    Assert.Equal(-1, local.YAxis.Z.Value);

        //    Assert.Equal(1, local.ZAxis.X.Value);
        //    Assert.Equal(0, local.ZAxis.Y.Value);
        //    Assert.Equal(0, local.ZAxis.Z.Value);
        //}

        //[Fact]
        //public void LocalCoordSystemFromZAxisLineTest()
        //{
        //    // Assemble
        //    var pt1 = new Point3d(4.5, 3.2, 2, LengthUnit.Meter);
        //    var pt2 = new Point3d(4.5, 3.2, -10, LengthUnit.Meter);

        //    // Act
        //    var ln = new Line3d(pt1, pt2);
        //    ILocalCoordinateSystem local = LocalCoordinateSystem.LocalCoordSystemFromLinePoints(ln);

        //    // Assert
        //    Assert.Equal(4.5, local.Origin.X.Value);
        //    Assert.Equal(3.2, local.Origin.Y.Value);
        //    Assert.Equal(2, local.Origin.Z.Value);

        //    Assert.Equal(0, local.XAxis.X.Value);
        //    Assert.Equal(-1, local.XAxis.Y.Value);
        //    Assert.Equal(0, local.XAxis.Z.Value);

        //    Assert.Equal(-1, local.YAxis.X.Value);
        //    Assert.Equal(0, local.YAxis.Y.Value);
        //    Assert.Equal(0, local.YAxis.Z.Value);

        //    Assert.Equal(0, local.ZAxis.X.Value);
        //    Assert.Equal(0, local.ZAxis.Y.Value);
        //    Assert.Equal(-1, local.ZAxis.Z.Value);
        //}
    }
}
