using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class BackgroundObjectsTest
{
    GameObject Camera { get; set; }
    GameObject planet;

    /// <summary>
    /// An example of an object in the background would be a planet.
    /// </summary>

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        planet = Object.Instantiate(Resources.Load("Test/BackgroundObject") as GameObject);
    }

    [UnityTest]
    public IEnumerator BackgroundObject_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = planet.GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator BackgroundObject_Has_Transform_Component()
    {
        Transform transform = planet.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator BackgroundObject_Has_SpawnPoints_Component()
    {
        SpawnPoints spawnPoints = planet.GetComponent<SpawnPoints>();

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
        Object.Destroy(planet.gameObject);
    }
}
