using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using OasysUnits;
using OasysUnits.Units;

namespace MagmaWorks.Geometry
{
    public class Mesh : IMesh
    {
        public IList<int[]> MeshIndices { get; set; }
        public IList<IVertex> Nodes { get; set; }
        public double Opacity { get; set; }
        public IBrush Brush { get; set; }

        public Mesh()
        {
            MeshIndices = new List<int[]>();
            Nodes = new List<IVertex>();
            Brush = new Brush(128, 128, 0);
            Opacity = 1;
        }

        public void AddNode(Length x, Length y, Length z, IPoint2d textureCoordinates)
        {
            Nodes.Add(new Vertex(new Point3d(x, y, z), textureCoordinates));
        }

        public void SetIndices(List<int[]> indices)
        {
            MeshIndices = new List<int[]>();
            foreach (int[] item in indices)
            {
                if (item.Length == 3)
                {
                    MeshIndices.Add(item);
                }
            }
        }

        public List<int[]> GetUniqueEdges()
        {
            List<int[]> returnList = new List<int[]>();
            foreach (int[] triangle in MeshIndices)
            {
                List<int[]> edges = new List<int[]>
                {
                    new int[] { triangle[0], triangle[1] },
                    new int[] { triangle[1], triangle[2] },
                    new int[] { triangle[2], triangle[0] }
                };

                foreach (int[] edge in edges)
                {
                    bool add = true;
                    foreach (int[] edge2 in returnList)
                    {
                        if ((edge[0] == edge2[0] && edge[1] == edge2[1])
                           || (edge[0] == edge2[1] && edge[1] == edge2[0]))
                        {
                            add = false;
                        }
                    }

                    if (add)
                    {
                        returnList.Add(edge);
                    }
                }
            }

            return returnList;
        }

        public List<int[]> GetAllEdges()
        {
            List<int[]> returnList = new List<int[]>();
            foreach (int[] triangle in MeshIndices)
            {
                List<int[]> edges = new List<int[]>
                {
                    new int[] { triangle[0], triangle[1] },
                    new int[] { triangle[1], triangle[2] },
                    new int[] { triangle[2], triangle[0] }
                };

                foreach (int[] edge in edges)
                {
                    returnList.Add(edge);
                }
            }
            return returnList;
        }

        public List<int[]> GetOuterEdges()
        {
            List<int[]> allEdges = GetAllEdges();
            var returnList = new List<int[]>();
            for (int i = 0; i < allEdges.Count; i++)
            {
                int[] edge = allEdges[i];
                bool isOuterEdge = true;
                for (int j = 0; j < allEdges.Count; j++)
                {
                    int[] edge2 = allEdges[j];
                    if (((edge[0] == edge2[0] && edge[1] == edge2[1])
                        || (edge[0] == edge2[1] && edge[1] == edge2[0]))
                        && (i != j))
                    {
                        isOuterEdge = false;
                    }
                }

                if (isOuterEdge)
                {
                    returnList.Add(new int[] { edge[0], edge[1] });
                }
            }

            return returnList;
        }

        public List<List<int>> GetMeshOutlines()
        {
            List<int[]> outerEdges = GetOuterEdges();
            List<bool> alreadyUsed = new List<bool>();
            foreach (int[] item in outerEdges)
            {
                alreadyUsed.Add(false);
            }

            var returnList = new List<List<int>>();
            for (int i = 0; i < outerEdges.Count; i++)
            {
                if (alreadyUsed[i] == false)
                {
                    List<int> currentList = new List<int>();
                    bool nothingAdded = false;
                    int prevID = outerEdges[i][1];
                    while (!nothingAdded)
                    {
                        bool somethingAdded = false;
                        for (int j = 0; j < outerEdges.Count; j++)
                        {
                            if (!alreadyUsed[j] && prevID == outerEdges[j][0])
                            {
                                somethingAdded = true;
                                currentList.Add(outerEdges[j][1]);
                                prevID = outerEdges[j][1];
                                alreadyUsed[j] = true;
                            }
                            else if (!alreadyUsed[j] && prevID == outerEdges[j][1])
                            {
                                somethingAdded = true;
                                currentList.Add(outerEdges[j][0]);
                                prevID = outerEdges[j][0];
                                alreadyUsed[j] = true;
                            }
                        }

                        if (!somethingAdded)
                        {
                            nothingAdded = true;
                        }
                    }

                    returnList.Add(currentList);
                }

            }
            return returnList;
        }

        public void ReverseFaceDirections()
        {
            foreach (int[] face in MeshIndices)
            {
                int temp = face[0];
                face[0] = face[2];
                face[2] = temp;
            }
        }

        public static Mesh MakeExtrudedPolygon(IPoint3d start, IPoint3d end, Length radius, int sides)
        {
            var returnMesh = new Mesh();
            LengthUnit unit = start.X.Unit;
            Length length = ((Point3d)end - (Point3d)start).Length;
            ILocalCoordinateSystem localCoords = LocalCoordinateSystem.LocalCoordSystemFromLinePoints(start, end);
            Matrix4x4 transMatrix = Point3d.GetTransformMatrix2dTo3d(start, (Point3d)start + (Vector3d)localCoords.XAxis, (Point3d)start + (Vector3d)localCoords.YAxis);
            var startPoints = new List<IPoint3d>();
            var endPoints = new List<IPoint3d>();
            double angle = 2 * Math.PI / sides;
            for (int i = 0; i < sides; i++)
            {
                Length x = radius * Math.Cos(angle * i);
                Length y = radius * Math.Sin(angle * i);
                startPoints.Add(new Point3d(x, y, Length.Zero));
                endPoints.Add(new Point3d(x, y, length));
            }

            for (int i = 0; i < startPoints.Count; i++)
            {
                var newPoint1 = Point3d.TransformedPoint(startPoints[i], transMatrix);
                var newPoint2 = Point3d.TransformedPoint(endPoints[i], transMatrix);
                returnMesh.AddNode(newPoint1.X, newPoint1.Y, newPoint1.Z, new Point2d(new Length(0.5, unit), new Length(0.5, unit)));
                returnMesh.AddNode(newPoint2.X, newPoint2.Y, newPoint2.Z, new Point2d(new Length(0.5, unit), new Length(0.5, unit)));
            }

            int prevStart = sides * 2 - 2;
            int prevEnd = sides * 2 - 1;
            for (int i = 0; i < startPoints.Count; i++)
            {
                int nextStart = i * 2; int nextEnd = (i * 2) + 1;
                returnMesh.MeshIndices.Add(new int[] { prevStart, nextEnd, prevEnd });
                returnMesh.MeshIndices.Add(new int[] { nextStart, nextEnd, prevStart });
                prevStart = nextStart;
                prevEnd = nextEnd;
            }

            returnMesh.Opacity = 1;
            returnMesh.Brush = new Brush(255, 128, 128);
            return returnMesh;
        }

        public static Mesh MakeExtrudedPolygon(IPoint3d start, IPoint3d end, List<IPoint3d> startPoints)
        {
            Mesh returnMesh = new Mesh();
            LengthUnit unit = start.X.Unit;
            Vector3d extrusionRail = (Point3d)end - (Point3d)start;
            ILocalCoordinateSystem localCoords = LocalCoordinateSystem.LocalCoordSystemFromLinePoints(start, end);
            Matrix4x4 transMatrix = Point3d.GetTransformMatrix2dTo3d(start, (Point3d)start + (Vector3d)localCoords.XAxis, (Point3d)start + (Vector3d)localCoords.YAxis);
            var endPoints = new List<IPoint3d>();
            foreach (IPoint3d point in startPoints)
            {
                endPoints.Add((Point3d)point + extrusionRail);
            }

            for (int i = 0; i < startPoints.Count; i++)
            {
                IPoint3d newPoint1 = startPoints[i];
                IPoint3d newPoint2 = endPoints[i];
                returnMesh.AddNode(newPoint1.X, newPoint1.Y, newPoint1.Z, new Point2d(new Length(0.5, unit), new Length(0.5, unit)));
                returnMesh.AddNode(newPoint2.X, newPoint2.Y, newPoint2.Z, new Point2d(new Length(0.5, unit), new Length(0.5, unit)));
            }

            int sides = startPoints.Count;
            int prevStart = sides * 2 - 2;
            int prevEnd = sides * 2 - 1;
            for (int i = 0; i < startPoints.Count; i++)
            {
                int nextStart = i * 2; int nextEnd = (i * 2) + 1;
                returnMesh.MeshIndices.Add(new int[] { prevStart, nextEnd, prevEnd });
                returnMesh.MeshIndices.Add(new int[] { nextStart, nextEnd, prevStart });
                prevStart = nextStart;
                prevEnd = nextEnd;
            }

            returnMesh.Opacity = 1;
            returnMesh.Brush = new Brush(255, 128, 128);
            return returnMesh;
        }
    }
}
