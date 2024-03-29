﻿using System.Collections.Generic;
using System.Linq;
using OasysUnits;

namespace MagmaWorks.Geometry
{
    public class Model3d : IModel3d
    {
        public IList<IMesh> Meshes { get; set; }
        public IList<IText3d> Texts { get; set; }

        public Model3d(IMesh mesh)
        {
            Meshes = new List<IMesh> { mesh };
            Texts = new List<IText3d>();
        }

        public Point3d GetMinimumCorner()
        {
            Length x = Meshes.SelectMany(a => a.Verticies).Min(b => b.X);
            Length y = Meshes.SelectMany(a => a.Verticies).Min(b => b.Y);
            Length z = Meshes.SelectMany(a => a.Verticies).Min(b => b.Z);
            return new Point3d(x, y, z);
        }

        public Point3d GetMaximumCorner()
        {
            Length x = Meshes.SelectMany(a => a.Verticies).Max(b => b.X);
            Length y = Meshes.SelectMany(a => a.Verticies).Max(b => b.Y);
            Length z = Meshes.SelectMany(a => a.Verticies).Max(b => b.Z);
            return new Point3d(x, y, z);
        }
    }
}
