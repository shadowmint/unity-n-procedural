using UnityEngine;

namespace N.Package.Procedural
{
    /// Create a mesh object using this type of factory
    public interface IMesh
    {
        /// Bind some kind of geometry into the given Mesh object
        void Bind(UnityEngine.Mesh mesh);
    }
}
