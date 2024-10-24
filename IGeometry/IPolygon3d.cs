﻿using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IPolygon3d : IGeometryBase, IPolygonBase<IDomain, IPoint3d>
    {
        IList<IPoint3d> Points { get; }
    }
}
