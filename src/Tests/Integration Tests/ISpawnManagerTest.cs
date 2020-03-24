using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// The EnemySpawner is the parent and BossSpawner is the varient. So they will both have the same
/// components which is why I will only need to test one.
/// </summary>

public class ISpawnManagerTest : MonoBehaviour
{
    GameObject Camera { get; set; }
    GameObject Player { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject MovingPositions { get; set; }
    GameObject spawner;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        Player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        MovingPositions = Object.Instantiate(Resources.Load("Test/MovingPosition") as GameObject);
        spawner = Object.Instantiate(Resources.Load("Test/SpawnManager") as GameObject);
    }

    [UnityTest]
    public IEnumerator SpawnManager_Spawns_Object()
    {
        yield return new WaitForSeconds(spawner.GetComponent<SpawnManager>().startTime);

        var obj = GameObject.FindObjectOfType(typeof(MonoBehaviour));

        //If the object exists, then the test should pass.
        if(obj != null)
        {
            Destroy(obj);
            yield break;
        }

        Assert.Fail();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(Player.gameObject);
        Object.Destroy(GM.gameObject);
        Object.Destroy(SM.gameObject);
        Object.Destroy(spawner.gameObject);
    }
}
