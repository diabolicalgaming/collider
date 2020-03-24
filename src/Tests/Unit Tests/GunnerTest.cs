using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using NSubstitute;
using System.Collections;

public class GunnerTest : MonoBehaviour
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
    public IEnumerator Gunner_Has_Transform_Component()
    {
        Transform transform = enemy.GetComponent<Transform>();

        if (transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = enemy.GetComponent<SpriteRenderer>();

        if (renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_Animator_Component()
    {
        Animator animator = enemy.GetComponent<Animator>();

        if (animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_BoxCollider2D_Component()
    {
        BoxCollider2D box = enemy.GetComponent<BoxCollider2D>();

        if (box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_Rigidbody2D_Component()
    {
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_Gunner_Component()
    {
        Gunner Gunner = enemy.GetComponent<Gunner>();

        if(Gunner != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_EnemyCollider_Component()
    {
        EnemyCollider EC = enemy.GetComponent<EnemyCollider>();

        if(EC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_SpawnPoints_Component()
    {
        SpawnPoints SP = enemy.GetComponent<SpawnPoints>();

        if(SP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_OutOfBounds_Component()
    {
        OutOfBounds OOB = enemy.GetComponent<OutOfBounds>();

        if(OOB != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_DamagePoints_Component()
    {
        DamagePoints DP = enemy.GetComponent<DamagePoints>();

        if(DP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Has_BlinkObject_Component()
    {
        BlinkObject BO = enemy.GetComponent<BlinkObject>();

        if(BO != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Thrust_Has_Transform_Component()
    {
        var thrust = enemy.transform.GetChild(0);

        Transform transform = thrust.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Thrust_Has_SpriteRenderer_Component()
    {
        var thrust = enemy.transform.GetChild(0);

        SpriteRenderer renderer = thrust.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Shooter_Has_Transform_Component()
    {
        var shooter = enemy.transform.GetChild(1);

        Transform transform = shooter.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Gunner_Shooter_Has_EnemyShooter_Component()
    {
        var shooter = enemy.transform.GetChild(1);

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
