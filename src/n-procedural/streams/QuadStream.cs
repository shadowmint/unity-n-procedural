using UnityEngine;
using System.Collections.Generic;
using N.Package.Procedural.Geometry;

namespace N.Package.Procedural.Stream
{
    /// Generate a series of quads with incrementally changing vertex color
    public class QuadStream : IGeometryStream
    {
        /// Geometry factory for each factory
        private Quad quad;

        /// Number of segments to build
        private int segments;

        /// Space between segments
        private Vector3 step;

        /// Start color
        private Color32 start;

        /// End color
        private Color32 end;

        /// Base origin point
        private Vector3 origin;

        /// Create a new instance of this generator
        /// @param origin The origin of the stream of quads
        /// @param left The left vector for the quads
        /// @param up The up vector for the quads
        /// @param size The (x,y) size for the quads
        /// @param step The interval between quad instances
        /// @param segments The number of segments to generate
        /// @param start The start color of the quads
        /// @param end The end color of the quads
        public QuadStream(Vector3 origin, Vector3 left, Vector3 up, Vector2 size, Vector3 step, int segments, Color32 start, Color32 end)
        {
            quad = new Quad(origin, left, up, size, start);
            this.segments = segments;
            this.step = step;
            this.origin = origin;
            this.start = start;
            this.end = end;
        }

        public IEnumerable<IGeometry> Geometry
        {
            get
            {
                for (var i = 0; i < segments; ++i)
                {
                    quad.color = Color32.Lerp(start, end, ((float)i) / ((float)segments));
                    quad.origin = origin + i * step;
                    yield return quad;
                }
            }
        }
    }
}
