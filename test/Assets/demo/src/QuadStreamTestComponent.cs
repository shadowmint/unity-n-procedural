using UnityEngine;
using N.Package.Procedural.Mesh;
using N.Package.Procedural.Stream;

/// Create a mesh using the QuadStream on start.
/// Destructively replaces the mesh instance with a new one.
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class QuadStreamTestComponent : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 left;
    public Vector3 up;
    public Vector2 size;
    public Vector3 step;
    public int segments;
    public Color startColor;
    public Color endColor;
    public bool active = true;

    public void Update()
    {
        if (active)
        {
            active = false;
            var stream = new QuadStream(origin, left, up, size, step, segments, startColor, endColor);
            var factory = new MeshFactory(stream);
            var filter = GetComponent<MeshFilter>();
            filter.mesh = new Mesh();
            factory.Bind(filter.mesh);
        }
    }
}
