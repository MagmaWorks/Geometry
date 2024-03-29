﻿using System.Collections.Generic;

namespace MagmaWorks.Geometry.Utility.Extensions
{
    public static class ListExtension
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> value)
        {
            if (value == null || value.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
