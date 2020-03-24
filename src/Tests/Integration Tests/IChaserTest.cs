using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IChaserTest
{
    GameObject Camera { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject Player { get; set; }
    GameObject enemy;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        enemy = Object.Instantiate(Resources.Load("Test/Chaser") as GameObject);
        Player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
    }

    [UnityTest]
    public IEnumerator Chaser_Chases_Player()
    {
        var originalPosition = enemy.transform.position;

        yield return null;

        var newPotision = enemy.transform.position;

        Assert.AreNotEqual(newPotision, originalPosition);
    }

    [UnityTest]
    public IEnumerator Chaser_LooksAt_Player()
    {
        float angle = Vector3.Angle(enemy.transform.forward, Player.transform.position - enemy.transform.position);

        yield return null;

        Assert.Greater(angle,30f);
    }

    [UnityTest]
    public IEnumerator Chaser_Fires_Missiles()
    {
        var shooterPosition = enemy.transform.GetChild(2).transform.position;

        yield return new WaitForSeconds(enemy.transform.GetChild(2).GetComponent<EnemyShooter>().startTime);

        var missilePosition = GameObject.FindGameObjectWithTag("EnemyMissileTag").transform.position;

        Assert.AreNotEqual(shooterPosition, missilePosition);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(GM.gameObject);
        Object.Destroy(SM.gameObject);
        Object.Destroy(Player.gameObject);
        Object.Destroy(enemy.gameObject);
    }
}
