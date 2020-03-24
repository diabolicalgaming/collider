using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PatrolTest
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
    }

    [UnityTest]
    public IEnumerator Patrol_Has_Transform_Component()
    {
        Transform transform = enemy.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Patrol_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = enemy.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Patrol_Has_BoxCollider2D_Component()
    {
        BoxCollider2D box = enemy.GetComponent<BoxCollider2D>();

        if(box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Patrol_Has_Follow_Component()
    {
        Follow follow = enemy.GetComponent<Follow>();

        if(follow != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Patrol_Has_SpawnPoints_Component()
    {
        SpawnPoints SP = enemy.GetComponent<SpawnPoints>();

        if(SP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Patrol_Has_DestroyParent_Component()
    {
        DestroyParent DP = enemy.GetComponent<DestroyParent>();

        if(DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_Transform_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        Transform transform = slicer.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_SpriteRenderer_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        SpriteRenderer renderer = slicer.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_Animator_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        Animator animator = slicer.GetComponent<Animator>();

        if(animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_BoxCollider2D_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        BoxCollider2D box = slicer.GetComponent<BoxCollider2D>();

        if(box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_Rigidbody2D_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        Rigidbody2D rigid = slicer.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_Slicer_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        Slicer slicerComp = slicer.GetComponent<Slicer>();

        if(slicerComp != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_EnemyCollider_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        EnemyCollider EC = slicer.GetComponent<EnemyCollider>();

        if(EC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_BlinkObject_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        BlinkObject BO = slicer.GetComponent<BlinkObject>();

        if(BO != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_OutOfBounds_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        OutOfBounds OOB = slicer.GetComponent<OutOfBounds>();

        if(OOB != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Has_DamagePoints_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        DamagePoints DP = slicer.GetComponent<DamagePoints>();

        if(DP == null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Thrust_Has_Transform_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        var thrust = slicer.transform.GetChild(0);
        Transform transform = thrust.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Thrust_Has_SpriteRenderer_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        var thrust = slicer.transform.GetChild(0);
        SpriteRenderer renderer = thrust.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Barrier_Has_Transform_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        var barrier = slicer.transform.GetChild(1);
        Transform transform = barrier.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Shooter_Has_Transform_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        var shooter = slicer.transform.GetChild(2);
        Transform transform = shooter.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Slicer_Shooter_Has_EnemyShooter_Component()
    {
        var slicer = enemy.transform.GetChild(0);
        var shooter = slicer.transform.GetChild(2);
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
