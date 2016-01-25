using System.Collections.Generic;
using UnityEngine;

namespace N.Package.Procedural
{
    /// Generate a geometry stream for a mesh
    public interface IGeometryStream {
      IEnumerable<IGeometry> Geometry { get; }
    }
}
