using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IGunnerTest : MonoBehaviour
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
        enemy = Object.Instantiate(Resources.Load("Test/Gunner") as GameObject);
        Player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
    }

    [UnityTest]
    public IEnumerator Gunner_Moves_Side_To_Side_On_X_Axis()
    {
        var positionBeforeUpdate = enemy.transform.position.x;

        yield return null;

        var positionAfterUpdate = enemy.transform.position.x;

        //If it moves, then the positions are not the same.
        Assert.AreNotEqual(positionAfterUpdate, positionBeforeUpdate);
    }

    [UnityTest]
    public IEnumerator Gunner_Moves_Down_Y_Axis()
    {
        var positionBeforeUpdate = enemy.transform.position.y;

        yield return null;

        var positionAfterUpdate = enemy.transform.position.y;

        //Should be less if it moved down the y-axis.
        Assert.Less(positionAfterUpdate, positionBeforeUpdate);
    }

    [UnityTest]
    public IEnumerator Gunner_Fires_Missiles()
    {
        var shooterPosition = enemy.transform.GetChild(1).transform.position;

        yield return new WaitForSeconds(enemy.transform.GetChild(1).GetComponent<EnemyShooter>().startTime);

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
