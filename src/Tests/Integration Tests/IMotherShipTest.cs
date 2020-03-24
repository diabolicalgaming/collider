using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class IMotherShipTest
{
    GameObject Camera { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject Player { get; set; }
    GameObject MovingPositions { get; set; }
    GameObject enemy;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        enemy = Object.Instantiate(Resources.Load("Test/MotherShip") as GameObject);
        Player = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
        MovingPositions = Object.Instantiate(Resources.Load("Test/MovingPosition") as GameObject);
    }

    [UnityTest]
    public IEnumerator MotherShip_LooksAt_Player()
    {
        float angle = Vector3.Angle(enemy.transform.forward, Player.transform.position - enemy.transform.position);

        yield return null;

        Assert.Greater(angle, 30f);
    }

    [UnityTest]
    public IEnumerator MotherShip_Moves_To_Moving_Positions()
    {
        //Get all of the positions that the MotherShip can move to.
        GameObject[] positions = enemy.GetComponent<MotherShip>().positionObjects;

        List<Vector3> positionVectors = new List<Vector3>();

        foreach(GameObject go in positions)
        {
            //Add the Vectors of each position to the positionVectors list.
            positionVectors.Add(go.transform.position);
        }

        //Allow the MotherShip to move around for some time.
        yield return new WaitForSeconds(9f);

        //If the current position of the MotherShip is in the list of all possible positions that it can move, then the test should pass.
        if(positionVectors.Contains(enemy.transform.position))
        {
            yield break;
        }

        //Otherwise it should fail.
        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Mothership_Fires_Missiles()
    {
        var shooterPosition = enemy.transform.GetChild(0).transform.position;

        yield return new WaitForSeconds(enemy.transform.GetChild(0).GetComponent<EnemyShooter>().startTime);

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
