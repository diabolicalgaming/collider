using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class IRingTest
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
        enemy = Object.Instantiate(Resources.Load("Test/RingParent") as GameObject);
        Player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
    }

    [UnityTest]
    public IEnumerator RingParent_Moves_Down_Y_Axis()
    {
        //Get the ring parents original position on the y-axis.
        var positionBeforeUpdate = enemy.transform.position.y;

        yield return null;

        var positionAfterUpdate = enemy.transform.position.y;

        //Its position after update should be less than the original position, if it moves down the y-axis.
        Assert.Less(positionAfterUpdate, positionBeforeUpdate);
    }

    /// <summary>
    /// The RingParent has 8 child ring objects. I only have to check for one, because I used the Prefab Varient feature.
    /// So all other ring objects derive from the first ring.
    /// </summary>
    [UnityTest]
    public IEnumerator Ring_Moves_In_Circular_Path()
    {
        var ring = enemy.transform.GetChild(0);

        //Get its original position on the y-axis.
        var parentPositionBeforeUpdate = enemy.transform.position;

        float angleBeforeUpdate = Vector3.Angle(ring.transform.position,parentPositionBeforeUpdate);

        yield return null;

        var parentPositionAfterUpdate = enemy.transform.position;

        float angleAfterUpdate = Vector3.Angle(ring.transform.position, parentPositionAfterUpdate);

        //If the ring is moving in a circular path around the parent...
        //Then the angle between the ring and its parent after the update
        //should be greater than the angle between the ring and its parent before the update.
        Assert.Greater(angleAfterUpdate, angleBeforeUpdate);
    }

    [UnityTest]
    public IEnumerator Ring_Fires_Missiles()
    {
        var ring = enemy.transform.GetChild(0);
        var shooterPosition = ring.transform.GetChild(0).transform.position;

        yield return new WaitForSeconds(ring.GetChild(0).GetComponent<EnemyShooter>().startTime);

        var missilePosition = GameObject.FindGameObjectWithTag("EnemyMissileTag").transform.position;

        //Since the missiles initial position is where the shooters (shooter is what fires the missile) position is.
        //If the missile is fired, after the update, the position of the missile should not be the same position as its shooter
        //(which is where the missile comes from).
        Assert.AreNotEqual(missilePosition, shooterPosition);
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
