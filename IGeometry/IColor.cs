﻿namespace MagmaWorks.Geometry
{
    public interface IColor : IGeometry
    {
        int ColorInt { get; }
        byte Alpha { get; }
        byte Red { get; }
        byte Green { get; }
        byte Blue { get; }
    }
}
