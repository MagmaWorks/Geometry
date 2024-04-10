﻿using System.Collections.Generic;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public interface ICartesianModel3d<TMesh, TVertex, TCoordinate, TText, TPoint, TVector, Txyz, Tx, Ty, Tz> : IGeometryBase
        where TMesh : ICartesianMesh<TVertex, TCoordinate, Tx, Ty, Tz>
        where TVertex : ICartesianVertex<TCoordinate, Tx, Ty, Tz>
        where TCoordinate : ICoordinate
        where TText : ICartesianText3d<TPoint, TVector, Txyz, Tx, Ty, Tz>
        where TPoint : ICartesian3d<Tx, Ty, Tz>
        where TVector : ICartesianVector3d<Txyz, Tx, Ty, Tz>
        where Txyz : IQuantity where Tx : IQuantity where Ty : IQuantity where Tz : IQuantity
    {
        IEnumerable<TMesh> Meshes { get; }
        IEnumerable<TText> Texts { get; }
    }
}
