﻿using System.Collections.Generic;

namespace MagmaWorks.Geometry
{
    public interface IExtrudedMesh
    {
        List<IPoint3d> Points { get; }
        IVector3d Direction { get; }
    }
}
