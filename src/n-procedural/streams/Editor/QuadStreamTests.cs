#if N_PROCEDURAL_TESTS
using NUnit.Framework;
using N.Package.Procedural.Stream;
using UnityEngine;
using System.Linq;
using N;

public class QuadStreamTests : N.Tests.Test
{
    [Test]
    public void test_quad_stream()
    {
        var stream = new QuadStream(new Vector3(0f, 0f, 0f),
                                    new Vector3(-1f, 0f, 0f),
                                    new Vector3(0f, 1f, 0f),
                                    new Vector2(2f, 2f),
                                    new Vector3(0f, 0.5f, 0f),
                                    10,
                                    new Color32(0, 0, 0, 0),
                                    new Color32(0, 255, 0, 0));
        Assert(stream.Geometry.Count() == 10);
    }
}
#endif
