﻿using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ICartesianTriFace<TVertex, TCoordinate, Tx, Ty, Tz> : ICartesianFace<TVertex, TCoordinate, Tx, Ty, Tz>
        where TVertex : ICartesianVertex<TCoordinate, Tx, Ty, Tz>
        where TCoordinate : ICoordinate
        where Tx : IQuantity where Ty : IQuantity where Tz : IQuantity
    {
        TVertex A { get; }
        TVertex B { get; }
        TVertex C { get; }
    }
}
