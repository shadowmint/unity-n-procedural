#if N_PROCEDURAL_TESTS
using UnityEngine;
using NUnit.Framework;
using N.Package.Procedural.Geometry;
using System.Linq;
using N;

public class QuadTests : N.Tests.Test
{
    [Test]
    public void test_quad()
    {
        var instance = new Quad(new Vector3(0f, 0f, 0f),
                                new Vector3(0f, 1f, 0f),
                                new Vector3(1f, 0f, 0f),
                                new Vector2(10f, 10f),
                                new Color32(255, 255, 255, 255));

        Assert(instance.Vertices.Count() == 4);
        Assert(instance.Triangles.Count() == 6);
        Assert(instance.UV.Count() == 4);
        Assert(instance.Color.Count() == 4);
        Assert(instance.Normals.Count() == 0);
    }
}
#endif
