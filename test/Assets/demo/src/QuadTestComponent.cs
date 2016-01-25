using UnityEngine;
using N.Package.Procedural.Mesh;
using N.Package.Procedural.Geometry;
using N.Package.Procedural.Stream;

/// Create a mesh using the QuadStream on start.
/// Destructively replaces the mesh instance with a new one.
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class QuadTestComponent : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 left;
    public Vector3 up;
    public Vector2 size;
    public Color color;
    public bool active = true;

    public void Update()
    {
        if (active)
        {
            active = false;
            var geometry = new Quad(origin, left, up, size, color);
            var stream = new Single(geometry);
            var factory = new MeshFactory(stream);
            var filter = GetComponent<MeshFilter>();
            filter.mesh = new Mesh();
            factory.Bind(filter.mesh);
      }
    }
}
