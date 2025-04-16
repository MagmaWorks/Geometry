﻿using UnitsNet;

namespace MagmaWorks.Geometry
{
    public interface ICartesian2d<Tu, Tv> : IGeometryBase
        where Tu : IQuantity where Tv : IQuantity
    {
        Tu U { get; }
        Tv V { get; }
    }
}
