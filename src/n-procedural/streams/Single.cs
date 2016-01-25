using UnityEngine;
using System.Collections.Generic;

namespace N.Package.Procedural.Stream
{
    /// A single geometry stream, for when it is desirable to use a single IGeometry source
    public class Single : IGeometryStream
    {
        IGeometry geometry;

        public Single(IGeometry geometry)
        {
            this.geometry = geometry;
        }

        public IEnumerable<IGeometry> Geometry
        {
            get { yield return geometry; }
        }
    }
}
