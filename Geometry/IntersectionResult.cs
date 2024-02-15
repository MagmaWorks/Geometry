using OasysUnits;

namespace MagmaWorks.Geometry
{
    public class IntersectionResult : IIntersectionResult
    {
        public IntersectionType IntersectionType { get; private set; }
        public IPoint2d Point { get; private set; }

        public IntersectionResult(IntersectionType intersectionType, IPoint2d point)
        {
            Point = point;
            IntersectionType = intersectionType;
        }
    }
}
