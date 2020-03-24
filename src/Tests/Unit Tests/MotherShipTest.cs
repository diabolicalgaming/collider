using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class MotherShipTest
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
    public IEnumerator MotherShip_Has_Transform_Component()
    {
        Transform transform = enemy.GetComponent<Transform>();

        if (transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = enemy.GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_Animator_Component()
    {
        Animator animator = enemy.GetComponent<Animator>();

        if (animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_BoxCollider2D_Component()
    {
        BoxCollider2D box = enemy.GetComponent<BoxCollider2D>();

        if (box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_Rigidbody2D_Component()
    {
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();

        if (rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_MotherShip_Component()
    {
        MotherShip MS = enemy.GetComponent<MotherShip>();

        if (MS != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_SpawnPoints_Component()
    {
        SpawnPoints SP = enemy.GetComponent<SpawnPoints>();

        if (SP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_DamagePoints_Component()
    {
        DamagePoints DP = enemy.GetComponent<DamagePoints>();

        if (DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_EnemyCollider_Component()
    {
        EnemyCollider EC = enemy.GetComponent<EnemyCollider>();

        if (EC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Has_BlinkObject_Component()
    {
        BlinkObject BO = enemy.GetComponent<BlinkObject>();

        if (BO != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Shooter_Has_Transform_Component()
    {
        var shooter = enemy.transform.GetChild(0);
        Transform transform = shooter.GetComponent<Transform>();

        if (transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator MotherShip_Shooter_Has_EnemyShooter_Component()
    {
        var shooter = enemy.transform.GetChild(0);
        EnemyShooter ES = shooter.GetComponent<EnemyShooter>();

        if (ES != null)
        {
            yield break;
        }

        Assert.Fail();
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
