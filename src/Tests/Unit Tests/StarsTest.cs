using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class StarsTest
{
    GameObject Camera { get; set; }
    GameObject star;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        star = Object.Instantiate(Resources.Load("Test/Star") as GameObject);
    }

    [UnityTest]
    public IEnumerator Star_Has_Transform_Component()
    {
        Transform transform = star.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Star_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = star.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Star_Has_Stars_Component()
    {
        Stars stars = star.GetComponent<Stars>();

        if(stars != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Star_Has_SpawnPoints_Component()
    {
        SpawnPoints spawnPoints = star.GetComponent<SpawnPoints>();

        if(spawnPoints != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(star.gameObject);
    }
}
