#if N_PROCEDURAL_TESTS
using NUnit.Framework;
using N.Package.Procedural.Mesh;
using N.Package.Procedural.Stream;
using N.Package.Procedural.Geometry;
using UnityEngine;
using N;

public class MeshFactoryTests : N.Tests.Test
{
    [Test]
    public void test_build_new_mesh()
    {
        var mesh = new Mesh();
        var quad = new Quad(new Vector3(0f, 0f, 0f),
                            new Vector3(0f, 1f, 0f),
                            new Vector3(1f, 0f, 0f),
                            new Vector2(10f, 10f),
                            new Color32(255, 255, 255, 255));
        MeshFactory instance = new MeshFactory(new Single(quad));
        instance.Bind(mesh);
        Assert(instance.vertexGen == 4);
        Assert(instance.triangleGen == 6);
    }

    [Test]
    public void test_bind_existing_mesh()
    {
        var mesh = this.SpawnComponent<MeshFilter>();
        mesh.sharedMesh = new Mesh();
        var quad = new Quad(new Vector3(0f, 0f, 0f),
                            new Vector3(0f, 1f, 0f),
                            new Vector3(1f, 0f, 0f),
                            new Vector2(10f, 10f),
                            new Color32(255, 255, 255, 255));
        MeshFactory instance = new MeshFactory(new Single(quad));
        instance.Bind(mesh.sharedMesh);
        Assert(instance.vertexGen == 4);
        Assert(instance.triangleGen == 6);
        this.TearDown();
    }
}
#endif
