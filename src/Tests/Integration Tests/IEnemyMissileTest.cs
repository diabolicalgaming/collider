using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// This test is just to check that all of the enemy missiles have the correct components.
/// I have chosen one example of an enemy missile to test because I made use of a new feature in
/// Unity called prefab variarents. This allows me to have one parent object where other varients
/// of that parent can be made. All enemy missiles prefab varients derive from the ChaserMissile parent
/// prefab, which is why I have used it as an example. Each other varient will have the same components attached.
/// </summary>

public class IEnemyMissileTest
{
    GameObject Camera { get; set; }
    GameObject Chaser { get; set; }
    GameObject Player { get; set; }
    GameObject missile;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        missile = Object.Instantiate(Resources.Load("Test/ChaserMissile") as GameObject);
    }

    /// <summary>
    /// The enemy missile prefab on its own shouldn't move.
    /// It should only move after the enemy fires it.
    /// </summary>
    [UnityTest]
    public IEnumerator EnemeyMissile_Prefab_Does_Not_Move()
    {
        var positionBeforeUpdate = missile.transform.position;

        yield return null;

        var positionAfterUpdate = missile.transform.position;

        Assert.AreEqual(positionAfterUpdate, positionBeforeUpdate);
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(Camera.gameObject);
        Object.Destroy(missile.gameObject);
    }
}
