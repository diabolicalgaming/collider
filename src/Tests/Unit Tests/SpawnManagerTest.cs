using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// The EnemySpawner is the parent and BossSpawner is the varient. So they will both have the same
/// components which is why I will only need to test one.
/// </summary>

public class SpawnManagerTest
{
    GameObject Camera { get; set; }
    GameObject spawner;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        spawner = Object.Instantiate(Resources.Load("Test/SpawnManager") as GameObject);
    }

    [UnityTest]
    public IEnumerator SpawnManager_Has_Transform_Component()
    {
        Transform transform = spawner.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator SpawnManager_Has_SpawnManager_Component()
    {
        SpawnManager SM = spawner.GetComponent<SpawnManager>();

        if(SM != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(spawner.gameObject);
    }
}
