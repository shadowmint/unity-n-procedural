using System.Collections.Generic;
using UnityEngine;

namespace N.Package.Procedural
{
    /// Generate geometry for a mesh with this type
    public interface IGeometry
    {
      /// Set the offset into the geometry stream for the first vertex
      int VertexOffset { set; }

      /// Set of vertex data (mandatory)
      IEnumerable<Vector3> Vertices { get; }

      /// Set of triangles from vertex data (mandatory)
      IEnumerable<int> Triangles { get; }

      /// UV data (optional)
      bool UseUV { get; }
      IEnumerable<Vector2> UV { get; }

      /// Color data (optional)
      bool UseColor { get; }
      IEnumerable<Color32> Color { get; }

      /// Normals data (optional)
      bool UseNormals { get; }
      IEnumerable<Vector3> Normals { get; }
    }
}
