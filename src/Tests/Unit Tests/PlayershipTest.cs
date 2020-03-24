using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PlayershipTest
{
    GameObject Camera { get; set; }
    GameObject GM { get; set; }
    GameObject SM { get; set; }
    GameObject playerShip;

    [SetUp]
    public void Init()
    {
        Camera = Object.Instantiate(Resources.Load("Test/Main Camera") as GameObject);
        GM = Object.Instantiate(Resources.Load("Test/GameManager") as GameObject);
        SM = Object.Instantiate(Resources.Load("Test/SoundManager") as GameObject);
        playerShip = Object.Instantiate(Resources.Load("Test/PlayershipMove") as GameObject);
    }

    [UnityTest]
    public IEnumerator Playership_Has_Transform_Component()
    {
        Transform transform = playerShip.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_Animator_Component()
    {
        Animator animator = playerShip.GetComponent<Animator>();

        if(animator != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_SpriteRenderer_Component()
    {
        SpriteRenderer renderer = playerShip.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_Playership_Component()
    {
        PlayerShip PS = playerShip.GetComponent<PlayerShip>();

        if(PS != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_PlayershipController_Component()
    {
        PlayershipController PC = playerShip.GetComponent<PlayershipController>();

        if(PC != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_BoxCollider2D_Component()
    {
        BoxCollider2D box = playerShip.GetComponent<BoxCollider2D>();

        if(box != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_Rigidbody2D_Component()
    {
        Rigidbody2D rigid = playerShip.GetComponent<Rigidbody2D>();

        if(rigid != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_HealthPoints_Component()
    {
        HealthPoints HP = playerShip.GetComponent<HealthPoints>();

        if(HP != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Has_BlinkObject_Component()
    {
        BlinkObject BO = playerShip.GetComponent<BlinkObject>();

        if(BO != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_PlayerMissilePosition1_Has_Transform_Component()
    {
        var missile1 = playerShip.transform.GetChild(0);
        Transform transform = missile1.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_PlayerMissilePosition2_Has_Transform_Component()
    {
        var missile2 = playerShip.transform.GetChild(1);
        Transform transform = missile2.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_PlayerThrust_Has_Transform_Component()
    {
        var thrust = playerShip.transform.GetChild(2);
        Transform transform = thrust.GetComponent<Transform>();

        if(transform != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_PlayerThrust_Has_SpriteRenderer_Component()
    {
        var thrust = playerShip.transform.GetChild(2);
        SpriteRenderer renderer = thrust.GetComponent<SpriteRenderer>();

        if(renderer != null)
        {
            yield break;
        }

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Playership_Stop_Has_Transform_Component()
    {
        var stop = playerShip.transform.GetChild(3);
        Transform transform = stop.GetComponent<Transform>();

        if(transform != null)
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
        Object.Destroy(playerShip.gameObject);
    }
}
