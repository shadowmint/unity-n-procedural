using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace N.Package.Procedural.Geometry
{
    /// A single simple quad
    public class Tube : IGeometry
    {
        /// The origin of the quad
        public Vector3 origin;

        /// The direction vectors
        public Vector3 up;
        public Vector3 left;

        /// The size of the quad in x and y directions
        public Vector2 size;

        /// The color for this quad in vertex colors
        public Color32 color;

        /// The offset into the total vertex list to start from
        private int offset;

        /// Create a new quad
        public Tube(Vector3 origin, Vector3 left, Vector3 up, Vector2 size, Color32 color)
        {
            this.origin = origin;
            this.left = left.normalized;
            this.up = up.normalized;
            this.size = size;
            this.color = color;
        }

        /// Set the master vertex offset
        public int VertexOffset { set { offset = value; } }

        /// Set of vertex data (mandatory)
        public IEnumerable<Vector3> Vertices
        {
            get
            {
                yield return origin + (left * size[0] / 2f) + (up * size[1] / 2f);
                yield return origin - (left * size[0] / 2f) + (up * size[1] / 2f);
                yield return origin - (left * size[0] / 2f) - (up * size[1] / 2f);
                yield return origin + (left * size[0] / 2f) - (up * size[1] / 2f);
            }
        }

        /// Set of triangles from vertex data (mandatory)
        public IEnumerable<int> Triangles
        {
            get
            {
                yield return offset + 0;
                yield return offset + 1;
                yield return offset + 2;
                yield return offset + 0;
                yield return offset + 2;
                yield return offset + 3;
            }
        }

        /// UV data (optional)
        public bool UseUV { get { return true; } }
        public IEnumerable<Vector2> UV
        {
            get
            {
                yield return new Vector2(0, 1);
                yield return new Vector2(1, 1);
                yield return new Vector2(1, 0);
                yield return new Vector2(0, 0);
            }
        }

        /// Color data (optional)
        public bool UseColor { get { return true; } }
        public IEnumerable<Color32> Color
        {
            get
            {
                yield return color;
                yield return color;
                yield return color;
                yield return color;
            }
        }

        /// Normals data (optional)
        public bool UseNormals
        { get { return false; } }

        public IEnumerable<Vector3> Normals
        { get { return Enumerable.Empty<Vector3>(); } }
    }
}
