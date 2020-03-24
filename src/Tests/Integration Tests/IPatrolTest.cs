using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IPatrolTest
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
        enemy = Object.Instantiate(Resources.Load("Test/Patrol") as GameObject);
        Player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
        enemy.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
    }

    [UnityTest]
    public IEnumerator Slicer_Fires_Missiles()
    {
        var slicer = enemy.transform.GetChild(0);
        var shooterPosition = slicer.transform.GetChild(1).transform.position;

        yield return new WaitForSeconds(slicer.GetChild(2).GetComponent<EnemyShooter>().startTime);

        var missilePosiion = GameObject.FindGameObjectWithTag("EnemyMissileTag").transform.position;

        //If a missile is fired, then its mosition is not equal to that of its shooter (where it comes from).
        Assert.AreNotEqual(shooterPosition, missilePosiion);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(GM.gameObject);
        Object.Destroy(SM.gameObject);
        Object.Destroy(Player.gameObject);
        Object.Destroy(enemy.gameObject);
        enemy.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
    }
}
