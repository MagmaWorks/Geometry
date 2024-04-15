﻿namespace MagmaWorks.Geometry
{
    public interface IIntersectionResult : IGeometryBase
    {
        IntersectionType IntersectionType { get; }
        IPoint2d Point { get; }
    }
}
