using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace N.Package.Procedural.Mesh
{
    /// MeshFactory related errors
    public class MeshFactoryException : System.Exception
    {
        public MeshFactoryException(string message) : base(message) { }
        public MeshFactoryException(string message, params object[] args) : base(string.Format(message, args)) { }
    }

    /// Generic class for binding IGeometry into Mesh objects
    public class MeshFactory : IMesh
    {
        /// The stream of geometry to use
        private IGeometryStream geometry;

        /// Does this factory use uvs?
        private bool useUV = false;

        /// Does this factory use normals?
        private bool useNormals = false;

        /// Does this factory use colors?
        private bool useColor = false;

        /// Total count of generated vertex, etc. data
        public int vertexGen = 0;
        public int triangleGen = 0;

        /// Create a new instance from some kind of geometry stream
        public MeshFactory(IGeometryStream geometry)
        {
            ValidateGeometryStream(geometry);
            this.geometry = geometry;
        }

        /// Collect and bind geometry from stream
        public void Bind(UnityEngine.Mesh mesh)
        {
            var vertices = new List<Vector3>();
            var triangles = new List<int>();
            var uv = useUV ? new List<Vector2>() : null;
            var color = useColor ? new List<Color32>() : null;
            var normals = useUV ? new List<Vector3>() : null;

            // Collect
            foreach (var gp in geometry.Geometry)
            {
                gp.VertexOffset = vertices.Count;
                vertices.AddRange(gp.Vertices);
                triangles.AddRange(gp.Triangles);
                if (uv != null) { uv.AddRange(gp.UV); }
                if (color != null) { color.AddRange(gp.Color); }
                if (normals != null) { normals.AddRange(gp.Normals); }
            }

            // Attach
            mesh.Clear();
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            if (useUV) { mesh.uv = uv.ToArray(); }
            if (useColor) { mesh.colors32 = color.ToArray(); }
            if (useNormals) { mesh.normals = normals.ToArray(); }

            // Bind
            if (!useNormals) { mesh.RecalculateNormals(); }
            mesh.RecalculateBounds();
            mesh.Optimize();

            // Summary
            vertexGen = vertices.Count;
            triangleGen = triangles.Count;
        }

        /// Validate that all geometry stream objects are compatibile.
        /// eg. If any stream has UseNormals, all must have it.
        private void ValidateGeometryStream(IGeometryStream geometry)
        {
            if (geometry.Geometry.Count() == 0) { throw new MeshFactoryException("No geometry in geometry stream"); }
            foreach (var gp in geometry.Geometry)
            {
                useUV = useUV | gp.UseUV;
                if (useUV && (!gp.UseUV)) { throw new MeshFactoryException("{0} did not implement UV as required by geometry stream", gp); }

                useNormals = useNormals | gp.UseNormals;
                if (useNormals && (!gp.UseNormals)) { throw new MeshFactoryException("{0} did not implement Normals as required by geometry stream", gp); }

                useColor = useColor | gp.UseColor;
                if (useColor && (!gp.UseColor)) { throw new MeshFactoryException("{0} did not implement Color as required by geometry stream", gp); }
            }
        }

    }
}
