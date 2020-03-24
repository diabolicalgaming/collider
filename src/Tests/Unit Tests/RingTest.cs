using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// These tests are written to unit test the Ring and RingParent enemy prefabs.
/// </summary>

public class RingTest
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
    public IEnumerator RingParent_Has_Transform_Component()
    {
        Transform transform = enemy.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator RingParent_Has_ObjectGravity_Component()
    {
        ObjectGravity OG = enemy.GetComponent<ObjectGravity>();

        if(OG != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator RingParent_Has_SpawnPoints_Component()
    {
        SpawnPoints SP = enemy.GetComponent<SpawnPoints>();

        if(SP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator RingParent_Has_DestroyParent_Component()
    {
        DestroyParent DP = enemy.GetComponent<DestroyParent>();

        if(DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator RingParent_Has_OutOufBounds_Component()
    {
        OutOfBounds OOB = enemy.GetComponent<OutOfBounds>();

        if(OOB != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_Transform_Component()
    {
        var ring = enemy.transform.GetChild(0);
        Transform transform = ring.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_SpriteRenderer_Component()
    {
        var ring = enemy.transform.GetChild(0);
        SpriteRenderer renderer = ring.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_Animator_Component()
    {
        var ring = enemy.transform.GetChild(0);
        Animator animator = ring.GetComponent<Animator>();

        if(animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_CircleCollider2D_Component()
    {
        var ring = enemy.transform.GetChild(0);
        CircleCollider2D circle = ring.GetComponent<CircleCollider2D>();

        if(circle != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_Rigidbody2D_Component()
    {
        var ring = enemy.transform.GetChild(0);
        Rigidbody2D rigid = ring.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_Ring_Component()
    {
        var ring = enemy.transform.GetChild(0);
        Ring ringComp = ring.GetComponent<Ring>();

        if (ringComp != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_EnemyCollider_Component()
    {
        var ring = enemy.transform.GetChild(0);
        EnemyCollider EC = ring.GetComponent<EnemyCollider>();

        if(EC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_BlinkObject_Component()
    {
        var ring = enemy.transform.GetChild(0);
        BlinkObject BO = ring.GetComponent<BlinkObject>();

        if(BO != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_OutOfBounds_Component()
    {
        var ring = enemy.transform.GetChild(0);
        OutOfBounds OOB = ring.GetComponent<OutOfBounds>();

        if(OOB != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Has_DamagePoints_Component()
    {
        var ring = enemy.transform.GetChild(0);
        DamagePoints DP = ring.GetComponent<DamagePoints>();

        if(DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Shooter_Has_Transform_Component()
    {
        var ring = enemy.transform.GetChild(0);
        var shooter = ring.transform.GetChild(0);
        Transform transform = shooter.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Ring_Shooter_Has_EnemyShooter_Component()
    {
        var ring = enemy.transform.GetChild(0);
        var shooter = ring.transform.GetChild(0);
        EnemyShooter ES = shooter.GetComponent<EnemyShooter>();

        if(ES != null)
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
